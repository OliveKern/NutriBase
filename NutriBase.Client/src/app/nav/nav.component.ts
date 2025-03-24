import { Component, OnInit } from '@angular/core';
import { IonicModule } from '@ionic/angular';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs';
import { InputModalComponent } from "../_shared/components/input-modal/input-modal.component";

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
  standalone: true,
  imports: [IonicModule, InputModalComponent],
})
export class NavComponent implements OnInit {
  currentPageTitle = 'Home';

  constructor(private router: Router) {}

  ngOnInit() {
    this.TrackRoute();
  }

  private TrackRoute() {
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe((event: any) => {
      this.updateNavbar(event.urlAfterRedirects);
    });
  }

  updateNavbar(route: string) {
    switch (route) {
      case '/recipes':
        this.currentPageTitle = 'Recipes';
        break;
      case '/shopping-lists':
        this.currentPageTitle = 'Shopping lists';
        break;
      case '/products':
        this.currentPageTitle = 'Products';
        break;
      default:
        this.currentPageTitle = 'Home';
    }
  }
}
