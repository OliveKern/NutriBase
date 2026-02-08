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
  deleteClick = output<void>();

  page = input<string>();
  isNew: boolean = true;

  defaultButtons: {type: string, color: string, click?: (() => void), routerLink?: string}[] = [
    { type: 'Save', color: 'success' , click: () => this.safeChanges()},
    { type: 'Delete', color: 'danger', click: () => this.deleteChanges() },
  ]
  buttons = computed(() => {
    if (!this.isNew) {
      this.defaultButtons.push(
        { type: 'Save as new', color: 'success', click: () => this.safeChanges(true) }
      )
    };

    switch (true) {
      case this.page()!.includes("shopping-lists"):

        this.defaultButtons.push(
          { type: 'Manage Products', color: 'primary', routerLink: '/products' },
        );

        return this.defaultButtons;

      case this.page()!.includes('recipe'):

        this.defaultButtons.push(
          { type: 'Go to Website', color: 'primary', routerLink: ''}
        );

        return this.defaultButtons;

      default:
        return this.defaultButtons;
    }
  });

  constructor() { }

  ngOnInit() {
    this.isNew = Number(this.page()!.at(-1)) == 0;
}

  safeChanges(asNew: boolean = false) {
    console.log('Safe changes clicked');
    this.safe.emit();
  }

  deleteChanges() {
    console.log('Delete changes clicked');
    this.deleteClick.emit();
  }
}
