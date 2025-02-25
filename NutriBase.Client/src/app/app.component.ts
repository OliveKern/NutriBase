import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { NavComponent } from './nav/nav.component';
import { HeaderComponent } from "./header/header.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet, RouterModule,
    NavComponent, HeaderComponent,
    ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'Nutrition Base';
  http = inject(HttpClient);

  ngOnInit(): void {}
}
