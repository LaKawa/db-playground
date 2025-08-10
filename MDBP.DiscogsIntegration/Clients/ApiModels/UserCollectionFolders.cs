using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed record UserCollectionFolders
{
    [JsonPropertyName("folders")]
    public required IReadOnlyList<UserCollectionFolder> Folders { get; init; }
}

public sealed record UserCollectionFolder
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("count")]
    public int Count { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("resource_url")]
    public Uri ResourceUrl { get; init; } = new Uri("https://example.invalid/");
}