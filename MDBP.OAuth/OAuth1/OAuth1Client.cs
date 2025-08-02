namespace OAuth.OAuth1;

public class OAuth1Client(
    HttpClient client,
    string consumerKey,
    string consumerSecret,
    string requestTokenUrl,
    string accessTokenUrl,
    string authorizeUrl)
    : IOAuthClient
{

public async Task<OAuthToken> GetRequestTokenAsync()
{
    var response = await client.GetAsync(requestTokenUrl);
        throw new NotImplementedException();
    }

    public Uri GetAuthorizeUrl(OAuthToken requestToken)
    {
        throw new NotImplementedException();
    }

    public Task<OAuthToken> GetAccessTokenAsync(OAuthToken requestToken, string verifier)
    {
        throw new NotImplementedException();
    }

    public void SignRequest(HttpRequestMessage request, OAuthToken accessToken, string httpMethod)
    {
        throw new NotImplementedException();
    }
}