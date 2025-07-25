using ForEveryAdventure.Api.Models;
using ForEveryAdventure.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ForEveryAdventure.Services
{
    public class ForEveryAdventureApiService
    {
        private readonly HttpClient _client = new HttpClient();
        private const string BaseUrl = "http://localhost:5034/api";

        // Fixes CS0721 and IDE0060: Remove JsonSerializer parameter, use static JsonSerializer directly
        public async Task<AssetTag> CreateAssetTagAsync(Guid userId)
        {
            var content = new StringContent(JsonSerializer.Serialize(userId), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{BaseUrl}/MakeAssetTag", content);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AssetTag>(json);
        }

        public async Task<TripPlan> AddTripPlanAsync(TripPlan plan)
        {
            var content = new StringContent(JsonSerializer.Serialize(plan), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{BaseUrl}/AddPlanLogistics", content);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TripPlan>(json);
        }

        public async Task<AssetTag> GetAssetTagAsync(string tagCode)
        {
            var response = await _client.GetAsync($"{BaseUrl}/ShareAssetTag/{tagCode}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AssetTag>(json);
        }

        public async Task<string> SendEmergencyAlertAsync(string tagCode)
        {
            var response = await _client.PostAsync($"{BaseUrl}/Emergency/{tagCode}/alert", null);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}