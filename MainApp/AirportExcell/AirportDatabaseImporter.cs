using MainApp.Models;
using MainApp.Queries;
using Microsoft.AspNetCore.Hosting;

namespace MainApp.AirportExcell
{
    public class AirportDatabaseImporter
    {
        private string _airports_path;
        private string _runways_path;
        private Querier _dbQuery;
        public AirportDatabaseImporter(IWebHostEnvironment env, Querier dbQuery){
            _airports_path = $"{env.ContentRootPath}/AirportExcell/Airports.csv";
            _runways_path = $"{env.ContentRootPath}/AirportExcell/Runways.csv";
            _dbQuery = dbQuery;
        }

        public string ImportTest(){
            string[] rows = System.IO.File.ReadAllLines(_airports_path);
            int column_count = rows[1].Split(',').Length;
            return $"Column Count: {column_count}";
        }
        
        public void ImportAirportData(){
            System.Console.WriteLine("Initialising database...");
            
            Airport NewAirport;
            string[] rows = System.IO.File.ReadAllLines(_airports_path);

            for(int y=1; y<2001; y++){
                NewAirport = new Airport();
                string[] current_column = rows[y].Split(',');
                for(int x=0; x<current_column.Length; x++){
                    if(x == 0){
                        NewAirport.AirportRef = System.Int32.Parse(current_column[x]);
                    }
                    if(x == 3){
                        NewAirport.AirportName = current_column[x].Replace("\"", "");
                    }
                    if(x == 4){
                        try{
                            NewAirport.Latitude = double.Parse(current_column[x]);
                        }catch{
                            //do nothing
                        }
                    }
                    if(x == 5){
                        try{
                            NewAirport.Longitude = double.Parse(current_column[x]);
                        }catch{
                            //do nothing
                        }
                    }                    
                }
                if(y%1001 == 0){
                    System.Console.WriteLine($"Adding item {y-1} out of {rows.Length}...");
                }
                _dbQuery.AddAirport(NewAirport);
            }

            System.Console.WriteLine("Database initialized with Airports");
        }

        public void ImportRunwayData(){
            System.Console.WriteLine("Initializing runway data...");

            Runway NewRunway;
            string[] rows = System.IO.File.ReadAllLines(_runways_path);

            for(int y=1; y<2001; y++){
                NewRunway = new Runway();
                string[] current_column = rows[y].Split(',');
                for(int x=0; x<current_column.Length; x++){
                    if(x == 1){
                        int airport_id =_dbQuery.FindAirportByReference(System.Int32.Parse(current_column[x])).AirportId;
                        NewRunway.AirportId = airport_id;
                    }
                    if(x == 3){
                        NewRunway.RunwayLengthFt = System.Int32.Parse(current_column[x]);
                    }
                    if(x == 5){
                        NewRunway.RunwayMaterial = current_column[x].Replace("\"", "");
                    }

                    if(x == 12){
                        try{
                            NewRunway.LowHeadingDeg = System.Int32.Parse(current_column[x]);
                        }catch{
                            NewRunway.LowHeadingDeg = null;
                        } 
                    }
                    
                    if(x == 8){
                        NewRunway.RunwayName = current_column[x].Replace("\"", "");
                    }                   
                }
                if(y%1001 == 0){
                    System.Console.WriteLine($"Adding item {y-1} out of {rows.Length}...");
                }
                _dbQuery.AddRunway(NewRunway);
            }

            System.Console.WriteLine("Database initalized with runways...");
        }
        
    }
}