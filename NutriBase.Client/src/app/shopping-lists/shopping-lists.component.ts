import { Component, inject, OnInit, signal } from '@angular/core';
import { ShoppingListComponent } from './shopping-list/shopping-list.component';
import { ShoppingListToolsComponent } from './shopping-list-tools/shopping-list-tools.component';
import { ShoppingListSelectionComponent } from './shopping-list-selection/shopping-list-selection.component';
import { ShoppingListsService } from '../_services/app/shopping-lists.service';
import { ShoppingList } from '../_shared/models/app/plan.model';

@Component({
  selector: 'app-shopping-lists',
  standalone: true,
  imports: [ShoppingListComponent, ShoppingListToolsComponent, ShoppingListSelectionComponent],
  templateUrl: './shopping-lists.component.html',
  styleUrl: './shopping-lists.component.css'
})
export class ShoppingListsComponent implements OnInit {
  sLService = inject(ShoppingListsService);
  shoppingLists: ShoppingList[] = [];
  selShopLi? = signal<ShoppingList | null>(null);

  ngOnInit() {
    this.sLService.getShoppingLists().subscribe({
      next: response => this.shoppingLists = response,
      error: err => console.log(err),
      complete: () => console.log('Shopping lists loaded')
    })
  }

  selectedShoppingListChanged(shoLi: ShoppingList) {
    throw new Error('Method not implemented.');
  }
}
