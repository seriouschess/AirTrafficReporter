using System;

namespace MainApp.dtos
{
    public class WeatherReportDto
    {
        public string Temperature {get;set;}
        public string Description {get;set;}
        public int WindDirectionDeg {get;set;} //360 is north
        public double WindSpeed {get;set;}
        public DateTime PredictionDatetime {get;set;}
    }
}