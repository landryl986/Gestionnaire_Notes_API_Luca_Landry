import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilialCardsComponent } from './filial-cards.component';

describe('FilialCardsComponent', () => {
  let component: FilialCardsComponent;
  let fixture: ComponentFixture<FilialCardsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FilialCardsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FilialCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
