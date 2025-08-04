using System.Net.Http.Headers;
using System.Text;

namespace OAuth.OAuth1;

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

    public async Task<OAuthToken> GetRequestTokenAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, _requestTokenUrl);
       // request.Content = new StringContent("Content-Type", Encoding.UTF8, "application/x-www-form-urlencoded");
        
        var authHeader = BuildAuthorizationHeader(
            token: null,
            tokenSecret: null,
            callbackUrl: _callbackUrl,
            verifier: null,
            httpMethod: "GET",
            url: _requestTokenUrl);
        request.Headers.Authorization = new AuthenticationHeaderValue("OAuth", authHeader.Replace("OAuth ", ""));
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("DiscogsCollectionSync", "0.1"));
        
        var response = await _client.SendAsync(request);
        
        Console.WriteLine(response.StatusCode);
        
        // handle response here!
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
            //["oauth_version"] = "1.0"
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
        
        var header = "OAuth " + string.Join(", ", headerParams);
        
        return header;
    }
}