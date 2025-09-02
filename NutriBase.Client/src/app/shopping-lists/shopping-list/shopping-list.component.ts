import { DatePipe } from '@angular/common';
import { Component, input, OnInit, WritableSignal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { Plan, ShoppingList } from 'src/app/_shared/models/app/plan.model';
import { Grocery, HouseholdItem } from 'src/app/_shared/models/base/product.model';
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
  // shoppingList = input<WritableSignal<ShoppingList>>(new ShoppingList('New Shopping List', new Date(), [], [], 0, 0, 0));
  readonly shoppingList = input.required<WritableSignal<ShoppingList>>();

  newGrocery: Grocery = new Grocery(
    '', // definition
    '', // description
    0,  // price
    '', // packageSize
    [], // recipes
    [], // shoppingLists
    0,  // kaloriesPer100g
    0,  // proteinPer100g
    0,  // sugarPer100g
    NutritionForm.NotSpecified // nutritionForm
  );
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

  get currentList(): ShoppingList {
    return this.shoppingList()?.();
  }
  
  constructor() { }

  addGrocery() {  
    const list = this.currentList;
    
    const grocery = new Grocery(
      this.newGrocery.definition,
      this.newGrocery.description,
      this.newGrocery.price,
      this.newGrocery.packageSize,
      this.newGrocery.recipes,
      this.newGrocery.shoppingLists,
      this.newGrocery.kaloriesPer100g,
      this.newGrocery.proteinPer100g,
      this.newGrocery.sugarPer100g,
      this.newGrocery.nutritionForm
    );

    grocery.shoppingLists.push(list);
    list.addProduct(grocery);
    console.log(list);
    this.newGrocery = this.ResetNewGrocery(this.newGrocery);
  }

  deleteGrocery(item: Grocery | HouseholdItem) {
    const list = this.currentList;
    console.log(list);
    list.removeProduct(item);
  }


  // addGrocery() {  
  //   const grocery = new Grocery(
  //     this.newGrocery.definition,
  //     this.newGrocery.description,
  //     this.newGrocery.price,
  //     this.newGrocery.packageSize,
  //     this.newGrocery.recipes,
  //     this.newGrocery.shoppingLists,
  //     this.newGrocery.kaloriesPer100g,
  //     this.newGrocery.proteinPer100g,
  //     this.newGrocery.sugarPer100g,
  //     this.newGrocery.nutritionForm
  //   );
  //   grocery.shoppingLists.push(this.shoppingList()!);
  //   this.shoppingList()!.addProduct(grocery);
  //   console.log(this.shoppingList());
  //   this.newGrocery = this.ResetNewGrocery(this.newGrocery);
  // }

  // deleteGrocery(item: Grocery | HouseholdItem) {
  //   console.log(item);
  //   this.shoppingList()!.removeProduct(item);
  // }

  ResetNewGrocery(grocery: Grocery) : Grocery {
    return grocery = {
      definition: '', 
      price: 0, 
      kaloriesPer100g: 0,
      proteinPer100g: 0,
      sugarPer100g: 0,
      nutritionForm: NutritionForm.NotSpecified,
      description: '',
      packageSize: '',
      recipes: [],
      shoppingLists: []
    };
  }

  ngOnInit() {}
}

