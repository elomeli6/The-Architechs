using System.Net.Http;
using System.Net.Http.Json;
using project_wildfire_web.Models;
using project_wildfire_web.Services;

namespace project_wildfire_web.Services
{
    public class EonetService : IEonetService
    {
        private readonly HttpClient _httpClient;

        public EonetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EonetEvent>> GetActiveWildfireEventsAsync(int days = 0)
        {
            var url = $"events?category=wildfires&status=open&days={days}";
            var resp = await _httpClient.GetAsync(url);
            resp.EnsureSuccessStatusCode();
            var wrapper = await resp.Content.ReadFromJsonAsync<EonetResponse>();
            return wrapper?.Events ?? new List<EonetEvent>();
        }

        public async Task<EonetEvent> GetEventDetailsAsync(string eventId)
        {
            var resp = await _httpClient.GetAsync($"events/{eventId}");
            resp.EnsureSuccessStatusCode();
            var wrapper = await resp.Content.ReadFromJsonAsync<EonetResponse>();
            return wrapper?.Events?.FirstOrDefault();
        }
    }
}