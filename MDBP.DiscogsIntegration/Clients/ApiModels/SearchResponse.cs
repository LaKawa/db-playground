using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed class SearchResponse
{
    [JsonPropertyName("pagination")]
    public PageInfo? Pagination { get; init; }

    [JsonPropertyName("results")]
    public List<SearchResultItem> Results { get; init; } = [];
}

public sealed class SearchResultItem
{
    // Arrays
    [JsonPropertyName("style")]
    public List<string> Style { get; init; } = [];

    [JsonPropertyName("format")]
    public List<string> Format { get; init; } = [];

    [JsonPropertyName("label")]
    public List<string> Label { get; init; } = [];

    [JsonPropertyName("genre")]
    public List<string> Genre { get; init; } = [];

    [JsonPropertyName("barcode")]
    public List<string> Barcode { get; init; } = [];

    // Scalars
    [JsonPropertyName("thumb")]
    public string? Thumb { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("country")]
    public string? Country { get; init; }

    // Discogs returns year as string in search results
    [JsonPropertyName("year")]
    public string? Year { get; init; }

    [JsonPropertyName("uri")]
    public string? Uri { get; init; }

    [JsonPropertyName("resource_url")]
    public string? ResourceUrl { get; init; }

    // One of: release, master, artist, label
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }

    // Minimal community stats for search results
    [JsonPropertyName("community")]
    public SearchCommunityStats? Community { get; init; }
}

public sealed class SearchCommunityStats
{
    [JsonPropertyName("want")]
    public int? Want { get; init; }

    [JsonPropertyName("have")]
    public int? Have { get; init; }
}
