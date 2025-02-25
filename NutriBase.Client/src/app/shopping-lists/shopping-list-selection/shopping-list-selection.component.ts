import { Component, input, output } from '@angular/core';
import { ShoppingList } from '../../_shared/models/app/plan.model';

@Component({
  selector: 'app-shopping-list-selection',
  standalone: true,
  imports: [],
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
