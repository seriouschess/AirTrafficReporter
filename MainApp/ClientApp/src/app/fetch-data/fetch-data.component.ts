import { Component} from '@angular/core';
import{ HttpService } from '../Services/http-service.service';


@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

  constructor(_httpClient: HttpService) {
    _httpClient.getWeather(this.forecasts).subscribe(res => this.forecasts = res);
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
