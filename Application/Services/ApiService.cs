namespace RealTimeDataApp.Application.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetDataAsync(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}