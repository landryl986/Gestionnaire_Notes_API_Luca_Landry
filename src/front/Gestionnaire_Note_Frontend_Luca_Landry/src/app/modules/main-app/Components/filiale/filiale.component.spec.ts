import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilialeComponent } from './filiale.component';

describe('FilialeComponent', () => {
  let component: FilialeComponent;
  let fixture: ComponentFixture<FilialeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FilialeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FilialeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
