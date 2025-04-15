import { DatePipe } from '@angular/common';
import { Component, input, OnInit, output } from '@angular/core';
import { IonicModule } from '@ionic/angular';
import { ShoppingList } from 'src/app/_shared/models/app/plan.model';

@Component({
  selector: 'app-shopping-lists-table',
  templateUrl: './shopping-lists-table.component.html',
  styleUrls: ['./shopping-lists-table.component.scss'],
  standalone: true,
  imports: [IonicModule, DatePipe]
})
export class ShoppingListsTableComponent  implements OnInit {
  shoppingLists = input<ShoppingList[]>();
  selShoLi = output<ShoppingList>();
  
  constructor() { }

  ngOnInit() {}

  selectShoppingList(shoLi: ShoppingList) {
    this.selShoLi.emit(shoLi);
    console.log('Selected Shopping List:', shoLi);
  }

  deleteShoppingList() {
    throw new Error('Method not implemented.');
  }

}
