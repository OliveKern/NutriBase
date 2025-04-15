import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { map } from 'rxjs';
import { ShoppingList } from 'src/app/_shared/models/app/plan.model';
import { environment } from 'src/environments/environment';

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
                      const shoppingListArray: ShoppingList[] = [];
                      console.log(responseData);
                      responseData.forEach(element => {
                        shoppingListArray.push(element);
                      });
                      return shoppingListArray;
                    }));
  }

  postShoppingList(shoppingList: ShoppingList) {
    return this.http.post(`$(this.url)/PostShoppingList`, shoppingList);
  }
}
