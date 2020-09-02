using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainApp.Models
{
    public class WeatherForecast
    {
        public int WeatherForecastId {get;set;}
        public int AirportId {get;set;}
        
        [ForeignKey("AirportId")]
        public Airport Airport {get;set;}
        public List<WeatherReport> WeatherReports {get;set;}
        public DateTime UpdatedAt {get;set;}
    }
}