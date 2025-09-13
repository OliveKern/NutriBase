import { Component, computed, input, OnInit, output } from '@angular/core';
import { RouterModule } from '@angular/router';
import { IonicModule } from '@ionic/angular';

@Component({
  selector: 'app-tool-card',
  templateUrl: './tool-card.component.html',
  styleUrls: ['./tool-card.component.scss'],
  standalone: true,
  imports: [IonicModule, RouterModule]
})
export class ToolCardComponent  implements OnInit {
  safe = output<void>();
  delete = output<void>();

  page = input<string>("shopping-list");
  defaultButtons: {type: string, color: string, click?: (() => void), routerLink?: string}[] = [
    { type: 'Save', color: 'success' , click: () => this.safeChanges()},
    { type: 'Delete', color: 'danger', click: () => this.deleteChanges()},
  ]
  buttons = computed(() => {
    switch (this.page()) {
      case 'shopping-list':
        this.defaultButtons.push(
          { type: 'Manage Products', color: 'primary', routerLink: '/products' }
        );
        return this.defaultButtons;
      case 'recipe':
        this.defaultButtons.push(
          { type: 'Go to Website', color: 'primary', routerLink: ''}
        );
        return this.defaultButtons;
      default:
        return this.defaultButtons;
    }
  });

  constructor() { }

  ngOnInit() {}

  safeChanges() {
    console.log('Safe changes clicked');
    this.safe.emit();
  }

  deleteChanges() {
    console.log('Delete changes clicked');
    this.delete.emit();
  }
}
