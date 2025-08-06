using OAuth.OAuth1.Models;

namespace OAuth.OAuth1;

public interface IOAuthClient
{
    Task<OAuthToken> GetRequestTokenAsync();
    Uri GetAuthorizeUri(OAuthToken requestToken);
    Task<OAuthToken> GetAccessTokenAsync(OAuthToken requestToken, string verifier);
    void SignRequest(HttpRequestMessage request, OAuthToken accessToken, string httpMethod);
}