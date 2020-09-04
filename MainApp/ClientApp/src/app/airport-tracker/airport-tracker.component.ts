import { Component, OnInit } from '@angular/core';
import { WeatherForecast } from '../dtos/WeatherForecast';
import { Airport } from '../dtos/Airport';
import { HttpService } from '../services/http-service.service';

@Component({
  selector: 'app-airport-tracker',
  templateUrl: './airport-tracker.component.html',
  styleUrls: ['./airport-tracker.component.css']
})
export class AirportTrackerComponent implements OnInit {
  public forecasts: WeatherForecast[];

  public airports: Airport[];
  public selected_airport: Airport;
  public airport_selected: boolean;
  public search_string: string;
  private httpClient: HttpService

  constructor(_httpClient: HttpService) {
    this.httpClient = _httpClient;
  }

  ngOnInit(): void {
    this.resetSearch();
  }

  resetSearch(){
    this.airport_selected = false;
    this.airports = null;
    this.search_string = "";
  }

  searchPlanes(){
    this.airport_selected = false;
    console.log(this.search_string);
    this.httpClient.searchPlanes(this.search_string).subscribe(res => this.airports = res);
  }

  getSingleAirport(airport_id:number){
    this.airport_selected = true;
    this.httpClient.getFullAirport(airport_id).subscribe(res => this.selected_airport = res);
  }

}
