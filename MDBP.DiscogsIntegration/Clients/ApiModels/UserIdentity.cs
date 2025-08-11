using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed record UserIdentity
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("username")]
    public string Username { get; init; } = string.Empty;

    [JsonPropertyName("resource_url")]
    public Uri ResourceUrl { get; init; } = new Uri("https://example.invalid/");

    [JsonPropertyName("consumer_name")]
    public string ConsumerName { get; init; } = string.Empty;
}