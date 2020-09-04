import { Component } from '@angular/core';
import{ HttpService } from '../Services/http-service.service';
import { WeatherForecast } from '../dtos/WeatherForecast';
import { Airport } from '../dtos/Airport';


@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

  public airports: Airport[];
  public selected_airport: Airport;
  private httpClient:HttpService

  constructor(_httpClient: HttpService) {
    this.httpClient = _httpClient;
    this.searchPlanes("heliport");
  }

  searchPlanes( search_string:string ){
    this.httpClient.searchPlanes(search_string).subscribe(res => this.airports = res);
  }

  getSingleAirport(airport_id:number){
    this.httpClient.getFullAirport(airport_id).subscribe(res => this.selected_airport = res);
  }
}
