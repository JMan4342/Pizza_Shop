import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';
import { MultiSelectModule } from 'primeng/multiselect';
import { ToppingsService } from '../../../toppings/toppings.service';
import { PizzasService } from '../../pizzas.service';
import { Topping } from '../../../shared/classes/topping';

@Component({
  selector: 'app-new-pizza',
  standalone: true,
  imports: [
    CardModule,
    FormsModule,
    ButtonModule,
    InputTextModule,
    MultiSelectModule,
  ],
  templateUrl: './new-pizza.component.html',
  styleUrl: './new-pizza.component.css',
})
export class NewPizzaComponent implements OnInit {
  @Output() outModalState = new EventEmitter<number>();
  @Output() outModalVisible = new EventEmitter<boolean>();
  @Output() repullPizzas = new EventEmitter<boolean>();

  newPizzaName: string = '';
  availableToppings: Topping[] = [];
  selectedToppings: Topping[] = [];

  constructor(
    private pizzasService: PizzasService,
    private toppingsService: ToppingsService
  ) {}

  ngOnInit(): void {
    this.toppingsService.getToppings().subscribe({
      next: (results) => {
        console.log(results);
        this.availableToppings = results;
      },
      error: (err) => console.log(err),
    });
  }

  addNewPizza(): void {
    let selectedToppingsString = '';
    let selectedToppingsNames = [];
    for (const t of this.selectedToppings) {
      selectedToppingsNames.push(t.toppingName);
    }
    selectedToppingsString = selectedToppingsNames.join(', ');
    this.pizzasService
      .addNewPizza(this.newPizzaName, selectedToppingsString)
      .subscribe({
        next: (results) => {
          this.closeModal(true);
          console.log(results);
        },
        error: (err) => console.log(err),
      });
  }

  closeModal(pizzaAdded: boolean): void {
    if (pizzaAdded) { 
      this.repullPizzas.emit(true);
    };
    this.outModalState.emit(0);
    this.outModalVisible.emit(false);
  }
}
