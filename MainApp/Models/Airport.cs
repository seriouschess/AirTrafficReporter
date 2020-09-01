using System.Collections.Generic;

namespace MainApp.Models
{
    public class Airport
    {
        public int AirportId {get;set;}
        public int AirportRef {get;set;}
        public string AirportName {get;set;}
        public double Latitude {get;set;}
        public double Longitude {get;set;}
        public List<Runway> Runways {get;set;}
    }
}