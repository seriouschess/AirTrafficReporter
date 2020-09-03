using System;
using System.Collections.Generic;
using MainApp.dtos;

namespace MainApp.BusinessLogic
{
    public class RunwaySelector
    {
        public RunwaySelector(){}

        public AirportDto AssignOptimalRunwayToAirportDto(AirportDto SubjectAirport){
            if(SubjectAirport.Runways == null || SubjectAirport.Runways.Count == 0 ){
                return SubjectAirport; //no runways, do nothing
            }else{
                if(SubjectAirport.WeatherForecast[0] == null){
                    throw new System.ArgumentException( "WeatherForecast required before optimal runway can be assigned" );
                }
                foreach(RunwayDto runway in SubjectAirport.Runways){ //reset all runways
                    runway.OptimalRunway = false;
                }
                int wind_direction = SubjectAirport.WeatherForecast[0].WeatherReports[0].WindDirectionDeg;


                List<int> converted_runways = ConvertRunways(SubjectAirport.Runways);

                //helicopter pads return null, do nothing if null
                if(converted_runways != null){
                    int optimal_runway_index = SelectRunway( converted_runways, wind_direction);
                    SubjectAirport.Runways[optimal_runway_index].OptimalRunway = true;
                }
            }
            return SubjectAirport;
        }

        //possible to receive empty list and/or return null
        public List<int> ConvertRunways(List<RunwayDto> runways){

            if(runways == null){ //ensure not null
                throw new System.ArgumentException("ConvertRunways cannot accept a null runway object.");
            }

            List<int> runway_directions = new List<int>();
            foreach( RunwayDto runway in runways ){

                if( runway.LowHeadingDeg != null ){
                    runway_directions.Add( (int)runway.LowHeadingDeg ); //not nullable
                }else if(runway.RunwayName.Contains("H")){ //helicopters
                    runway.RunwayDescription = "Has a Helicopter Pad";
                }else if(runway.RunwayName.Contains("B")){ //ballons don't make noise
                    runway.RunwayDescription = "Has A Balloon Pad";
                }else{ 
                    //determine runway scale
                    if((runway.RunwayMaterial.ToLower().Contains("as")
                     || runway.RunwayMaterial.ToLower().Contains("con"))
                     && runway.RunwayLengthFt > 6000){ //asphalt or concrete runways of sufficient length
                        runway.RunwayDescription = "Capable of fielding large planes";
                    }else{
                        runway.RunwayDescription = "Capable of fielding small planes";
                    }

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

                    int r_direction;
                    //handle edge cases
                    if(number_string == ""){ //no numbers were extracted
                        string rn = runway.RunwayName.ToLower();
                        if(rn.Contains("ne")){
                            r_direction = 45;
                        }else if(rn.Contains("nw")){
                            r_direction = 315;
                        }else if(rn.Contains("ne")){
                            r_direction = 45;
                        }else if(rn.Contains("sw")){
                            r_direction = 225;
                        }else if(rn.Contains("se")){
                            r_direction = 135;
                        }else if(rn.Contains("n")){
                            r_direction = 360;
                        }else if(rn.Contains("s")){
                            r_direction = 180;
                        }else if(rn.Contains("e")){
                            r_direction = 90;
                        }else{ //rn.Contains("w")
                            r_direction = 270;
                        }
                        runway.LowHeadingDeg = r_direction; //provide angle to runway
                        runway_directions.Add( r_direction );
                    }else{ //attempt to parse numbers
                        try{
                            r_direction = System.Int32.Parse( number_string );
                            runway.LowHeadingDeg = r_direction; //provide angle to runway
                            runway_directions.Add( r_direction );
                        }catch{
                            throw new System.ArgumentException($"{runway.RunwayName} from RunwayID: {runway.RunwayId} did not contain a formatable string");
                        }
                    }
                }
            }

            if(runway_directions.Count == 0){
                return null;
            }else{
                return runway_directions;
            }
        }

        public int SelectRunway( List<int> runway_directions, int wind_direction ){ //returns integer index with most optimal runway

            if(runway_directions == null ||runway_directions.Count == 0 ){
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

                if( test_a < LowestCosine ){
                    LowestCosine = test_a;
                    current_winner = x;
                }

                if( test_b < LowestCosine ){
                    LowestCosine = test_a;
                    current_winner = x;
                }
            }
            
            return current_winner;
        }
    }
}