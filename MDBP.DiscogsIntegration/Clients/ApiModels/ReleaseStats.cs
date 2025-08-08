using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed class ReleaseStats
{
    [JsonPropertyName("num_have")]
    public int NumHave { get; init; }

    [JsonPropertyName("num_want")]
    public int NumWant { get; init; }
}
