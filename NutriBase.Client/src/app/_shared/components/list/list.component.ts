import { Component, input, OnInit, output } from '@angular/core';
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
  inputArray = input<any[]>([]);
  item = output<any>();


  constructor() { }

  ngOnInit() {}

  deleteItem(item: any) {
    console.log(item);
    this.item.emit(item);
  }

  logitemstring() {   //test
    console.log(this.inputArray());
    this.inputArray()!.forEach(element => {
      console.log(element.description);
    });
  }
}
