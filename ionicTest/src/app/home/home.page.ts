import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
  standalone: false,
})
export class HomePage {
  text = 'Default starting text';

  constructor() {}

  onChangeText() {
    this.text = 'Text changed!';
  }
}
