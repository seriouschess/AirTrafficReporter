import { WeatherForecast } from "./WeatherForecast";
import { Runway } from "./Runway";

export interface Airport {
    airportId: number;
    airportName: string;
    latitude: string;
    longitude: string;
    runways: Runway[];
    weatherForecast: WeatherForecast[];
  }