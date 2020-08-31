using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MainApp.Controllers.ControllerMethods;
using MainApp.Queries;

namespace MainApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        WeatherForecastControllerMethods methods;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Querier dbQuery)
        {
            methods = new WeatherForecastControllerMethods(dbQuery);
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return methods.GetMethod();
        }
    }
}
