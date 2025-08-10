// csharp
using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed record AddToCollectionFolderResponse
{
    [JsonPropertyName("instance_id")]
    public long InstanceId { get; init; }

    [JsonPropertyName("resource_url")]
    public Uri ResourceUrl { get; init; } = new("https://example.invalid/");
}