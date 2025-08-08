using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed class MasterRelease
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("main_release")]
    public int? MainRelease { get; init; }

    [JsonPropertyName("main_release_url")]
    public string? MainReleaseUrl { get; init; }

    [JsonPropertyName("uri")]
    public string? Uri { get; init; }

    [JsonPropertyName("resource_url")]
    public string? ResourceUrl { get; init; }

    [JsonPropertyName("versions_url")]
    public string? VersionsUrl { get; init; }

    [JsonPropertyName("year")]
    public int? Year { get; init; }

    [JsonPropertyName("styles")]
    public List<string> Styles { get; init; } = [];

    [JsonPropertyName("genres")]
    public List<string> Genres { get; init; } = [];

    [JsonPropertyName("videos")]
    public List<Video> Videos { get; init; } = [];

    [JsonPropertyName("artists")]
    public List<ArtistCredit> Artists { get; init; } = [];

    [JsonPropertyName("images")]
    public List<Image> Images { get; init; } = [];

    [JsonPropertyName("tracklist")]
    public List<MasterTrack> Tracklist { get; init; } = [];

    [JsonPropertyName("num_for_sale")]
    public int? NumForSale { get; init; }

    [JsonPropertyName("lowest_price")]
    public decimal? LowestPrice { get; init; }

    [JsonPropertyName("data_quality")]
    public string? DataQuality { get; init; }
}

public sealed class MasterTrack
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

    // Present on some tracks
    [JsonPropertyName("extraArtists")]
    public List<ArtistCredit> ExtraArtists { get; init; } = [];
}
