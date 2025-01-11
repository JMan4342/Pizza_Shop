import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ToppingsService } from '../../toppings.service';
import { MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';
import { Topping } from '../../../shared/classes/topping';

@Component({
  selector: 'app-edit-topping',
  standalone: true,
  imports: [
    CardModule,
    FormsModule,
    ButtonModule,
    InputTextModule,
    ToastModule,
  ],
  providers: [MessageService],
  templateUrl: './edit-topping.component.html',
  styleUrl: './edit-topping.component.css',
})
export class EditToppingComponent implements OnInit {
  @Input() inToppings: Topping[] = [];
  @Input() inToppingDetail: Topping = new Topping();
  @Output() outModalState = new EventEmitter<number>();
  @Output() outModalVisible = new EventEmitter<boolean>();
  @Output() repullToppings = new EventEmitter<boolean>();

  toppingName: string = '';

  constructor(
    private toppingsService: ToppingsService,
    private messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.toppingName = '';
    this.toppingName = this.inToppingDetail.toppingName;
  }

  updateTopping(): void {
    if (
      this.inToppings.filter(
        (x) => x.toppingName.toLowerCase() == this.toppingName.toLowerCase()
      ).length == 0
    ) {
      this.toppingsService
        .updateTopping(this.toppingName, this.inToppingDetail.toppingId)
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
        detail: 'Topping Already Exists',
      });
    }
  }

  closeModal(toppingUpdated: boolean): void {
    if (toppingUpdated) {
      this.repullToppings.emit(true);
    }
    this.outModalState.emit(0);
    this.outModalVisible.emit(false);
  }
}
