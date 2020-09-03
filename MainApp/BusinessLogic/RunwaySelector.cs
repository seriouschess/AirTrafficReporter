using System;
using System.Collections.Generic;
using MainApp.dtos;

namespace MainApp.BusinessLogic
{
    public class RunwaySelector
    {
        public RunwaySelector(){}

        public bool ValidateRunway(){
            bool t = true;
            if(t){
                return true;
            }else{
                return false;
            }
        }

        //possible to receive empty list and/or return null
        public List<int> ConvertRunways(List<RunwayDto> runways){

            if(runways == null){ //some airports don't have runway data
                return null;
            }

            List<int> runway_directions = new List<int>();
            foreach( RunwayDto runway in runways ){
                if( runway.LowHeadingDeg != null ){
                    runway_directions.Add( (int)runway.LowHeadingDeg ); //not nullable
                }else if(runway.RunwayName.Contains("H") || runway.RunwayName.Contains("B")){ //helicopters and balloons
                    //do nothing, don't add
                }else{ 
                    //extract numbers from string
                    string s = runway.RunwayName;
                    string number_string = "";
                    for(int x=0; x<s.Length; x++){
                        try{
                            System.Int32.Parse( s[x]+"" );

                            //throw error for characters and don't add to number
                            number_string += s[x];
                        }catch{
                            //do nothing
                        }
                    }
                    int r_direction = System.Int32.Parse( number_string );
                    runway_directions.Add( r_direction );
                }
            }

            if(runway_directions.Count == 0){
                return null;
            }else{
                return runway_directions;
            }
        }

        public int SelectRunway( List<int> runway_directions, int wind_direction ){ //returns integer index with most optimal runway

            if(runway_directions.Count == 0 || runway_directions == null){
                throw new System.ArgumentException("Runway selector cannot accept empty runway list");
            }

            RunwayDto SelectedRunway = new RunwayDto();

            //find the lowest value cosine for the difference between the wind angle and the runway angle

            double LowestCosine = 1; //inital value max
            int current_winner = 0;

            for(int x=0;x<runway_directions.Count;x++){

                //candidate runway directions
                int direction = runway_directions[x];
                int opposite_direction = (direction + 180) % 360;

                //difference between runway directions and wind direction
                int absolute_difference_a = Math.Abs(direction - wind_direction );
                int absolute_difference_b = Math.Abs(opposite_direction - wind_direction );

                double test_a = Math.Cos( absolute_difference_a* Math.PI / 180.0 );
                double test_b = Math.Cos( absolute_difference_b* Math.PI / 180.0 );
                System.Console.WriteLine($"Differances a:{absolute_difference_a} b:{absolute_difference_b}");
                System.Console.WriteLine($"Tests a:{test_a} b:{test_b}");

                if( test_a < LowestCosine ){
                    System.Console.WriteLine("doe");
                    LowestCosine = test_a;
                    current_winner = x;
                }

                if( test_b < LowestCosine ){
                    System.Console.WriteLine("ray");
                    LowestCosine = test_a;
                    current_winner = x;
                }
            }
            
            return current_winner;
        }
    }
}