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

        //DB creation methods
        public void AddAirport(Airport NewAirport){
            dbContext.Add( NewAirport );
            dbContext.SaveChanges();
        }

        public void AddRunway(Runway NewRunway){
            dbContext.Add( NewRunway );
            dbContext.SaveChanges();
        }

        //DB search methods
        public Airport FindAirportById(int airport_id){
            List<Airport> FoundAirport = dbContext.Airports.Where(x => x.AirportId == airport_id).ToList();
            if( FoundAirport.Count != 1 ){
                throw new System.ArgumentException("ID not found for Airport");
            }else{
                return FoundAirport[0];
            } 
        }

        public Airport FindAirportByReference(int airport_reference){
            List<Airport> FoundAirport = dbContext.Airports.Where(x => x.AirportRef == airport_reference).ToList();
            if( FoundAirport.Count != 1 ){
                throw new System.ArgumentException("More than one Airport Reference exists!");
            }else{
                return FoundAirport[0];
            } 
        }

         public Runway FindRunwayById(int runway_id){
            List<Runway> FoundRunway = dbContext.Runways.Where(x => x.RunwayId == runway_id).ToList();
            if( FoundRunway.Count != 1 ){
                throw new System.ArgumentException("Runway ID not found");
            }else{
                return FoundRunway[0];
            } 
        }


        // public Airport AddAirportConfirmation(Airport _NewAirport){
        //     Airport NewAirport = new Airport();
        //     NewAirport.AirportId = _NewAirport.AirportId;
        //     NewAirport.Name = _NewAirport.Name;
        //     NewAirport.Latitude = _NewAirport.Latitude;
        //     NewAirport.Longitude = _NewAirport.Longitude;
        //     dbContext.Add( NewAirport );
        //     dbContext.SaveChanges();
        //     return FindAirportByAirportId( NewAirport.AirportId );
        // }
    }
}