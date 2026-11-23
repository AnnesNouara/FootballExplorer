
using System.Net.Http.Json;
using System.Text.Json;

namespace FootballExplorer.Server.Services;

public class FootballApiService
{
    private readonly HttpClient _httpClient;

    public FootballApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("FootballData");
    }

    public async Task<JsonElement> GetAsync(string endpoint)
    {
        var response = await _httpClient.GetFromJsonAsync<JsonElement>(endpoint);

        return response;
    }
}
