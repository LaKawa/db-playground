// csharp
using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed class Artist
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    // Often present in Discogs responses
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("realname")]
    public string? RealName { get; init; }

    [JsonPropertyName("profile")]
    public string? Profile { get; init; }

    [JsonPropertyName("releases_url")]
    public string? ReleasesUrl { get; init; }

    [JsonPropertyName("resource_url")]
    public string? ResourceUrl { get; init; }

    [JsonPropertyName("uri")]
    public string? Uri { get; init; }

    [JsonPropertyName("urls")]
    public List<string> Urls { get; init; } = [];

    [JsonPropertyName("data_quality")]
    public string? DataQuality { get; init; }

    [JsonPropertyName("namevariations")]
    public List<string> NameVariations { get; init; } = [];

    [JsonPropertyName("images")]
    public List<Image> Images { get; init; } = [];

    // Present for groups
    [JsonPropertyName("members")]
    public List<ArtistMember> Members { get; init; } = [];

    // Occasionally included by the API
    [JsonPropertyName("aliases")]
    public List<ArtistReference> Aliases { get; init; } = [];

    [JsonPropertyName("groups")]
    public List<ArtistReference> Groups { get; init; } = [];
}

public sealed class ArtistMember
{
    [JsonPropertyName("active")]
    public bool? Active { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("resource_url")]
    public string? ResourceUrl { get; init; }
}

public sealed class ArtistReference
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("resource_url")]
    public string? ResourceUrl { get; init; }
}
