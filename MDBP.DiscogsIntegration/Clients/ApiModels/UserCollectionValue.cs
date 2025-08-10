// csharp
using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed record UserCollectionValue
{
    [JsonPropertyName("maximum")]
    public string Maximum { get; init; } = string.Empty;

    [JsonPropertyName("median")]
    public string Median { get; init; } = string.Empty;

    [JsonPropertyName("minimum")]
    public string Minimum { get; init; } = string.Empty;
}
