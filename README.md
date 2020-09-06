#Airport Noise Tracker

Made with Angular and ASP.NET Core 3.1

Angular: ./MainApp/ClientApp
ASP.NET Core: ./MainApp
DB: MySQL

#Application Overview

- Find where airplanes are taking off from your local airport based on local weather information.
- Search any registered airport in the world.
- Display 5 day weather forecast with air traffic patterns for each day.

#Setup:

create a file called appsettings.json in the ./MainApp directory and add the following content with your sql root and password:
```yaml
{
  "ConnectionString": "server=localhost;userid=fakeuser;password=fakepassword;port=3306;database=relativitycapstone;SslMode=None",
  "WeatherApiKey": "<Your openweather.org api key here>"
}
```

#Running Migrations:

Multiproject ef Migration:
dotnet ef --startup-project MainApp/MainApp.csproj migrations add first -p MainApp/MainApp.csproj

Multiproject Database Update:
dotnet ef --startup-project MainApp/MainApp.csproj database update

Run Application:
dotnet run --project ./MainApp


Note: Database initialization happens on startup and can take a while to load. Progress can be tracked in the console on the first startup.