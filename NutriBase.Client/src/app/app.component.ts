import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { IonicModule } from '@ionic/angular';

// import { IonIcon } from '@ionic/angular/standalone';
// import { addIcons } from 'ionicons';
// import { logoIonic } from 'ionicons/icons';



@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
  standalone: true,
  imports: [ IonicModule, RouterModule ]
})
export class AppComponent implements OnInit {
  public appPages = [
    { title: 'Home', url: '/home', icon: 'home' },
    { title: 'Register', url: '/register', icon: 'register' },
    { title: 'Recipes', url: '/recipes', icon: 'recipe' },
    { title: 'Shopping lists', url: '/shopping-lists', icon: 'shopping-lists' },
    { title: 'Products', url: '/products', icon: 'products' },
  ];
  public labels = ['Family', 'Friends', 'Notes', 'Work', 'Travel', 'Reminders'];
  
  constructor() {
    // addIcons({logoIonic});
  }

  ngOnInit() {
  }
}
