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

namespace MainApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        static HttpClient client = new HttpClient();
        WeatherForecastControllerMethods methods;

        private readonly ILogger<WeatherForecastController> _logger;

        private IWebHostEnvironment _env;

        private Querier _dbQuery;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Querier dbQuery, IWebHostEnvironment env)
        {
            _dbQuery = dbQuery;
            _env = env;
            methods = new WeatherForecastControllerMethods(dbQuery);
            _logger = logger;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return methods.GetMethod();
        }

        [HttpGet]
        [Route("test")]
        public async Task<ActionResult<List<WeatherForecast>>> RunTest(){
            WeatherApiCaller weather_api = new WeatherApiCaller(client);
            return await weather_api.GetWeatherForLocation(25,30);
        }
    }
}
