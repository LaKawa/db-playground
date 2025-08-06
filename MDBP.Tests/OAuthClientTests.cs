using System.Net;
using OAuth.OAuth1;
using OAuth.OAuth1.Models;

namespace MDBP.Tests;

public class OAuthClientTests
{
    [Fact]
    public void BuildAuthorizationHeader_Plaintext_ReturnsHeader()
    {
        var client = new HttpClient();
        var oAuthClient = new OAuthClient(
            client,
            "testKey",
            "testSecret",
            "https://api.discogs.com/oauth/request_token",
            "https://api.discogs.com/oauth/access_token",
            "https://www.discogs.com/oauth/authorize",
            "http://localhost:8976/callback",
            OAuthSignatureMethod.PLAINTEXT);

        var header = oAuthClient.BuildAuthorizationHeader(
            token: null,
            tokenSecret: null,
            callbackUrl: "http://localhost:8976/callback",
            verifier: null,
            httpMethod: "GET",
            url: "https://api.discogs.com/oauth/request_token");
        
        Assert.Contains("oauth_signature_method=\"PLAINTEXT\"", header);
        Assert.Contains("oauth_consumer_key=\"testKey\"", header);
        Assert.Contains($"oauth_signature=\"{Uri.EscapeDataString("testSecret&")}\"", header);
        Assert.Contains($"oauth_callback=\"{Uri.EscapeDataString("http://localhost:8976/callback")}\"", header);
    }
        
}
