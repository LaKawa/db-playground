using OAuth.OAuth1;

namespace MusicDBPlayground.DiscogsIntegration;

public class DiscogsOAuthClient(HttpClient httpClient)
{
    private const string RequestTokenUrl = "https://api.discogs.com/oauth/request_token";
    private const string AccessTokenUrl = "https://api.discogs.com/oauth/access_token";
    private const string AuthorizeUrl = "https://www.discogs.com/oauth/authorize";
    private const string CallbackUrl = "http://localhost:8976/callback";

    private readonly OAuth1Client _authClient = new OAuth1Client(
        httpClient,
        Environment.GetEnvironmentVariable("DISCOGS_CONSUMER_KEY")
            ?? throw new InvalidOperationException("DISCOGS_CONSUMER_KEY isn't set as environment variable!"),
        Environment.GetEnvironmentVariable("DISCOGS_CONSUMER_SECRET")
            ?? throw new InvalidOperationException("DISCOGS_CONSUMER_SECRET is not set as environment variable!"),
        RequestTokenUrl,
        AccessTokenUrl,
        AuthorizeUrl,
        CallbackUrl,
        OAuthSignatureMethod.PLAINTEXT);
    
    public async Task<string> GetRequestTokenAsync()
    {
        throw new NotImplementedException();
    } 
}