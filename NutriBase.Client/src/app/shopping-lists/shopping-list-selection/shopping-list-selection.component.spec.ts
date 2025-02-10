import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingListSelectionComponent } from './shopping-list-selection.component';

describe('ShoppingListSelectionComponent', () => {
  let component: ShoppingListSelectionComponent;
  let fixture: ComponentFixture<ShoppingListSelectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ShoppingListSelectionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoppingListSelectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
