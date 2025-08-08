using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed class ReleaseUserRating
{
    [JsonPropertyName("username")]
    public string? Username { get; init; }

    [JsonPropertyName("release_id")]
    public int ReleaseId { get; init; }

    // Discogs may return 0 when not rated; keep it nullable to be resilient
    [JsonPropertyName("rating")]
    public int? Rating { get; init; }
}
