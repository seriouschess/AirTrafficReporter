using MainApp.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using MainApp.Models;
using System.Net.Http;
using MainApp.Weather;
using System.Threading.Tasks;
using MainApp.dtos;
using MainApp.BusinessLogic;

namespace MainApp.Controllers.ControllerMethods
{
    public class AirportControllerMethods: ControllerBase
    {
        Querier dbQuery;
        HttpClient client;
        public AirportControllerMethods( Querier _dbQuery, HttpClient _client ){
            client = _client;
            dbQuery = _dbQuery;
        }

        public async Task<ActionResult<string>> UpdateWeatherForAirportMethod(int airport_id){
            Airport FoundAirport;
            try{
                FoundAirport = dbQuery.FindAirportWithForecastById(airport_id);
            }catch{
                JsonResponse r = new JsonResponse("Invalid Airport Id"); 
                return StatusCode(400, r);
            }

            if(FoundAirport.WeatherForecast.Count > 0){ //verify weather cache

                //check if less than 1 hour since last update
                if( FoundAirport.WeatherForecast[0].UpdatedAt.AddHours(1) > DateTime.Now  ){ 
                    //don't update cache
                    return "cache ok";
                }
            }

            WeatherInformation weather_information = new WeatherInformation(client);

            WeatherForecast airport_forecast =
             await weather_information.GetWeatherForLocation( FoundAirport.Latitude, FoundAirport.Longitude );

            airport_forecast.AirportId = FoundAirport.AirportId;
            dbQuery.AddWeatherForecast(airport_forecast);

            return "cache updated";
        }

        public async Task<ActionResult<AirportDto>> GetFullAirportWithIdMethod(int airport_id){
            try{
                await UpdateWeatherForAirportMethod(airport_id);
            }catch(ArgumentException e){
                JsonResponse r = new JsonResponse(e.Message);
                return StatusCode(400, r);
            }

            AirportDto FoundAirport;
            try{
                FoundAirport = dbQuery.FindFullAirportInformationById(airport_id);
            }catch{
                JsonResponse r = new JsonResponse("Invalid Airport Id"); 
                return StatusCode(400, r);
            }

            RunwaySelector selector = new RunwaySelector();
            selector.AssignOptimalRunwayToAirportDto(FoundAirport);
            return FoundAirport;
        }
    }
}