import { Component, input, OnInit } from '@angular/core';
import { IonicModule } from '@ionic/angular';
import { BaseInterface } from '../../interfaces/baseInterface';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
  standalone: true,
  imports: [IonicModule]
})
export class ListComponent  implements OnInit {
  inputArray = input<any[]>();

  constructor() { }

  ngOnInit() {}

}
