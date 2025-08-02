using System.Net.Http.Headers;

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
    // TODO: add exception-handling for faulty Url's if needed
    var request = new HttpRequestMessage(HttpMethod.Get, requestTokenUrl);
    request.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
    // TODO: generate authorization headers - adding discogs specific parts in integration class lib rn
    request.Headers.Authorization = new AuthenticationHeaderValue("TODO");
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