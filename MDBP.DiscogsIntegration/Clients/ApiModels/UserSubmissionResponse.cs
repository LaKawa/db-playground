using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;
public sealed record UserSubmissionsResponse
{
    [JsonPropertyName("pagination")]
    public Pagination Pagination { get; init; } = new();

    [JsonPropertyName("submissions")]
    public UserSubmissionsPayload Submissions { get; init; } = new();
}

public sealed record UserSubmissionsPayload
{
    [JsonPropertyName("artists")]
    public List<UserSubmissionArtist> Artists { get; init; } = [];

    [JsonPropertyName("labels")]
    public List<UserSubmissionLabel> Labels { get; init; } = [];

    [JsonPropertyName("releases")]
    public List<UserSubmissionRelease> Releases { get; init; } = [];
}

public sealed record UserSubmissionArtist
{
    [JsonPropertyName("data_quality")]
    public string DataQuality { get; init; } = string.Empty;

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("namevariations")]
    public List<string> NameVariations { get; init; } = [];

    [JsonPropertyName("releases_url")]
    public Uri ReleasesUrl { get; init; } = new("https://example.invalid/");

    [JsonPropertyName("resource_url")]
    public Uri ResourceUrl { get; init; } = new("https://example.invalid/");

    [JsonPropertyName("uri")]
    public Uri Uri { get; init; } = new("https://example.invalid/");
}

public sealed record UserSubmissionLabel
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

public sealed record UserSubmissionRelease
{
    [JsonPropertyName("artists")]
    public List<UserSubmissionReleaseArtistRef> Artists { get; init; } = [];

    [JsonPropertyName("community")]
    public UserSubmissionReleaseCommunity Community { get; init; } = new();

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
    public List<UserSubmissionFormat> Formats { get; init; } = [];

    [JsonPropertyName("genres")]
    public List<string> Genres { get; init; } = [];

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("images")]
    public List<UserSubmissionImage> Images { get; init; } = [];

    [JsonPropertyName("labels")]
    public List<UserSubmissionLabel> Labels { get; init; } = [];

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
    public List<UserSubmissionVideo> Videos { get; init; } = [];

    [JsonPropertyName("year")]
    public int Year { get; init; }
}

public sealed record UserSubmissionReleaseArtistRef
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

public sealed record UserSubmissionReleaseCommunity
{
    [JsonPropertyName("contributors")]
    public List<UserSubmissionUserRef> Contributors { get; init; } = [];

    [JsonPropertyName("data_quality")]
    public string DataQuality { get; init; } = string.Empty;

    [JsonPropertyName("have")]
    public int Have { get; init; }

    [JsonPropertyName("rating")]
    public UserSubmissionRating Rating { get; init; } = new();

    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    [JsonPropertyName("submitter")]
    public UserSubmissionUserRef Submitter { get; init; } = new();

    [JsonPropertyName("want")]
    public int Want { get; init; }
}

public sealed record UserSubmissionUserRef
{
    [JsonPropertyName("resource_url")]
    public Uri ResourceUrl { get; init; } = new("https://example.invalid/");

    [JsonPropertyName("username")]
    public string Username { get; init; } = string.Empty;
}

public sealed record UserSubmissionRating
{
    [JsonPropertyName("average")]
    public double Average { get; init; }

    [JsonPropertyName("count")]
    public int Count { get; init; }
}

public sealed record UserSubmissionFormat
{
    [JsonPropertyName("descriptions")]
    public List<string> Descriptions { get; init; } = [];

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    // The API returns this as a string
    [JsonPropertyName("qty")]
    public string Quantity { get; init; } = string.Empty;
}

public sealed record UserSubmissionImage
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

public sealed record UserSubmissionVideo
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
