using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

// TODO this is almost the same as UserCollectionReleasesResponse.cs - consolidate!

public sealed record UserCollectionFolderReleases
{
    [JsonPropertyName("pagination")]
    public required Pagination Pagination { get; init; }

    [JsonPropertyName("releases")]
    public required IReadOnlyList<UserCollectionFolderReleaseItem> Releases { get; init; }
}

public sealed record UserCollectionFolderReleaseItem
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("instance_id")]
    public long InstanceId { get; init; }

    [JsonPropertyName("folder_id")]
    public int FolderId { get; init; }

    [JsonPropertyName("rating")]
    public int Rating { get; init; }

    [JsonPropertyName("basic_information")]
    public required BasicReleaseInformation BasicInformation { get; init; }

    // Visible depending on auth/visibility
    [JsonPropertyName("notes")]
    public IReadOnlyList<UserCollectionNote>? Notes { get; init; }
}

public sealed record BasicReleaseInformation
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; } = string.Empty;

    [JsonPropertyName("year")]
    public int? Year { get; init; }

    [JsonPropertyName("resource_url")]
    public Uri ResourceUrl { get; init; } = new("https://example.invalid/");

    // Kept as string because API may return empty strings
    [JsonPropertyName("thumb")]
    public string Thumb { get; init; } = string.Empty;

    [JsonPropertyName("cover_image")]
    public string CoverImage { get; init; } = string.Empty;

    [JsonPropertyName("formats")]
    public required IReadOnlyList<ReleaseFormat> Formats { get; init; }

    [JsonPropertyName("labels")]
    public required IReadOnlyList<ReleaseLabel> Labels { get; init; }

    [JsonPropertyName("artists")]
    public required IReadOnlyList<ReleaseArtist> Artists { get; init; }

    [JsonPropertyName("genres")]
    public IReadOnlyList<string>? Genres { get; init; }

    [JsonPropertyName("styles")]
    public IReadOnlyList<string>? Styles { get; init; }
}

public sealed record UserCollectionNote
{
    [JsonPropertyName("field_id")]
    public int FieldId { get; init; }

    [JsonPropertyName("value")]
    public string Value { get; init; } = string.Empty;
}




