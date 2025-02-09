import { Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { ShoppingListsComponent } from "./shopping-lists/shopping-lists.component";
import { RecipesComponent } from "./recipes/recipes.component";

export const routes: Routes = [
  { path: '', redirectTo: 'Home', pathMatch: 'full' },
  { path: 'Home', component: HomeComponent },
  { path: 'Shopping', component: ShoppingListsComponent },
  { path: 'Recipes', component: RecipesComponent },
]

