using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

// TODO this is almost the same as UserCollectionFolderReleases.cs - consolidate!
public sealed record UserCollectionReleasesResponse
{
    [JsonPropertyName("pagination")]
    public required Pagination Pagination { get; init; }

    [JsonPropertyName("releases")]
    public required IReadOnlyList<UserCollectionReleaseInstance> Releases { get; init; }
}

public sealed record UserCollectionReleaseInstance
{
    [JsonPropertyName("instance_id")]
    public long InstanceId { get; init; }

    [JsonPropertyName("rating")]
    public int Rating { get; init; }

    [JsonPropertyName("basic_information")]
    public required ReleaseBasicInformation BasicInformation { get; init; }

    [JsonPropertyName("folder_id")]
    public int FolderId { get; init; }

    [JsonPropertyName("date_added")]
    public DateTimeOffset DateAdded { get; init; }

    // Release ID
    [JsonPropertyName("id")]
    public int Id { get; init; }
}

public sealed record ReleaseBasicInformation
{
    [JsonPropertyName("labels")]
    public required IReadOnlyList<ReleaseLabel> Labels { get; init; }

    [JsonPropertyName("formats")]
    public required IReadOnlyList<ReleaseFormat> Formats { get; init; }

    // Kept as string; Discogs may return empty string which is not a valid Uri
    [JsonPropertyName("thumb")]
    public string Thumb { get; init; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; init; } = string.Empty;

    [JsonPropertyName("artists")]
    public required IReadOnlyList<ReleaseArtist> Artists { get; init; }

    [JsonPropertyName("resource_url")]
    public Uri ResourceUrl { get; init; } = new("https://example.invalid/");

    [JsonPropertyName("year")]
    public int? Year { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }
}

public sealed record ReleaseLabel
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("entity_type")]
    public string? EntityType { get; init; }

    [JsonPropertyName("catno")]
    public string Catno { get; init; } = string.Empty;

    [JsonPropertyName("resource_url")]
    public Uri ResourceUrl { get; init; } = new("https://example.invalid/");

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("entity_type_name")]
    public string? EntityTypeName { get; init; }
}

public sealed record ReleaseFormat
{
    [JsonPropertyName("descriptions")]
    public IReadOnlyList<string>? Descriptions { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("qty")]
    public string? Quantity { get; init; }
}

public sealed record ReleaseArtist
{
    [JsonPropertyName("join")]
    public string? Join { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("anv")]
    public string? Anv { get; init; }

    [JsonPropertyName("tracks")]
    public string? Tracks { get; init; }

    [JsonPropertyName("role")]
    public string? Role { get; init; }

    [JsonPropertyName("resource_url")]
    public Uri ResourceUrl { get; init; } = new("https://example.invalid/");

    [JsonPropertyName("id")]
    public int Id { get; init; }
}


