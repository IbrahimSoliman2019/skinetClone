import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NotFonundComponent } from './not-fonund.component';

describe('NotFonundComponent', () => {
  let component: NotFonundComponent;
  let fixture: ComponentFixture<NotFonundComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NotFonundComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NotFonundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
