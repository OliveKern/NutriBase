import { Component } from '@angular/core';
import { ShoppingListComponent } from './shopping-list/shopping-list.component';
import { ShoppingListToolsComponent } from './shopping-list-tools/shopping-list-tools.component';
import { ShoppingListSelectionComponent } from './shopping-list-selection/shopping-list-selection.component';

@Component({
  selector: 'app-shopping-lists',
  standalone: true,
  imports: [ShoppingListComponent, ShoppingListToolsComponent, ShoppingListSelectionComponent],
  templateUrl: './shopping-lists.component.html',
  styleUrl: './shopping-lists.component.css'
})
export class ShoppingListsComponent {

}
