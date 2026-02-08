import { Component, inject, signal, OnInit } from '@angular/core';
import { IonicModule } from '@ionic/angular';
import { ShoppingListComponent } from "./shopping-list/shopping-list.component";
import { ShoppingListsTableComponent } from "./shopping-lists-table/shopping-lists-table.component";
import { ShoppingListsService } from '../_services/app/shopping-lists.service';
import { ShoppingList } from '../_shared/models/app/plan.model';
import { Product } from '../_shared/models/base/product.model';
import { ToolCardComponent } from "../_shared/components/tool-card/tool-card.component";

@Component({
  selector: 'app-shopping-lists',
  templateUrl: './shopping-lists.page.html',
  styleUrls: ['./shopping-lists.page.scss'],
  standalone: true,
  imports: [IonicModule, ShoppingListComponent, ShoppingListsTableComponent, ToolCardComponent, ToolCardComponent]
})
export class ShoppingListsPage implements OnInit {
  name = 'shopping-lists';
  shoLiService = inject(ShoppingListsService);
  
  shoppingLists: ShoppingList[] = [];
  products: Product[] = [];
  selShoLi = signal<ShoppingList>(this.returnDefaultShoppingList());

  constructor() { }

  ngOnInit() {
    this.loadShoppingLists();
  }

  SetSelShoLi(selShoLi: ShoppingList) {
    const newList = selShoLi;
    this.selShoLi.set(newList);
    console.log('Selected Shopping List:', selShoLi);
  }

  loadShoppingLists() {
        this.shoLiService.getShoppingLists().subscribe({
      next: response => this.shoppingLists = response,
      error: err => console.log(err),
      complete: () => console.log("Shopping lists loaded!")
    })
  }

  onSave() {
    console.log('Save action triggered');
    this.shoLiService.postShoppingList(this.selShoLi()).subscribe({
      next: response => console.log('Shopping list saved:', response),
      error: err => console.error('Error saving shopping list:', err),
      complete: () => console.log('Save operation completed.')
    });
    this.loadShoppingLists(); // Aktualisiere die Liste nach dem Speichern
  }

  onDelete() {
    console.log('Delete action triggered');
    this.selShoLi.set(this.returnDefaultShoppingList()); // Zurücksetzen
  }

  returnDefaultShoppingList(): ShoppingList {
    return new ShoppingList('New Shopping List', new Date(), 0); 
  }
}
