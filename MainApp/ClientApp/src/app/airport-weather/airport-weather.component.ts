import { Component, OnInit, Input} from '@angular/core';
import { WeatherReport } from '../dtos/WeatherReport';

@Component({
  selector: 'app-airport-weather',
  templateUrl: './airport-weather.component.html',
  styleUrls: ['./airport-weather.component.css']
})
export class AirportWeatherComponent implements OnInit {

  @Input() weather_reports:WeatherReport[];
  weather_report_index:number;
  display_flight_arrow:boolean;
  current_report:WeatherReport;
  constructor() { }

  ngOnInit() {
    this.weather_report_index = 0;
    this.current_report = this.weather_reports[this.weather_report_index];
    this.checkCompassDisplay();
  }

  incrementReportIndex(){
    this.weather_report_index += 1
    if(this.weather_report_index >= this.weather_reports.length){
      this.weather_report_index = 0;
    }
    this.current_report = this.weather_reports[this.weather_report_index];
  }

  decrementReportIndex(){
    this.weather_report_index -= 1;
    if(this.weather_report_index < 0){
      this.weather_report_index = this.weather_reports.length - 1;
    }
    this.current_report = this.weather_reports[this.weather_report_index];
  }

  checkCompassDisplay(){
    var check_me:string = this.weather_reports[this.weather_report_index].airplaneTakeoffDescription;
    if( check_me == null  || 
      check_me == "Planes do not take off from this airport." ||
      check_me == "Insufficient runway information to calculate takeoff direction."){
      this.display_flight_arrow = false;
    }else{
      this.display_flight_arrow = true;
    }
  }
}




