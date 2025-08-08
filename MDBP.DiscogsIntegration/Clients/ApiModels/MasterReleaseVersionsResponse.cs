using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed class MasterReleaseVersionsResponse
{
    [JsonPropertyName("pagination")]
    public PageInfo? Pagination { get; init; }

    [JsonPropertyName("versions")]
    public List<MasterReleaseVersion> Versions { get; init; } = [];
}

public sealed class PageInfo
{
    [JsonPropertyName("per_page")]
    public int? PerPage { get; init; }

    [JsonPropertyName("items")]
    public int? Items { get; init; }

    [JsonPropertyName("page")]
    public int? Page { get; init; }

    [JsonPropertyName("pages")]
    public int? Pages { get; init; }

    // Empty object in examples; map to dictionary for flexibility
    [JsonPropertyName("urls")]
    public Dictionary<string, string> Urls { get; init; } = [];
}

public sealed class MasterReleaseVersion
{
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("stats")]
    public VersionStats? Stats { get; init; }

    [JsonPropertyName("thumb")]
    public string? Thumb { get; init; }

    [JsonPropertyName("format")]
    public string? Format { get; init; }

    [JsonPropertyName("country")]
    public string? Country { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("label")]
    public string? Label { get; init; }

    // Discogs returns year as a string (e.g., "1993")
    [JsonPropertyName("released")]
    public string? Released { get; init; }

    [JsonPropertyName("major_formats")]
    public List<string> MajorFormats { get; init; } = [];

    [JsonPropertyName("catno")]
    public string? Catno { get; init; }

    [JsonPropertyName("resource_url")]
    public string? ResourceUrl { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }
}

public sealed class VersionStats
{
    [JsonPropertyName("user")]
    public VersionStatsCounts? User { get; init; }

    [JsonPropertyName("community")]
    public VersionStatsCounts? Community { get; init; }
}

public sealed class VersionStatsCounts
{
    [JsonPropertyName("in_collection")]
    public int? InCollection { get; init; }

    [JsonPropertyName("in_wantlist")]
    public int? InWantlist { get; init; }
}
