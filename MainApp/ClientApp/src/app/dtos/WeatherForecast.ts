import { WeatherReport } from "./WeatherReport";

export interface WeatherForecast {
    weatherForecastId: number;
    weatherReports: WeatherReport[];
    UpdatedAt: string;
  }