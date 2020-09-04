import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AirportTrackerComponent } from './airport-tracker.component';

describe('AirportTrackerComponent', () => {
  let component: AirportTrackerComponent;
  let fixture: ComponentFixture<AirportTrackerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AirportTrackerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AirportTrackerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
