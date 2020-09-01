#Airport Noise Tracker

Made with Angular and ASP.NET Core 3.1

Angular: ./MainApp/ClientApp
ASP.NET Core: ./MainApp


#Running Migrations:

Multiproject ef Migration:
dotnet ef --startup-project MainApp/MainApp.csproj migrations add first -p MainApp/MainApp.csproj

Multiproject Database Update:
dotnet ef --startup-project MainApp/MainApp.csproj database update 