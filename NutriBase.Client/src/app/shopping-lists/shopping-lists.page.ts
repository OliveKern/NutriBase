import { Component, inject, OnInit, signal } from '@angular/core';
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
  selShoLi? = signal<ShoppingList>(this.shoppingLists[0]);

  constructor() { }

  ngOnInit() {
    this.shoLiService.getShoppingLists().subscribe({
      next: response => this.shoppingLists = response,
      error: err => console.log(err),
      complete: () => console.log("Shopping lists loaded!")
    })
  }

}
