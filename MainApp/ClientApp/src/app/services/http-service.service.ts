import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WeatherForecast } from '../dtos/WeatherForecast';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  http:HttpClient;
  baseUrl:string;

  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.http = _http;
    this.baseUrl = _baseUrl;
  }

  getWeather(weather:WeatherForecast[]):Observable<WeatherForecast[]>{
    return this.http.get<WeatherForecast[]>(this.baseUrl + 'weatherforecast');
  }
}
