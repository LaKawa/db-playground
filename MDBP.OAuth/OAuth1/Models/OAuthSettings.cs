namespace OAuth.OAuth1.Models;
internal record OAuthSettings
{
    public string Url { get; init; }
    public string ConsumerKey { get; init; }
    public string ConsumerSecret { get; init; }
    public HttpMethod HttpMethod { get; init; } = HttpMethod.Get;
    public OAuthSignatureMethod OAuthSignatureMethod { get; init; } = OAuthSignatureMethod.PLAINTEXT;
    public string? Token { get; init; }
    public string? TokenSecret { get; init; }
    public string? CallbackUrl { get; init; }
    public string? Verifier { get; init; }

    public OAuthSettings(
        string url,
        string consumerKey,
        string consumerSecret,
        HttpMethod? httpMethod = null,
        OAuthSignatureMethod oAuthSignatureMethod = OAuthSignatureMethod.PLAINTEXT,
        string? token = null,
        string? tokenSecret = null,
        string? callbackUrl = null,
        string? verifier = null)
    {
        Url = url;
        ConsumerKey = consumerKey;
        ConsumerSecret = consumerSecret;
        HttpMethod = httpMethod ?? HttpMethod.Get;
        OAuthSignatureMethod = oAuthSignatureMethod;
        Token = token;
        TokenSecret = tokenSecret;
        CallbackUrl = callbackUrl;
        Verifier = verifier;
    }
}

