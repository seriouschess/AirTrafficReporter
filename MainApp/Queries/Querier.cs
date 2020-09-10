using MainApp.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using MainApp.dtos;
using System.Globalization;

namespace MainApp.Queries
{
    public class Querier
    {
        private DatabaseContext dbContext;

        public Querier( DatabaseContext _dbContext ){
            dbContext = _dbContext;
        }

        //DB creation methods
        public void AddAirport(Airport NewAirport){ //save changes required
            dbContext.Add( NewAirport );
        }

        public void AddRunway(Runway NewRunway){ //save changes required
            dbContext.Add( NewRunway );
        }

        public void SaveChanges(){
            dbContext.SaveChanges();
        }

        public void AddWeatherForecast(WeatherForecast NewWeatherForecast){
            //no more than one forecast may exist per airport
            List<WeatherForecast> FoundForecasts = dbContext.WeatherForecasts.Where(x => x.AirportId == NewWeatherForecast.AirportId).ToList();
            if(FoundForecasts.Count == 0){
                //add forecast
                dbContext.Add( NewWeatherForecast );
                dbContext.SaveChanges();
            }
            
            if(FoundForecasts.Count == 1){
                //update existing forecast
                FoundForecasts[0].WeatherReports = NewWeatherForecast.WeatherReports;
                FoundForecasts[0].UpdatedAt = DateTime.Now; 
                dbContext.SaveChanges();
            }

            if(FoundForecasts.Count > 1){
                //should never happen
                throw new System.Exception(
                    $"More than one forecast exists for Airport ID: {NewWeatherForecast.AirportId}. Module rewrite required.");
            }            
        }

        public void DeleteWeatherForecast(WeatherForecast DoomedWeatherForecast){
            dbContext.Remove(DoomedWeatherForecast);
            dbContext.SaveChanges();
        }

        public void AddWeatherReport(WeatherReport NewWeatherReport){
            dbContext.Add( NewWeatherReport );
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

        public List<Airport> FindAirportByIncompleteNameTenMax( string incomplete_string ){
            //string lowercase_incomplete_string = incomplete_string.ToLower();

            List<Airport> FoundAirports = dbContext.Airports.Where(
                x => x.AirportName.Contains(incomplete_string)).Take(10).ToList();

            return FoundAirports;
        }

        public Airport FindAirportWithForecastById(int airport_id ){
              List<Airport> FoundAirport = dbContext.Airports.Where(x => x.AirportId == airport_id).Select(a => new Airport(){
                AirportId = a.AirportId,
                AirportName = a.AirportName,
                Latitude = a.Latitude,
                Longitude = a.Longitude,
                WeatherForecast = dbContext.WeatherForecasts.Where(f => f.AirportId == airport_id).ToList()
            }).ToList();
            if(FoundAirport.Count != 1){
                throw new System.ArgumentException("Airport Id Not Found.");
            }else{
                return FoundAirport[0];
            }
        }

        public AirportDto FindFullAirportInformationById( int airport_id ){
            CultureInfo datetime_culture_format = CultureInfo.CreateSpecificCulture("en-US");
            List<AirportDto> FoundAirport = dbContext.Airports.Where(x => x.AirportId == airport_id).Select(a => new AirportDto(){
                AirportId = a.AirportId,
                AirportName = a.AirportName,
                Latitude = a.Latitude,
                Longitude = a.Longitude,
                Runways = dbContext.Runways.Where(r => r.AirportId == airport_id).Select(ru => new RunwayDto(){
                    RunwayId = ru.RunwayId,
                    RunwayName = ru.RunwayName,
                    RunwayLengthFt =ru.RunwayLengthFt,
                    RunwayMaterial = ru.RunwayMaterial,
                    LowHeadingDeg = ru.LowHeadingDeg
                }).ToList(),
                WeatherForecast = dbContext.WeatherForecasts.Where(f => f.AirportId == airport_id).Select(w => new WeatherForecastDto(){
                    WeatherForecastId = w.WeatherForecastId,
                    UpdatedAt = w.UpdatedAt,
                    WeatherReports = dbContext.WeatherReports.Where(r => r.WeatherForecastId == w.WeatherForecastId).Select(re => new WeatherReportDto(){
                        Temperature = re.Temperature,
                        Description = re.Description,
                        WindSpeed = re.WindSpeed,
                        WindDirectionDeg = re.WindDirectionDeg,
                        PredictionDateString = re.PredictionDatetime.ToString("D", datetime_culture_format)
                    }).ToList(),
                }).ToList()
            }).ToList();
            if(FoundAirport.Count != 1){
                throw new System.ArgumentException("Airport Id Not Found.");
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
    }
}