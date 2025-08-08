using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed class Release
{
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("artists")]
    public List<ArtistCredit> Artists { get; init; } = [];

    [JsonPropertyName("data_quality")]
    public string? DataQuality { get; init; }

    [JsonPropertyName("thumb")]
    public string? Thumb { get; init; }

    [JsonPropertyName("community")]
    public Community? Community { get; init; }

    [JsonPropertyName("companies")]
    public List<CompanyRef> Companies { get; init; } = [];

    [JsonPropertyName("country")]
    public string? Country { get; init; }

    [JsonPropertyName("date_added")]
    public DateTimeOffset? DateAdded { get; init; }

    [JsonPropertyName("date_changed")]
    public DateTimeOffset? DateChanged { get; init; }

    [JsonPropertyName("estimated_weight")]
    public int? EstimatedWeight { get; init; }

    [JsonPropertyName("extraartists")]
    public List<ArtistCredit> ExtraArtists { get; init; } = [];

    [JsonPropertyName("format_quantity")]
    public int? FormatQuantity { get; init; }

    [JsonPropertyName("formats")]
    public List<Format> Formats { get; init; } = [];

    [JsonPropertyName("genres")]
    public List<string> Genres { get; init; } = [];

    [JsonPropertyName("identifiers")]
    public List<Identifier> Identifiers { get; init; } = [];

    [JsonPropertyName("images")]
    public List<Image> Images { get; init; } = [];

    [JsonPropertyName("labels")]
    public List<LabelRef> Labels { get; init; } = [];

    [JsonPropertyName("lowest_price")]
    public decimal? LowestPrice { get; init; }

    [JsonPropertyName("master_id")]
    public int? MasterId { get; init; }

    [JsonPropertyName("master_url")]
    public string? MasterUrl { get; init; }

    [JsonPropertyName("notes")]
    public string? Notes { get; init; }

    [JsonPropertyName("num_for_sale")]
    public int? NumForSale { get; init; }

    // Discogs "released" can be a year or full date as string (e.g. "1987", "1987-07-27")
    [JsonPropertyName("released")]
    public string? Released { get; init; }

    [JsonPropertyName("released_formatted")]
    public string? ReleasedFormatted { get; init; }

    [JsonPropertyName("resource_url")]
    public string? ResourceUrl { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("styles")]
    public List<string> Styles { get; init; } = [];

    [JsonPropertyName("tracklist")]
    public List<Track> Tracklist { get; init; } = [];

    [JsonPropertyName("uri")]
    public string? Uri { get; init; }

    [JsonPropertyName("videos")]
    public List<Video> Videos { get; init; } = [];

    [JsonPropertyName("year")]
    public int? Year { get; init; }
}

public sealed class ArtistCredit
{
    [JsonPropertyName("anv")]
    public string? Anv { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("join")]
    public string? Join { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("resource_url")]
    public string? ResourceUrl { get; init; }

    [JsonPropertyName("role")]
    public string? Role { get; init; }

    [JsonPropertyName("tracks")]
    public string? Tracks { get; init; }
}

public sealed class Community
{
    [JsonPropertyName("contributors")]
    public List<UserRef> Contributors { get; init; } = [];

    [JsonPropertyName("data_quality")]
    public string? DataQuality { get; init; }

    [JsonPropertyName("have")]
    public int? Have { get; init; }

    [JsonPropertyName("rating")]
    public Rating? Rating { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("submitter")]
    public UserRef? Submitter { get; init; }

    [JsonPropertyName("want")]
    public int? Want { get; init; }
}

public sealed class UserRef
{
    [JsonPropertyName("resource_url")]
    public string? ResourceUrl { get; init; }

    [JsonPropertyName("username")]
    public string? Username { get; init; }
}

public sealed class CompanyRef
{
    [JsonPropertyName("catno")]
    public string? Catno { get; init; }

    // Discogs sends this as a string
    [JsonPropertyName("entity_type")]
    public string? EntityType { get; init; }

    [JsonPropertyName("entity_type_name")]
    public string? EntityTypeName { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("resource_url")]
    public string? ResourceUrl { get; init; }
}

public sealed class LabelRef
{
    [JsonPropertyName("catno")]
    public string? Catno { get; init; }

    [JsonPropertyName("entity_type")]
    public string? EntityType { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("resource_url")]
    public string? ResourceUrl { get; init; }
}

public sealed class Format
{
    [JsonPropertyName("descriptions")]
    public List<string> Descriptions { get; init; } = [];

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    // Discogs uses string for quantities
    [JsonPropertyName("qty")]
    public string? Qty { get; init; }
}

public sealed class Identifier
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("value")]
    public string? Value { get; init; }
}

public sealed class Image
{
    [JsonPropertyName("height")]
    public int? Height { get; init; }

    [JsonPropertyName("resource_url")]
    public string? ResourceUrl { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("uri")]
    public string? Uri { get; init; }

    [JsonPropertyName("uri150")]
    public string? Uri150 { get; init; }

    [JsonPropertyName("width")]
    public int? Width { get; init; }
}

public sealed class Track
{
    [JsonPropertyName("duration")]
    public string? Duration { get; init; }

    [JsonPropertyName("position")]
    public string? Position { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    // Discogs uses "type_" in JSON
    [JsonPropertyName("type_")]
    public string? Type { get; init; }
}

public sealed class Video
{
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("duration")]
    public int? Duration { get; init; }

    [JsonPropertyName("embed")]
    public bool? Embed { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("uri")]
    public string? Uri { get; init; }
}