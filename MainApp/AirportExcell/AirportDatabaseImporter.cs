using MainApp.Models;
using MainApp.Queries;
using Microsoft.AspNetCore.Hosting;

namespace MainApp.AirportExcell
{
    public class AirportDatabaseImporter
    {
        private string _path;
        private Querier _dbQuery;
        public AirportDatabaseImporter(IWebHostEnvironment env, Querier dbQuery){
            _path = $"{env.ContentRootPath}/AirportExcell/Airports.csv";
            _dbQuery = dbQuery;
        }

        public string ImportTest(){
            string[] rows = System.IO.File.ReadAllLines(_path);
            int column_count = rows[1].Split(',').Length;
            return $"Column Count: {column_count}";
        }
        
        public void import(){
            System.Console.WriteLine("Initialising database: this may take several minutes...");
            
            Airport NewAirport;
            string[] rows = System.IO.File.ReadAllLines(_path);

            for(int y=1; y<rows.Length; y++){
                NewAirport = new Airport();
                string[] current_column = rows[y].Split(',');
                for(int x=0; x<current_column.Length; x++){
                    if(x == 3){
                        NewAirport.Name += current_column[x].Replace("\"", "");
                    }
                    if(x == 4){
                        NewAirport.Latitude = current_column[x];
                    }
                    if(x == 5){
                        NewAirport.Longitude = current_column[x];
                    }                    
                }
                if(y%1001 == 0){
                    System.Console.WriteLine($"Adding item {y-1} out of {rows.Length}...");
                }
                _dbQuery.AddAirport(NewAirport);
            }

            

            System.Console.WriteLine("Database initialized with Airports");
        }
        
    }
}