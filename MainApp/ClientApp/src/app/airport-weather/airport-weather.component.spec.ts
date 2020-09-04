import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AirportWeatherComponent } from './airport-weather.component';

describe('AirportWeatherComponent', () => {
  let component: AirportWeatherComponent;
  let fixture: ComponentFixture<AirportWeatherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AirportWeatherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AirportWeatherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
