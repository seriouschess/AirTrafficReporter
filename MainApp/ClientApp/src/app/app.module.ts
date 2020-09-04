import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AirportTrackerComponent } from './airport-tracker/airport-tracker.component';
import { CompassComponent } from './compass/compass.component';
import { AirportWeatherComponent } from './airport-weather/airport-weather.component';

@NgModule({
  declarations: [
    AppComponent,
    AirportTrackerComponent,
    CompassComponent,
    AirportWeatherComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: AirportTrackerComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
