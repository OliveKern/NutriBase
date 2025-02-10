import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingListToolsComponent } from './shopping-list-tools.component';

describe('ShoppingListToolsComponent', () => {
  let component: ShoppingListToolsComponent;
  let fixture: ComponentFixture<ShoppingListToolsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ShoppingListToolsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoppingListToolsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
