import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../_environments/environments';
import { User } from '../../_shared/models/account/user.model';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AcccountService {
  url: string = environment.ApiPaths.restApiPath + '/users';
  private http = inject(HttpClient);
  currentUser = signal<User | null>(null);

  constructor() { }

  getUsers() {
    return this.http.get<User[]>(`${this.url}/GetUsers`)
                    .pipe(map(responseData => {
                      const usersArray: User[] = [];
                      console.log(responseData)
                      responseData.forEach(element => {
                        usersArray.push(element);
                      });
                      return usersArray;
                    }));               
  }

  getUser(id: number) {
    return this.http.get<User>(`${this.url}/GetUser/${id}`);
  }

  register(user: User) {
    return this.http.post(`${this.url}/Register`, user);
  }

  login(user: User) {
    return this.http.post(`${this.url}/Login`, user);
  }
}
