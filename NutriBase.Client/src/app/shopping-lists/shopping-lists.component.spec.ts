import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingListsComponent } from './shopping-lists.component';

describe('ShoppingListsComponent', () => {
  let component: ShoppingListsComponent;
  let fixture: ComponentFixture<ShoppingListsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShoppingListsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoppingListsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
