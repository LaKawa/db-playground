using System.Diagnostics;
using System.Net;
using OAuth.OAuth1;
using OAuth.OAuth1.Models;

namespace MusicDBPlayground.DiscogsIntegration.Clients;

public class DiscogsOAuthClient : IDisposable
{
    private const string RequestTokenUrl = "https://api.discogs.com/oauth/request_token";
    private const string AccessTokenUrl = "https://api.discogs.com/oauth/access_token";
    private const string AuthorizeUrl = "https://www.discogs.com/oauth/authorize";
    private const string CallbackUrl = "http://localhost:8976/callback/";
    private readonly HttpClient _httpClient;

    private readonly HttpListener _listener;
    private readonly OAuthClient _oauthClient;

    private const string ProductName = "DiscogsCollectionSync";
    private const string ProductVersion = "0.1";


    public OAuthToken? AccessToken { get; private set; }

    public void SetAccessToken(OAuthToken token)
    {
        if (AccessToken != null)
            throw new InvalidOperationException("AccessToken is already set and cannot be overwritten.");
        AccessToken = token;
    }


    public DiscogsOAuthClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd($"{ProductName}/{ProductVersion}");
        
        _oauthClient = new OAuthClient(
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
        
        AccessToken = await _oauthClient.GetAccessTokenAsync(requestToken, verifier);
        return AccessToken;
    }

    public void SignRequest(HttpRequestMessage request)
    {
        if (AccessToken == null) throw new InvalidOperationException("Access token is not set!");
        _oauthClient.SignRequest(request, AccessToken, request.Method.ToString());
    }
    
    private static void OpenUriInBrowser(Uri authorizeUri)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = authorizeUri.ToString(),
            UseShellExecute = true
        });
    }

    public void Dispose()
    {
        ((IDisposable)_listener).Dispose();
        GC.SuppressFinalize(this);
    }
}