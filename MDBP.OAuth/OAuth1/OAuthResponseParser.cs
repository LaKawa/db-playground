using OAuth.OAuth1.Models;

namespace OAuth.OAuth1;

internal static class OAuthResponseParser
{
    internal static async Task<OAuthToken> ParseTokenResponseAsync(HttpResponseMessage response, TokenRequestType requestType)
    {
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var values = OAuthUtils.ParseQueryString(content);

        if (!values.TryGetValue("oauth_token", out var token) ||
            !values.TryGetValue("oauth_token_secret", out var tokenSecret))
            throw new InvalidOperationException(
                $"Invalid {requestType} response from OAuth token endpoint despite 200(OK) code!");

        // ReSharper disable once InvertIf
        if (requestType == TokenRequestType.RequestToken)
            if (!values.TryGetValue("oauth_callback_confirmed", out var callbackConfirmed)
                || callbackConfirmed != "true")
                throw new InvalidOperationException(
                    "Oauth callback wasn't confirmed from server despite 200(OK) code!");

        return new OAuthToken
        {
            Token = token,
            TokenSecret = tokenSecret
        };
    }
}