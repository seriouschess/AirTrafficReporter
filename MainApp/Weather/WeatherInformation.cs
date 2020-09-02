using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MainApp.Configuration;
using MainApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MainApp.Weather
{
    public class WeatherInformation
    {
        HttpClient _client;
        public WeatherInformation(HttpClient client){
            _client = client;
        }

        public async Task<WeatherForecast> GetWeatherForLocation(double latitude, double longitude){
            System.Console.WriteLine(ConfSettings.Configuration["WeatherApiKey:Value"]);

            HttpResponseMessage response = await _client.GetAsync(
                $"https://api.openweathermap.org/data/2.5/forecast?lat={latitude}&lon={longitude}&APPID={ConfSettings.Configuration["WeatherApiKey"]}");

            if (response.IsSuccessStatusCode)
            {
                JObject forecast = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());

                //Create Weather Reports
                List<WeatherReport> weather_reports = new List<WeatherReport>();
                WeatherReport report;
                foreach(JObject weather_report in forecast["list"].ToArray()){
                    report = new WeatherReport();
                    report.Description = (string)weather_report["weather"].ToArray()[0]["description"];
                    report.Temperature = (string)weather_report["main"]["temp"];
                    report.WindDirectionDeg = (int)weather_report["wind"]["deg"];
                    report.WindSpeed = (double)weather_report["wind"]["speed"];
                    string dt = (string)weather_report["dt_txt"];
                    report.PredictionDatetime = DateTime.Parse(dt);

                    //check for changed API
                    if(report.Description == null || report.Temperature == null || weather_report["wind"]["deg"] == null || weather_report["wind"]["speed"] == null || dt == null){
                        throw new System.Exception("openweathermap.org api naming conventions have changed. Module requires update.");
                    }

                    weather_reports.Add(report);
                }

                //Export new Weather Forecast for Location
                WeatherForecast new_forecast = new WeatherForecast();
                new_forecast.WeatherReports = weather_reports;
                new_forecast.AirportId = 0; //to be assigned by other methods
                new_forecast.UpdatedAt = DateTime.Now;
                return new_forecast;
            }else{
                throw new Exception("openweathermap.org returned bad status.");
            }
        }
    }
}