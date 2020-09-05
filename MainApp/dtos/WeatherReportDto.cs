using System;

namespace MainApp.dtos
{
    public class WeatherReportDto
    {
        public string Temperature {get;set;}
        public string Description {get;set;}
        public int WindDirectionDeg {get;set;} //360 is north
        public double WindSpeed {get;set;}
        public string PredictionDateString {get;set;}
        public int AirplaneTakeoffAngle {get;set;}
        public string AirplaneTakeoffDescription {get;set;}
    }
}