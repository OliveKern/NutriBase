import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@Component({
    selector: 'app-nav',
    imports: [FormsModule, BsDropdownModule],
    templateUrl: './nav.component.html',
    styleUrl: './nav.component.css'
})
export class NavComponent {

  onLogout() {
    throw new Error('Method not implemented.');
  }

}
