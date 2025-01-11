import { Component, EventEmitter, Input, Output } from '@angular/core';
import { sortBy as _sortBy } from 'lodash';
import { FormsModule } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';
import { MultiSelectModule } from 'primeng/multiselect';
import { Pizza } from '../../../shared/classes/pizza';
import { PizzasService } from '../../pizzas.service';
import { ToppingsService } from '../../../toppings/toppings.service';
import { Topping } from '../../../shared/classes/topping';

@Component({
  selector: 'app-edit-pizza',
  standalone: true,
  imports: [
    CardModule,
    FormsModule,
    ButtonModule,
    InputTextModule,
    MultiSelectModule,
    ToastModule,
  ],
  providers: [MessageService],
  templateUrl: './edit-pizza.component.html',
  styleUrl: './edit-pizza.component.css',
})
export class EditPizzaComponent {
  @Input() inPizzas: Pizza[] = [];
  @Input() inPizzaDetail = new Pizza();
  @Output() outModalState = new EventEmitter<number>();
  @Output() outModalVisible = new EventEmitter<boolean>();
  @Output() repullPizzas = new EventEmitter<boolean>();

  pizzaName: string = '';
  availableToppings: Topping[] = [];
  selectedToppings: Topping[] = [];

  constructor(
    private pizzasService: PizzasService,
    private toppingsService: ToppingsService,
    private messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.toppingsService.getToppings().subscribe({
      next: (results) => {
        console.log(results);
        this.availableToppings = results;
        this.availableToppings = _sortBy(this.availableToppings, [
          'toppingName',
        ]);
        this.selectedToppings = [];
        let prevSelectToppings = [];
        prevSelectToppings = this.inPizzaDetail.toppings.split(', ');
        for (const p of prevSelectToppings) {
          let selectedTopping = this.availableToppings.filter(
            (x) => x.toppingName == p
          )[0];
          this.selectedToppings.push(selectedTopping);
        }
        this.pizzaName = this.inPizzaDetail.pizzaName;
      },
      error: (err) => console.log(err),
    });
  }

  updatePizza(): void {
    let selectedToppingsString = '';
    let selectedToppingsNames = [];
    this.selectedToppings = _sortBy(this.selectedToppings, ['toppingName']);
    for (const t of this.selectedToppings) {
      selectedToppingsNames.push(t.toppingName);
    }
    selectedToppingsString = selectedToppingsNames.join(', ');
    if (
      this.inPizzas.filter(
        (x) =>
          x.pizzaName.toLowerCase() == this.pizzaName.toLowerCase() ||
          x.toppings.toLowerCase() == selectedToppingsString.toLowerCase()
      ).length == 0
    ) {
      this.pizzasService
        .updatePizza(
          this.pizzaName,
          selectedToppingsString,
          this.inPizzaDetail.pizzaId
        )
        .subscribe({
          next: (results) => {
            this.closeModal(true);
          },
          error: (err) => console.log(err),
        });
    } else {
      this.messageService.add({
        severity: 'error',
        summary: 'Not Created',
        detail: 'Pizza Already Exists',
      });
    }
  }

  closeModal(pizzaAdded: boolean): void {
    if (pizzaAdded) {
      this.repullPizzas.emit(true);
    }
    this.outModalState.emit(0);
    this.outModalVisible.emit(false);
  }
}
