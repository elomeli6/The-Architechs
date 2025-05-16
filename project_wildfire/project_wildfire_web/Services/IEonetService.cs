using project_wildfire_web.Models;

namespace project_wildfire_web.Services
{
    public interface IEonetService
    {
        Task<List<EonetEvent>> GetActiveWildfireEventsAsync(int days = 0);
        Task<EonetEvent> GetEventDetailsAsync(string eventId);
    }
}