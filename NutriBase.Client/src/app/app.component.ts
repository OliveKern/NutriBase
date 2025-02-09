import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from "./header/header.component";
import { ShoppingListsComponent } from './shopping-lists/shopping-lists.component';
import { RecipesComponent } from './recipes/recipes.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    NavComponent, HeaderComponent,
    HomeComponent, ShoppingListsComponent, RecipesComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'Nutrition Base';
  http = inject(HttpClient);
  users: any;

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: response => this.users = response,
      error: error => console.log(error),
      complete: () => console.log('Request completed')
    })
  }
}
