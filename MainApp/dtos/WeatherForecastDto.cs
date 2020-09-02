using System;
using System.Collections.Generic;
using MainApp.Models;

namespace MainApp.dtos
{
    public class WeatherForecastDto
    {
        public int WeatherForecastId {get;set;}
        public List<WeatherReportDto> WeatherReports {get;set;}
        public DateTime UpdatedAt {get;set;}
    }
}