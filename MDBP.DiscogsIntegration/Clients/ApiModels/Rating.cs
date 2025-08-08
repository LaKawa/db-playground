using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed class Rating
{
    [JsonPropertyName("average")]
    public decimal? Average { get; init; }

    [JsonPropertyName("count")]
    public int? Count { get; init; }
}