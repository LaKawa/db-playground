namespace OAuth.OAuth1;

public interface IOAuthClient
{
    Task<OAuthToken> GetRequestTokenAsync();
    Uri GetAuthorizeUrl(OAuthToken requestToken);
    Task<OAuthToken> GetAccessTokenAsync(OAuthToken requestToken, string verifier);
    void SignRequest(HttpRequestMessage request, OAuthToken accessToken, string httpMethod);
}