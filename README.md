#Airport Noise Tracker

Made with Angular and ASP.NET Core 3.1

Angular: ./MainApp/ClientApp
ASP.NET Core: ./MainApp
DB: MySQL

#Setup:

create a file called appsettings.json in the ./MainApp directory and add the following content with your sql root and password:
```yaml
{
  "Logging": {
      "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
      }
    },
  "AllowedHosts": "*",
  "DBInfo":
          {
            "Name": "MySQLconnect",
            "ConnectionString": "server=localhost;userid=fakeuser;password=fakepassword;port=3306;database=relativitycapstone;SslMode=None"
          },
  "WeatherApiKey": "<Your openweather.org api key here>"
}
```


#Running Migrations:

Multiproject ef Migration:
dotnet ef --startup-project MainApp/MainApp.csproj migrations add first -p MainApp/MainApp.csproj

Multiproject Database Update:
dotnet ef --startup-project MainApp/MainApp.csproj database update 