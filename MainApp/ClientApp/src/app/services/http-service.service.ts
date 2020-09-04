import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Airport } from '../dtos/Airport';

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

  searchPlanes(search_string:string):Observable<Airport[]>{
    return this.http.get<Airport[]>(this.baseUrl + `airport/search/${search_string}`);
  }

  getFullAirport(airport_id:number):Observable<Airport>{
    return this.http.get<Airport>(this.baseUrl + `airport/full/${airport_id}`);
  }
}
