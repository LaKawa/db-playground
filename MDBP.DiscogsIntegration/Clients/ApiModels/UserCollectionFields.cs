using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed record UserCollectionFields
{
    [JsonPropertyName("fields")]
    public required IReadOnlyList<UserCollectionField> Fields { get; init; }
}

public sealed record UserCollectionField
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    // Present for "dropdown" types.
    [JsonPropertyName("options")]
    public IReadOnlyList<string>? Options { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("position")]
    public int Position { get; init; }

    // e.g. "dropdown", "textarea", etc.
    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;

    [JsonPropertyName("public")]
    public bool IsPublic { get; init; }

    // Present for "textarea" types.
    [JsonPropertyName("lines")]
    public int? Lines { get; init; }
}
