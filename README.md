## Airport Noise Tracker

Made with Angular and ASP.NET Core 3.1

Angular: ./MainApp/ClientApp
ASP.NET Core: ./MainApp
DB: MySQL


Currently deployed at: https://airnoisetracker.professionalserver.net/




## Application Overview

- Find where airplanes are taking off from your local airport based on local weather information.
- Search any registered airport in the world.
- Display 5 day weather forecast with air traffic patterns for each day.




## API Endpoints:

HttpGet - .../airport/search/<string search_string>

returns up to 10 airports whose airport name contains the search string. The search is not case sensative.

HttpGet 0 .../airport/full/<int airport_id>

returns an airport with runway and local 5 day weather forecast in addition to calculated optimal runway data for each day of the forecast.



## Custom file folders:

AirportExcell - 

Contains .csv files used to initialise database with airports and runways, and AirportDatabaseImporter class which is called in Startup.cs

Weather - Contains WeatherInformation class which is used to load weather information using the openweather.org API

BusinessLogic - 

Contains RunwaySelector class used to select the appropriate runway direction given weather conditions.
Contains a small validator used by the search route.

Queries - Contains all database queries used by the project.

Models - Contains all database models and the database context used by Entity ORM

Controllers/ControllerMethods - Contains main logic for each of the two routes which comprise the backend API.

ClientApp/src - Contains all frontend code written in AngularJS



## Setup:

create a file called appsettings.json in the ./MainApp directory and add the following content with your sql root and password:
```yaml
{
  "ConnectionStrings":{
    "ConnectionString": "<Your remote db connection string>",
    "WeatherApiKey": "<Your openweather.org api key here>"
  }
}
```




## Running Migrations:

Multiproject ef Migration:
dotnet ef --startup-project MainApp/MainApp.csproj migrations add first -p MainApp/MainApp.csproj

Multiproject Database Update:
dotnet ef --startup-project MainApp/MainApp.csproj database update

Run Application:
dotnet run --project ./MainApp


Note: Database initialization happens on startup and can take a while to load. Progress can be tracked in the console on the first startup.