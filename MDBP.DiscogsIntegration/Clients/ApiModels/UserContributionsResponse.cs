namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public sealed record UserContributionsResponse
{
    [JsonPropertyName("contributions")]
    public List<UserContributionRelease> Contributions { get; init; } = [];

    [JsonPropertyName("pagination")]
    public Pagination Pagination { get; init; } = new();
}


public sealed record UserContributionRelease
{
    [JsonPropertyName("artists")]
    public List<UserContributionReleaseArtistRef> Artists { get; init; } = [];

    [JsonPropertyName("community")]
    public UserContributionReleaseCommunity Community { get; init; } = new();

    [JsonPropertyName("companies")]
    public List<object> Companies { get; init; } = []; // Not detailed in sample

    [JsonPropertyName("country")]
    public string Country { get; init; } = string.Empty;

    [JsonPropertyName("data_quality")]
    public string DataQuality { get; init; } = string.Empty;

    [JsonPropertyName("date_added")]
    public DateTimeOffset DateAdded { get; init; }

    [JsonPropertyName("date_changed")]
    public DateTimeOffset DateChanged { get; init; }

    [JsonPropertyName("estimated_weight")]
    public int EstimatedWeight { get; init; }

    [JsonPropertyName("format_quantity")]
    public int FormatQuantity { get; init; }

    [JsonPropertyName("formats")]
    public List<UserContributionFormat> Formats { get; init; } = [];

    [JsonPropertyName("genres")]
    public List<string> Genres { get; init; } = [];

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("images")]
    public List<UserContributionImage> Images { get; init; } = [];

    [JsonPropertyName("labels")]
    public List<UserContributionLabel> Labels { get; init; } = [];

    [JsonPropertyName("master_id")]
    public long? MasterId { get; init; }

    [JsonPropertyName("master_url")]
    public Uri? MasterUrl { get; init; }

    [JsonPropertyName("notes")]
    public string? Notes { get; init; }

    [JsonPropertyName("released")]
    public string? Released { get; init; }

    [JsonPropertyName("released_formatted")]
    public string? ReleasedFormatted { get; init; }

    [JsonPropertyName("resource_url")]
    public Uri ResourceUrl { get; init; } = new("https://example.invalid/");

    [JsonPropertyName("series")]
    public List<object> Series { get; init; } = []; // Not detailed in sample

    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    [JsonPropertyName("styles")]
    public List<string> Styles { get; init; } = [];

    [JsonPropertyName("thumb")]
    public Uri? Thumb { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; } = string.Empty;

    [JsonPropertyName("uri")]
    public Uri Uri { get; init; } = new("https://example.invalid/");

    [JsonPropertyName("videos")]
    public List<UserContributionVideo> Videos { get; init; } = [];

    [JsonPropertyName("year")]
    public int Year { get; init; }
}

public sealed record UserContributionReleaseArtistRef
{
    [JsonPropertyName("anv")]
    public string Anv { get; init; } = string.Empty;

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("join")]
    public string Join { get; init; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("resource_url")]
    public Uri ResourceUrl { get; init; } = new("https://example.invalid/");

    [JsonPropertyName("role")]
    public string Role { get; init; } = string.Empty;

    [JsonPropertyName("tracks")]
    public string Tracks { get; init; } = string.Empty;
}

public sealed record UserContributionReleaseCommunity
{
    [JsonPropertyName("contributors")]
    public List<UserContributionUserRef> Contributors { get; init; } = [];

    [JsonPropertyName("data_quality")]
    public string DataQuality { get; init; } = string.Empty;

    [JsonPropertyName("have")]
    public int Have { get; init; }

    [JsonPropertyName("rating")]
    public UserContributionRating Rating { get; init; } = new();

    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    [JsonPropertyName("submitter")]
    public UserContributionUserRef Submitter { get; init; } = new();

    [JsonPropertyName("want")]
    public int Want { get; init; }
}

public sealed record UserContributionUserRef
{
    [JsonPropertyName("resource_url")]
    public Uri ResourceUrl { get; init; } = new("https://example.invalid/");

    [JsonPropertyName("username")]
    public string Username { get; init; } = string.Empty;
}

public sealed record UserContributionRating
{
    [JsonPropertyName("average")]
    public double Average { get; init; }

    [JsonPropertyName("count")]
    public int Count { get; init; }
}

public sealed record UserContributionFormat
{
    [JsonPropertyName("descriptions")]
    public List<string> Descriptions { get; init; } = [];

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    // The API returns this as a string
    [JsonPropertyName("qty")]
    public string Quantity { get; init; } = string.Empty;
}

public sealed record UserContributionImage
{
    [JsonPropertyName("height")]
    public int Height { get; init; }

    [JsonPropertyName("resource_url")]
    public Uri ResourceUrl { get; init; } = new("https://example.invalid/");

    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;

    [JsonPropertyName("uri")]
    public Uri Uri { get; init; } = new("https://example.invalid/");

    [JsonPropertyName("uri150")]
    public Uri Uri150 { get; init; } = new("https://example.invalid/");

    [JsonPropertyName("width")]
    public int Width { get; init; }
}

public sealed record UserContributionVideo
{
    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    [JsonPropertyName("duration")]
    public int Duration { get; init; }

    [JsonPropertyName("embed")]
    public bool Embed { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; } = string.Empty;

    [JsonPropertyName("uri")]
    public Uri Uri { get; init; } = new("https://example.invalid/");
}

public sealed record UserContributionLabel
{
    [JsonPropertyName("catno")]
    public string CatNo { get; init; } = string.Empty;

    // In the sample this is a string value like "1"
    [JsonPropertyName("entity_type")]
    public string EntityType { get; init; } = string.Empty;

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("resource_url")]
    public Uri ResourceUrl { get; init; } = new("https://example.invalid/");
}
