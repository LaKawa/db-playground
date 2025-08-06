namespace OAuth.OAuth1.Models;

public record OAuthToken
{
    public string Token { get; init; } = "";
    public string TokenSecret { get; init; } = "";
}