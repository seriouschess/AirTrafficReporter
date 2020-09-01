using System.ComponentModel.DataAnnotations.Schema;

namespace MainApp.Models
{
    public class Runway
    {
        public int RunwayId {get;set;}
        public int AirportId {get;set;}
        [ForeignKey("AirportId")]
        public Airport Airport {get;set;}
        public string RunwayName {get;set;} //Also known as le_ident in the .csv
        public string RunwayMaterial {get;set;}
        public int RunwayLengthFt {get;set;} //also applies to helipads
        public int? LowHeadingDeg {get;set;} //Not listed for every runway (helipads)!
    }
}