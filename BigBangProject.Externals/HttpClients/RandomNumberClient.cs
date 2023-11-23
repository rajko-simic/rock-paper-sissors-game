using System.Text.Json;
using System.Text.Json.Serialization;
using BigBangProject.Externals.Interfaces;

namespace BigBangProject.Externals.HttpClients;

public class RandomNumberClient : IRandomNumberClient
{
    private const string RandomEndpoint = "https://codechallenge.boohma.com/random";
    private readonly HttpClient _httpClient = new();
    
    public async Task<int> GetRandomValue()
    {
        var response = await _httpClient.GetAsync(RandomEndpoint);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        
        var randomResult = JsonSerializer.Deserialize<RandomNumberResponse>(content);
        if (randomResult is null)
            throw new ArgumentNullException(content, "");
            
        return randomResult.RandomNumber;
    }
    
    public record RandomNumberResponse(
        [property: JsonPropertyName("random_number")] int RandomNumber
    );
}