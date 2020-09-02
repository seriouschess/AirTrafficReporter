using System;
using System.Collections.Generic;
using MainApp.Models;

namespace MainApp
{
    public class WeatherForecast
    {
        public string Temperature {get;set;}
        public string Description {get;set;}
        public int WindDirectionDeg {get;set;} //360 is north
        public double WindSpeed {get;set;}

        public DateTime DateTime {get;set;}


    }
}
