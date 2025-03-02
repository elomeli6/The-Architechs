using project_wildfire_web.DAL.Abstract;
using project_wildfire_web.Models;

namespace project_wildfire_web
{
    public interface IWildfireRepository
    {
        ICollection<FireDatum> GetWildfires();
    }
}