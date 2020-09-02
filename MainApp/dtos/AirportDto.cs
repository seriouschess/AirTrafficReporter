using System.Collections.Generic;
using MainApp.Models;

namespace MainApp.dtos
{
    public class AirportDto
    {
        public int AirportId {get;set;}
        public string AirportName {get;set;}
        public double Latitude {get;set;}
        public double Longitude {get;set;}
        public List<RunwayDto> Runways {get;set;}
        public List<WeatherForecastDto> WeatherForecast {get;set;}
    }
}