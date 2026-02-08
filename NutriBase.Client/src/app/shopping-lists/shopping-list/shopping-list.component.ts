import { DatePipe } from '@angular/common';
import { Component, effect, input, OnInit, WritableSignal } from '@angular/core';
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
  readonly shoppingList = input.required<ShoppingList>();
  //readonly groceries = input.required<WritableSignal<Grocery[]>>();

  newGrocery: Grocery = new Grocery(
    '', // definition
    '', // description
    0,  // price
    '', // packageSize
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
  },
  {
    definition: 'test 2', price: 50, kaloriesPer100g: 15,
    proteinPer100g: 0,
    sugarPer100g: 0,
    nutritionForm: NutritionForm.Vegetarian,
    description: '',
    packageSize: '',
  }];

  get currentList() : ShoppingList {
    return this.shoppingList();
  }

  get currentListGroceries(): Grocery[] {
    const list = this.shoppingList();
    return list.groceries ?? [];
  }

  addGrocery() {      
    const grocery = new Grocery(
      this.newGrocery.definition,
      this.newGrocery.description,
      this.newGrocery.price,
      this.newGrocery.packageSize,
      this.newGrocery.kaloriesPer100g,
      this.newGrocery.proteinPer100g,
      this.newGrocery.sugarPer100g,
      this.newGrocery.nutritionForm
    );

    const list = this.shoppingList();

    if (list) {
      list.groceries.push(grocery);
    }

    this.newGrocery = this.ResetGrocery(this.newGrocery);

    //const sig = this.groceries?.();
    //if (sig) {
    //  sig.update(arr => [...arr, grocery]);
    //}

    //this.groceries()?.().push(grocery);
    //this.newGrocery = this.ResetNewGrocery(this.newGrocery);
  }

  deleteGrocery(item: Grocery | HouseholdItem) {
    const list = this.currentList;
    console.log(list);
  //  list.removeProduct(item);
  }

  ResetGrocery(grocery: Grocery) : Grocery {
    return grocery = {
      definition: '', 
      price: 0, 
      kaloriesPer100g: 0,
      proteinPer100g: 0,
      sugarPer100g: 0,
      nutritionForm: NutritionForm.NotSpecified,
      description: '',
      packageSize: '',
    };
  }

  ngOnInit() {}
}

