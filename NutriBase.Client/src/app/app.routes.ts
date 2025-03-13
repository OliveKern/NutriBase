import { Routes } from "@angular/router";
// import { HomePage } from "./home/home.page";
// import { ShoppingListsPage } from "./shopping-lists/shopping-lists.page";
// import { RecipesPage } from "./recipes/recipes.page";
// import { ProductsPage } from "./products/products.page";

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },  {
    path: 'home',
    loadComponent: () => import('./home/home.page').then( m => m.HomePage)
  },
  {
    path: 'register',
    loadComponent: () => import('./register/register.page').then( m => m.RegisterPage)
  },
  {
    path: 'recipes',
    loadComponent: () => import('./recipes/recipes.page').then( m => m.RecipesPage)
  },
  {
    path: 'shopping-lists',
    loadComponent: () => import('./shopping-lists/shopping-lists.page').then( m => m.ShoppingListsPage)
  },
  {
    path: 'products',
    loadComponent: () => import('./products/products.page').then( m => m.ProductsPage)
  },

  // { path: 'home', component: HomePage },
  // { path: 'shopping', component: ShoppingListsPage },
  // { path: 'recipes', component: RecipesPage },
  // { path: 'products', component: ProductsPage },
]

