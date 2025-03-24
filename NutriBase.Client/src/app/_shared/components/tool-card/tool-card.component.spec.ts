import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ToolCardComponent } from './tool-card.component';

describe('ToolCardComponent', () => {
  let component: ToolCardComponent;
  let fixture: ComponentFixture<ToolCardComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      imports: [ToolCardComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(ToolCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
