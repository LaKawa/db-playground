using OAuth.OAuth1.Models;

namespace OAuth.OAuth1;

// TODO: could add a facade service class to start authorization to hide internals

public class OAuthClient : IOAuthClient
{
    private readonly HttpClient _client;
    private readonly OAuthRequestSettings _requestTokenSettings;
    private readonly string _accessTokenUrl;
    private readonly string _authorizeUrl;

    public OAuthClient(HttpClient client,
        string consumerKey,
        string consumerSecret,
        string requestTokenUrl,
        string accessTokenUrl,
        string authorizeUrl,
        string callbackUrl,
        OAuthSignatureMethod oAuthSignatureMethod)
    {
        ValidateInputData(client, consumerKey, consumerSecret, requestTokenUrl, accessTokenUrl, authorizeUrl,
            callbackUrl, oAuthSignatureMethod);

        // initial state for 1st oAuth token request
        _requestTokenSettings = new OAuthRequestSettings(
            url: requestTokenUrl,
            consumerKey,
            consumerSecret,
            httpMethod: HttpMethod.Get,
            oAuthSignatureMethod,
            callbackUrl: callbackUrl);

        _client = client;
        _accessTokenUrl = accessTokenUrl;
        _authorizeUrl = authorizeUrl;
    }

    private static void ValidateInputData(HttpClient client, string consumerKey, string consumerSecret,
        string requestTokenUrl,
        string accessTokenUrl, string authorizeUrl, string callbackUrl, OAuthSignatureMethod oAuthSignatureMethod)
    {
        ArgumentNullException.ThrowIfNull(client);
        if (string.IsNullOrWhiteSpace(consumerKey)) throw new ArgumentException("Consumer key is required!");
        if (string.IsNullOrWhiteSpace(consumerSecret)) throw new ArgumentException("Consumer secret is required!");

        if (!OAuthUtils.IsValidUrl(requestTokenUrl))
            throw new ArgumentException("Invalid request token URL!", nameof(requestTokenUrl));
        if (!OAuthUtils.IsValidUrl(accessTokenUrl))
            throw new ArgumentException("Invalid access token URL!", nameof(accessTokenUrl));
        if (!OAuthUtils.IsValidUrl(authorizeUrl))
            throw new ArgumentException("Invalid authorize URL!", nameof(authorizeUrl));
        if (!OAuthUtils.IsValidUrl(callbackUrl))
            throw new ArgumentException("Invalid callback URL!", nameof(callbackUrl));

        if (!Enum.IsDefined(oAuthSignatureMethod))
            throw new ArgumentOutOfRangeException(nameof(oAuthSignatureMethod), "Invalid OAuth signature method!");
    }


    public async Task<OAuthToken> GetRequestTokenAsync()
    {
        var request = OAuthRequestBuilder.BuildHttpRequestMessage(_requestTokenSettings);

        var response = await _client.SendAsync(request);

        return await OAuthResponseParser.ParseTokenResponseAsync(response, TokenRequestType.RequestToken);
    }

    public async Task<OAuthToken> GetAccessTokenAsync(OAuthToken requestToken, string verifier)
    {
        var accessTokenRequestSettings = _requestTokenSettings with
        {
            HttpMethod = HttpMethod.Post,
            Token = requestToken.Token,
            TokenSecret = requestToken.TokenSecret,
            Verifier = verifier,
            Url = _accessTokenUrl,
            CallbackUrl = null
        };
        var request = OAuthRequestBuilder.BuildHttpRequestMessage(accessTokenRequestSettings);

        var response = await _client.SendAsync(request);

        return await OAuthResponseParser.ParseTokenResponseAsync(response, TokenRequestType.AccessToken);
    }

    public void SignRequest(HttpRequestMessage request, OAuthToken accessToken, string httpMethod)
    {
        throw new NotImplementedException();
    }


    public Uri GetAuthorizeUri(OAuthToken requestToken)
    {
        return new Uri($"{_authorizeUrl}?oauth_token={requestToken.Token}");
    }
}