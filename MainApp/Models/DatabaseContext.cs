using Microsoft.EntityFrameworkCore;

namespace MainApp.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options) : base (options) { }
        public DbSet<Airport> Airports {get;set;}
        public DbSet<Runway> Runways {get;set;}
        public DbSet<WeatherForecast> WeatherForecasts {get;set;}
        public DbSet<WeatherReport> WeatherReports {get;set;}
    }
}