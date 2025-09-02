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
  shoLiService = inject(ShoppingListsService);
  
  shoppingLists: ShoppingList[] = [];
  products: Product[] = [];
  selShoLi = signal<ShoppingList>(new ShoppingList('New Shopping List', new Date(), [], [], 0, 0, 0));

  constructor() { }

  ngOnInit() {
    this.shoLiService.getShoppingLists().subscribe({
      next: response => this.shoppingLists = response,
      error: err => console.log(err),
      complete: () => console.log("Shopping lists loaded!")
    })
  }

  SetSelShoLi(selShoLi: ShoppingList) {
    const newList = new ShoppingList(
      selShoLi.definition,
      selShoLi.modifiedDate,
      [...selShoLi.groceries],         
      [...selShoLi.householdItems],      
      selShoLi.groceryNumber,
      selShoLi.householdItemNumber,
      selShoLi.totalCost
    );
    this.selShoLi.set(newList);
    console.log('Selected Shopping List:', selShoLi);
  }

  // SetSelShoLi(selShoLi: ShoppingList) {
  //   this.selShoLi.set(new ShoppingList(
  //     selShoLi.definition,
  //     selShoLi.modifiedDate,
  //     selShoLi.groceries,
  //     selShoLi.householdItems,
  //     selShoLi.groceryNumber,
  //     selShoLi.householdItemNumber,
  //     selShoLi.totalCost
  //   ));
  //   console.log('Selected Shopping List:', selShoLi);
  // }


}
