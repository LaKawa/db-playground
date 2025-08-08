using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed class LabelReleasesResponse
{
    [JsonPropertyName("pagination")]
    public PageInfo? Pagination { get; init; }

    [JsonPropertyName("releases")]
    public List<LabelReleaseListItem> Releases { get; init; } = [];
}

public sealed class LabelReleaseListItem
{
    [JsonPropertyName("artist")]
    public string? Artist { get; init; }

    [JsonPropertyName("catno")]
    public string? Catno { get; init; }

    [JsonPropertyName("format")]
    public string? Format { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("resource_url")]
    public string? ResourceUrl { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("thumb")]
    public string? Thumb { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("year")]
    public int? Year { get; init; }
}
