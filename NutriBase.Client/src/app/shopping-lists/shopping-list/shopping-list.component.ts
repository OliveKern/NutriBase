import { DatePipe } from '@angular/common';
import { Component, input, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { ShoppingList } from 'src/app/_shared/models/app/plan.model';
import { Grocery } from 'src/app/_shared/models/base/product.model';
import { ListComponent } from "../../_shared/components/list/list.component";
import { NutritionForm } from 'src/app/_shared/enums/nutritionForm.enum';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.scss'],
  standalone: true,
  imports: [IonicModule, FormsModule, DatePipe, ListComponent]
})
export class ShoppingListComponent  implements OnInit {
  shoppingList = input<ShoppingList>(new ShoppingList('New Shopping List', new Date(), [], [], 0, 0, 0, new Date(), ''));
  newGrocery: Grocery | any;
  testArray: Grocery[] = [{
    definition: 'test 1', price: 50, kaloriesPer100g: 15,
    proteinPer100g: 0,
    sugarPer100g: 0,
    nutritionForm: NutritionForm.Vegetarian,
    description: '',
    packageSize: '',
    recipes: [],
    shoppingLists: []
  },
  {
    definition: 'test 2', price: 50, kaloriesPer100g: 15,
    proteinPer100g: 0,
    sugarPer100g: 0,
    nutritionForm: NutritionForm.Vegetarian,
    description: '',
    packageSize: '',
    recipes: [],
    shoppingLists: []
  }];
  
  constructor() { }

  addGrocery() {
    this.shoppingList().groceries.push(this.newGrocery);
    this.newGrocery = ''; 
  }

  deleteGrocery(grocery: Grocery) {
    throw new Error('Method not implemented.');
  }

  ngOnInit() {}

}
