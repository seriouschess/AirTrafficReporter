using MainApp.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace MainApp.Queries
{
    public class Querier
    {
        private DatabaseContext dbContext;

        public Querier( DatabaseContext _dbContext ){
            dbContext = _dbContext;
        }

        public Airport AddAirport(Airport _NewAirport){
            Airport NewAirport = new Airport();
            NewAirport.Name = _NewAirport.Name;
            NewAirport.Latitude = _NewAirport.Latitude;
            NewAirport.Longitude = _NewAirport.Longitude;
            dbContext.Add( NewAirport );
            dbContext.SaveChanges();
            return FindAirportById( NewAirport.AirportId );
        }

        public Airport FindAirportById(int airport_id){
            List<Airport> FoundWalk = dbContext.Airports.Where(x => x.AirportId == airport_id).ToList();
            if( FoundWalk.Count != 1 ){
                throw new System.ArgumentException("Airport ID not found");
            }else{
                return FoundWalk[0];
            } 
        }

    }
}