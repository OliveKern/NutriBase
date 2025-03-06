import { Component, input, output } from '@angular/core';
import { ShoppingList } from '../../_shared/models/app/plan.model';
import { DatePipe } from '@angular/common';

@Component({
    selector: 'app-shopping-list-selection',
    imports: [DatePipe],
    templateUrl: './shopping-list-selection.component.html',
    styleUrl: './shopping-list-selection.component.css'
})
export class ShoppingListSelectionComponent {
  shoppingLists = input<ShoppingList[]>();
  selShopLi = output<ShoppingList>();

  selectShoppingList(shoLi: ShoppingList) {
    this.selShopLi.emit(shoLi);
  }

  deleteShoppingList() {
    throw new Error('Method not implemented.');
  }
}
