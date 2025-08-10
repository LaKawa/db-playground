using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;
public sealed record Pagination
{
    [JsonPropertyName("per_page")]
    public int PerPage { get; init; }

    [JsonPropertyName("pages")]
    public int Pages { get; init; }

    [JsonPropertyName("page")]
    public int Page { get; init; }

    [JsonPropertyName("items")]
    public int Items { get; init; }

    [JsonPropertyName("urls")]
    public PaginationUrls Urls { get; init; } = new();
}


public sealed record PaginationUrls
{
    [JsonPropertyName("next")]
    public Uri? Next { get; init; }

    [JsonPropertyName("prev")]
    public Uri? Prev { get; init; }

    [JsonPropertyName("first")]
    public Uri? First { get; init; }

    [JsonPropertyName("last")]
    public Uri? Last { get; init; }
}
