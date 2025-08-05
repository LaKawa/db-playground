using System.Net.Http.Headers;
using System.Text;

namespace OAuth.OAuth1;

// TODO: could add a facade service class to start authorization to hide internals
public class OAuth1Client : IOAuthClient
{
    private readonly HttpClient _client;
    private readonly string _consumerKey;
    private readonly string _consumerSecret;
    private readonly string _requestTokenUrl;
    private readonly string _accessTokenUrl;
    private readonly string _authorizeUrl;
    private readonly string _callbackUrl;
    private readonly OAuthSignatureMethod _signatureMethod;

    private const string ProductName = "DiscogsCollectionSync";
    private const string ProductVersion = "0.1"; // get this from config file?

    public OAuth1Client(HttpClient client,
        string consumerKey,
        string consumerSecret,
        string requestTokenUrl,
        string accessTokenUrl,
        string authorizeUrl,
        string callbackUrl,
        OAuthSignatureMethod signatureMethod)
    {
        ValidateInputData(client, consumerKey, consumerSecret, requestTokenUrl, accessTokenUrl, authorizeUrl, callbackUrl, signatureMethod);
        
        _client = client;
        _consumerKey = consumerKey;
        _consumerSecret = consumerSecret;
        _requestTokenUrl = requestTokenUrl;
        _accessTokenUrl = accessTokenUrl;
        _authorizeUrl = authorizeUrl;
        _callbackUrl = callbackUrl;
        _signatureMethod = signatureMethod;
    }

    private static void ValidateInputData(HttpClient client, string consumerKey, string consumerSecret, string requestTokenUrl,
        string accessTokenUrl, string authorizeUrl, string callbackUrl, OAuthSignatureMethod signatureMethod)
    {
        ArgumentNullException.ThrowIfNull(client);
        if (string.IsNullOrWhiteSpace(consumerKey)) throw new ArgumentException("Consumer key is required!");
        if (string.IsNullOrWhiteSpace(consumerSecret)) throw new ArgumentException("Consumer secret is required!");
        
        if (!OAuthHelper.IsValidUrl(requestTokenUrl)) throw new ArgumentException("Invalid request token URL!", nameof(requestTokenUrl));
        if (!OAuthHelper.IsValidUrl(accessTokenUrl)) throw new ArgumentException("Invalid access token URL!", nameof(accessTokenUrl));
        if (!OAuthHelper.IsValidUrl(authorizeUrl)) throw new ArgumentException("Invalid authorize URL!", nameof(authorizeUrl));
        if (!OAuthHelper.IsValidUrl(callbackUrl)) throw new ArgumentException("Invalid callback URL!", nameof(callbackUrl));
        
        if(!Enum.IsDefined(signatureMethod))
            throw new ArgumentOutOfRangeException(nameof(signatureMethod), "Invalid OAuth signature method!");
    }

    public async Task AuthorizeWithOAuth1()
    {
        var oAuthToken = await GetRequestTokenAsync();
        var authorizeUri = GetAuthorizeUri(oAuthToken);
        // open browser with uri
        
        //var verifier = await
    }

    public async Task<OAuthToken> GetRequestTokenAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, _requestTokenUrl);
        
        var authHeader = BuildAuthorizationHeader(
            token: null,
            tokenSecret: null,
            callbackUrl: _callbackUrl,
            verifier: null,
            httpMethod: "GET",
            url: _requestTokenUrl);
        request.Headers.Authorization = new AuthenticationHeaderValue("OAuth", authHeader);
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue(ProductName, ProductVersion));
        
        
        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode(); // could handle this gracefully without throwing?

        var content = await response.Content.ReadAsStringAsync();

        var values = OAuthHelper.ParseQueryString(content);

        if (!values.TryGetValue("oauth_token", out var token) ||
            !values.TryGetValue("oauth_token_secret", out var tokenSecret) ||
            !values.TryGetValue("oauth_callback_confirmed", out var callbackConfirmed) ||
            callbackConfirmed != "true")
            throw new InvalidOperationException("Invalid response from request token endpoint despite 200(OK) response code!");

        return new OAuthToken
        {
            Token = token,
            TokenSecret = tokenSecret,
        };
    }

   
    public Uri GetAuthorizeUri(OAuthToken requestToken)
    {
        return new Uri($"{_authorizeUrl}?oauth_token={requestToken.Token}");
    }
    
    public async Task<OAuthToken> GetAccessTokenAsync(OAuthToken requestToken, string verifier)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, _accessTokenUrl);
        
        var oAuthHeader = BuildAuthorizationHeader(
            token: requestToken.Token,
            tokenSecret: requestToken.TokenSecret,
            callbackUrl: null,
            verifier: verifier,
            httpMethod: "POST",
            url: _accessTokenUrl);
        request.Headers.Authorization = new AuthenticationHeaderValue("OAuth", oAuthHeader);
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue(ProductName, ProductVersion));
       
        var response = await _client.SendAsync(request);
        
        response.EnsureSuccessStatusCode();
        throw new NotImplementedException();
    }

    public void SignRequest(HttpRequestMessage request, OAuthToken accessToken, string httpMethod)
    {
        throw new NotImplementedException();
    }

    public string BuildAuthorizationHeader(
        string? token,
        string? tokenSecret,
        string? callbackUrl,
        string? verifier,
        // TODO: needed for HMACSHA1 signature
        string httpMethod,
        string url)
    {
        var nonce = OAuthHelper.GenerateNonce();
        var timestamp = OAuthHelper.GenerateTimestamp();

        var parameters = new Dictionary<string, string>
        {
            ["oauth_consumer_key"] = _consumerKey,
            ["oauth_nonce"] = nonce,
            ["oauth_signature_method"] = _signatureMethod.ToString(),
            ["oauth_timestamp"] = timestamp,
            ["oauth_version"] = "1.0"
        };

        if (!string.IsNullOrEmpty(callbackUrl))
            parameters["oauth_callback"] = callbackUrl;
        if (!string.IsNullOrEmpty(verifier))
            parameters["oauth_verifier"] = verifier;
        if (!string.IsNullOrEmpty(token))
            parameters["oauth_token"] = token;

        var signature = _signatureMethod switch
        {
            OAuthSignatureMethod.PLAINTEXT =>
                $"{_consumerSecret}&{tokenSecret ?? string.Empty}",
            OAuthSignatureMethod.HMACSHA1 =>
                throw new NotImplementedException("HMAC-SHA1 is not implemented yet"),
            _ => throw new NotSupportedException("Unsupported OAuth signature method"),
        };
        parameters["oauth_signature"] = signature;

        // TODO: needs to be sorted when we implement HMACSHA1
        var headerParams = parameters
            .Where(kvp => kvp.Key.StartsWith("oauth_"))
            .Select(kvp => $"{kvp.Key}=\"{kvp.Value}\"");
                // ? $"{kvp.Key}=\"{Uri.EscapeDataString(kvp.Value)}\""
                    //: $"{kvp.Key}=\"{kvp.Value}\"");
        
        var header = string.Join(", ", headerParams);
        
        return header;
    }
}