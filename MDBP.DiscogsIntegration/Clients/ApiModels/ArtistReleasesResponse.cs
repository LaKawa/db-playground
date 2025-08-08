// csharp
using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed class ArtistReleasesResponse
{
    [JsonPropertyName("pagination")]
    public PageInfo? Pagination { get; init; }

    [JsonPropertyName("releases")]
    public List<ArtistReleaseListItem> Releases { get; init; } = [];
}

public sealed class ArtistReleaseListItem
{
    [JsonPropertyName("artist")]
    public string? Artist { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }

    // Present when item is a master
    [JsonPropertyName("main_release")]
    public int? MainRelease { get; init; }

    [JsonPropertyName("resource_url")]
    public string? ResourceUrl { get; init; }

    [JsonPropertyName("role")]
    public string? Role { get; init; }

    [JsonPropertyName("thumb")]
    public string? Thumb { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    // "master" or "release"
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("year")]
    public int? Year { get; init; }

    // Present for releases
    [JsonPropertyName("format")]
    public string? Format { get; init; }

    // Present for releases
    [JsonPropertyName("label")]
    public string? Label { get; init; }

    // Present for releases
    [JsonPropertyName("status")]
    public string? Status { get; init; }
}
