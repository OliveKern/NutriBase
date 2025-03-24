import { Component, input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { InputDto, RegisterDto } from '../../models/account/user.model';
import { IonModal } from '@ionic/angular/common';

@Component({
  selector: 'app-input-modal',
  templateUrl: './input-modal.component.html',
  styleUrls: ['./input-modal.component.scss'],
  standalone: true,
  imports: [IonicModule, ReactiveFormsModule]
})
export class InputModalComponent  implements OnInit {
  @ViewChild(IonModal) modal!: IonModal;
  formMode = input.required<string>();
  form: FormGroup;

  constructor(private formBuilder: FormBuilder) { 
    this.form = formBuilder.group({});
  }

  ngOnInit() {
    this.DefineAndCreateForm();
  }

  // cancel() {
  //   this.modal.dismiss(null, 'cancel');
  // }

  // confirm() {
  //   this.modal.dismiss(null, 'confirm');
  // }

  DefineAndCreateForm() {
    if(this.formMode() === 'login')
      this.GenerateForm(InputDto)
    else if(this.formMode() === 'signup')
      this.GenerateForm(RegisterDto)
  }

  GenerateForm(inpClass: any){
    const instance = new inpClass();
    console.log('Instance of inpClass:', instance);
    const properties = Object.keys(instance);
    console.log('Generated properties:', properties);

    properties.forEach(prop => {
      this.form.addControl(prop, this.formBuilder.control(''));
    }) 
    console.log('Generated form:', this.form); 
  }

  GetButtonColor() : string {
    switch(this.formMode()) {
      case 'login':
        return 'success';
      case 'signup':
        return 'primary';
      default:
        return '';
    }
  }

  get formControlKeys(): string[] {
    return Object.keys(this.form.controls);
  }
}


