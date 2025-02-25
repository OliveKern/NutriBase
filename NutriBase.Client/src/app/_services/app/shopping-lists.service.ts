import { inject, Injectable } from '@angular/core';
import { environment } from '../../_environments/environments';
import { HttpClient } from '@angular/common/http';
import { ShoppingList } from '../../_shared/models/app/plan.model';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShoppingListsService {
  url: string = environment.ApiPaths.restApiPath + '/shoppinglists';
  private http = inject(HttpClient);

  constructor() { }

  getShoppingLists() {
    return this.http.get<ShoppingList[]>(`${this.url}/GetShoppingLists`)
                    .pipe(map(responseData => {
                      const shoppingListsArray: ShoppingList[] = [];
                      console.log(responseData);
                      responseData.forEach(element => {
                        shoppingListsArray.push(element);
                      });
                      return shoppingListsArray;
                    }));
  }

  postShoppingList(shoppingList: ShoppingList) {
    return this.http.post(`${this.url}/PostShoppingList`, shoppingList);
  }
}
