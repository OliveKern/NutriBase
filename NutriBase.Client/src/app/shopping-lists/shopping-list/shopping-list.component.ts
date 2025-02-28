import { Component, input } from '@angular/core';
import { ShoppingList } from '../../_shared/models/app/plan.model';
import { Grocery, HouseholdItem } from '../../_shared/models/base/product.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  standalone: true,
  imports: [DatePipe],
  styleUrl: './shopping-list.component.css'
})
export class ShoppingListComponent {
  shoppingList = input<ShoppingList>(new ShoppingList('Shopping List 1', new Date(), [], [], 0, 0, 0, new Date(), ''));
newGrocery: any;

  addGrocery() {
    this.shoppingList().groceries.push(this.newGrocery);
    this.newGrocery = ''; 
  }

  deleteGrocery(_t5: Grocery) {
    throw new Error('Method not implemented.');
  }
}
