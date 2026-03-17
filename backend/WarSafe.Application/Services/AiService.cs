using System.Net.Http.Json;

public class AiService
{
    private readonly HttpClient _http;

    public AiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<object> Cluster(List<object> coords)
    {
        var response = await _http.PostAsJsonAsync("http://localhost:8000/cluster", coords);
        return await response.Content.ReadFromJsonAsync<object>();
    }
}