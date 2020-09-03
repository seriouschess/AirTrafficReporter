using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MainApp.Controllers.ControllerMethods;
using MainApp.Queries;
using Microsoft.AspNetCore.Hosting;
using MainApp.AirportExcell;
using MainApp.Weather;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MainApp.Models;
using MainApp.dtos;

namespace MainApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportController : ControllerBase
    {
        static HttpClient client = new HttpClient();
        AirportControllerMethods methods;

        private readonly ILogger<AirportController> _logger;

        private IWebHostEnvironment _env;

        private Querier _dbQuery;

        public AirportController(ILogger<AirportController> logger, Querier dbQuery, IWebHostEnvironment env)
        {
            _dbQuery = dbQuery;
            _env = env;
            methods = new AirportControllerMethods(dbQuery, client);
            _logger = logger;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet]
        [Route("test")]
        public async Task<ActionResult<WeatherForecast>> RunTest(){
            WeatherInformation weather_api = new WeatherInformation(client);
            return await weather_api.GetWeatherForLocation(25,30);
        }

        [HttpGet]
        [Route("search/{search_string}")]
        public ActionResult<List<Airport>> SearchAirports(string search_string){
            return methods.SearchAirportsMethod( search_string );
        }

        [HttpGet]
        [Route("full/{airport_id}")]
        public async Task<ActionResult<AirportDto>> GetFullAirportWithId(int airport_id){
            return await methods.GetFullAirportWithIdMethod( airport_id );
        }
    }
}