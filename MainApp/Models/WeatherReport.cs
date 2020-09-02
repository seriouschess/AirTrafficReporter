using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainApp.Models
{
    public class WeatherReport
    {
        public int WeatherReportId {get;set;}
        public string Temperature {get;set;}
        public string Description {get;set;}
        public int WindDirectionDeg {get;set;} //360 is north
        public double WindSpeed {get;set;}
        public DateTime PredictionDatetime {get;set;}
        public int WeatherForecastId {get;set;}
        [ForeignKey("WeatherForecastId")]
        public WeatherForecast WeatherForecast {get;set;}
    }
}
