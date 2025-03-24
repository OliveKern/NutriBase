import { Component, computed, input, OnInit } from '@angular/core';
import { IonicModule } from '@ionic/angular';

@Component({
  selector: 'app-tool-card',
  templateUrl: './tool-card.component.html',
  styleUrls: ['./tool-card.component.scss'],
  standalone: true,
  imports: [IonicModule]
})
export class ToolCardComponent  implements OnInit {
  page = input<string>("shopping-list");
  buttons = computed(() => {
    switch (this.page()) {
      case 'shopping-list':
        return [
          { type: 'Save', color: 'success' },
          { type: 'Delete', color: 'danger' }
        ];
      case 'recipe':
        return [
          { type: 'Add Ingredient', color: 'primary' },
          { type: 'Remove Ingredient', color: 'warning' }
        ];
      default:
        return [{ type: 'Default Action', color: 'secondary' }];
    }
  });

  constructor() { }

  ngOnInit() {}
}
