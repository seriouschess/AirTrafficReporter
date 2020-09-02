using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MainApp.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MainApp.Weather
{
    public class WeatherApiCaller
    {
        HttpClient _client;
        public WeatherApiCaller(HttpClient client){
            _client = client;
        }

        public async Task<List<WeatherForecast>> GetWeatherForLocation(double latitude, double longitude){
            System.Console.WriteLine(ConfSettings.Configuration["WeatherApiKey:Value"]);

            HttpResponseMessage response = await _client.GetAsync(
                $"https://api.openweathermap.org/data/2.5/forecast?lat={latitude}&lon={longitude}&APPID={ConfSettings.Configuration["WeatherApiKey"]}");

            if (response.IsSuccessStatusCode)
            {
                JObject forecast = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());

                List<WeatherForecast> weather_reports = new List<WeatherForecast>();
                WeatherForecast report;
                foreach(JObject weather_report in forecast["list"].ToArray()){
                    report = new WeatherForecast();
                    report.Description = (string)weather_report["weather"].ToArray()[0]["description"];
                    report.Temperature = (string)weather_report["main"]["temp"];
                    report.WindDirectionDeg = (int)weather_report["wind"]["deg"];
                    report.WindSpeed = (double)weather_report["wind"]["speed"];
                    string dt = (string)weather_report["dt_txt"];
                    report.DateTime = DateTime.Parse(dt);
                    weather_reports.Add(report);
                }
                return weather_reports;
            }else{
                throw new Exception("openweathermap.org returned bad status.");
            }
        }

        // public string Temperature {get;set;}
        // public string Description {get;set;}
        // public int WindDirectionDeg {get;set;} //360 is north
        // public double WindSpeed {get;set;}
    }
}