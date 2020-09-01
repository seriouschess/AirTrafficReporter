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

namespace MainApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
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
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return methods.GetMethod();
        }

        [HttpGet]
        [Route("test")]
        public string RunTest(  ){
            return "hi";
        }
    }
}
