// csharp
using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed class Label
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("profile")]
    public string? Profile { get; init; }

    [JsonPropertyName("contact_info")]
    public string? ContactInfo { get; init; }

    [JsonPropertyName("uri")]
    public string? Uri { get; init; }

    [JsonPropertyName("resource_url")]
    public string? ResourceUrl { get; init; }

    [JsonPropertyName("releases_url")]
    public string? ReleasesUrl { get; init; }

    [JsonPropertyName("urls")]
    public List<string> Urls { get; init; } = [];

    [JsonPropertyName("images")]
    public List<Image> Images { get; init; } = [];

    [JsonPropertyName("sublabels")]
    public List<LabelRef> Sublabels { get; init; } = [];

    // Present when this label has a parent label
    [JsonPropertyName("parent_label")]
    public LabelRef? ParentLabel { get; init; }

    [JsonPropertyName("data_quality")]
    public string? DataQuality { get; init; }
}
