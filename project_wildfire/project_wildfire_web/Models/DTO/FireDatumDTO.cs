using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;
using project_wildfire_web.Models;
using NetTopologySuite.Geometries;



namespace project_wildfire_web.Models.DTO
{
public partial class FireDatumDTO
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    //[Required]
    //public Geometry Location { get; set; } = null!;


    [Required]
    [Name("frp")]
    public decimal RadiativePower { get; set; }

}

}

namespace project_wildfire_web.ExtensionsMethods
    {
    
        public static class FireDatumExtensions
        {
    public static FireDatum ToFireDatum (this project_wildfire_web.Models.DTO.FireDatumDTO fireDatum)
    {   
        return new project_wildfire_web.Models.FireDatum
        {
        Location = new Point(fireDatum.Longitude, fireDatum.Latitude) { SRID = 4326 },
        RadiativePower = fireDatum.RadiativePower
        };

    }
        }

    }