using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;
using project_wildfire_web.Models;


namespace project_wildfire_web.Models.DTO
{
public partial class FireDatumDTO
{
    //[Required]
    //[Name("latitude")]
  //  public int FireID {get; set;}

    [Required]
    [Name("latitude")]
    public double? Latitude { get; set; }

    [Required]
    [Name("longitude")]
    public double? Longitude { get; set; }

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
        Latitude = fireDatum.Latitude,
        Longitude = fireDatum.Longitude,
        RadiativePower = fireDatum.RadiativePower
        };


    }
        }

    }