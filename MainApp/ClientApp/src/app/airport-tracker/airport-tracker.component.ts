import { Component, OnInit } from '@angular/core';
import { WeatherForecast } from '../dtos/WeatherForecast';
import { Airport } from '../dtos/Airport';
import { HttpService } from '../services/http-service.service';
import { Runway } from '../dtos/Runway';

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
  public input_validation_error:boolean;
  public search_string: string;
  private httpClient: HttpService;
  public runway_information:Array<string>;
  constructor(_httpClient: HttpService) {
    this.httpClient = _httpClient;
  }

  ngOnInit(): void {
    this.runway_information = [];
    this.resetSearch();
  }

  resetSearch(){
    this.input_validation_error = false;
    this.airport_selected = false;
    this.airports = null;
    this.search_string = "";
  }

  searchPlanes(){
    this.input_validation_error = false;
    this.airport_selected = false;
    if(this.search_string.length >= 3 && this.search_string.length <= 25){
      this.httpClient.searchPlanes(this.search_string).subscribe(res => this.airports = res);
    }else{
      this.input_validation_error = true;
    }
  }

  getSingleAirport( airport_id: number ){
    this.httpClient.getFullAirport(airport_id).subscribe(res =>{
      this.selected_airport = res;
      this.parseRunwayInformation();
      this.airport_selected = true;
    });
  }

  parseRunwayInformation(){
    var runways: Runway[] = this.selected_airport.runways;
    this.runway_information = [];
    for(var x=0; x<runways.length; x++){
      if( this.runway_information.includes( runways[x].runwayDescription ) ){
        //do nothing
      }else{
        this.runway_information.push(runways[x].runwayDescription);
      }
    }
  }

}
