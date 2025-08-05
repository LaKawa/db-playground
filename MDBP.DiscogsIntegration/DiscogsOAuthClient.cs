using System.Diagnostics;
using System.Net;
using OAuth.OAuth1;

namespace MusicDBPlayground.DiscogsIntegration;

public class DiscogsOAuthClient : IDisposable
{
    private const string RequestTokenUrl = "https://api.discogs.com/oauth/request_token";
    private const string AccessTokenUrl = "https://api.discogs.com/oauth/access_token";
    private const string AuthorizeUrl = "https://www.discogs.com/oauth/authorize";
    private const string CallbackUrl = "http://localhost:8976/callback/";
    private readonly HttpClient _httpClient;

    private readonly HttpListener _listener;
    private readonly OAuth1Client _oauthClient;


    public DiscogsOAuthClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        _oauthClient = new OAuth1Client(
            httpClient,
            Environment.GetEnvironmentVariable("DISCOGS_CONSUMER_KEY")
            ?? throw new InvalidOperationException("DISCOGS_CONSUMER_KEY isn't set as environment variable!"),
            Environment.GetEnvironmentVariable("DISCOGS_CONSUMER_SECRET")
            ?? throw new InvalidOperationException("DISCOGS_CONSUMER_SECRET isn't set as environment variable!"),
            RequestTokenUrl,
            AccessTokenUrl,
            AuthorizeUrl,
            CallbackUrl,
            OAuthSignatureMethod.PLAINTEXT);
        
        _listener = new HttpListener();
        _listener.Prefixes.Add(CallbackUrl);
    }

    private async Task<string> ListenForVerifierCallbackAsync()
    {
        if(!_listener.IsListening) 
            _listener.Start();
        
        while (_listener.IsListening)
        {
            // TODO: add a timeout to not get stuck here
            // discogs itself needs a new request started if access token wasn't used within 15 minutes
            var context = await _listener.GetContextAsync();
            var query = context.Request.QueryString;
            
            var token = query["oauth_token"];
            var verifier = query["oauth_verifier"];

            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(verifier)) continue;
            Console.WriteLine($"Verifier received: {verifier}");
            _listener.Stop();
            return verifier;
        }
        throw new InvalidOperationException("OAuth callback listener stopped before receiving verifier!");
    }

    public async Task<OAuthToken> AuthorizeWithOAuth1()
    {
        var requestToken = await _oauthClient.GetRequestTokenAsync();
        
        var authorizeUri = _oauthClient.GetAuthorizeUri(requestToken);
        
        OpenUriInBrowser(authorizeUri);
        var verifier = await ListenForVerifierCallbackAsync();
        
        return await _oauthClient.GetAccessTokenAsync(requestToken, verifier);
    }

    private static void OpenUriInBrowser(Uri authorizeUri)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = authorizeUri.ToString(),
            UseShellExecute = true
        });
    }


    public async Task<string> GetRequestUrlWithToken()
    {
        var requestToken = await _oauthClient.GetRequestTokenAsync();
        return $"{AuthorizeUrl}?oauth_token={requestToken.Token}";
    }

    public void Dispose()
    {
        ((IDisposable)_listener).Dispose();
        GC.SuppressFinalize(this);
    }
}