using System.Net.Http.Headers;
using OAuth.OAuth1.Models;

namespace OAuth.OAuth1;

internal static class OAuthRequestBuilder
{
    internal static HttpRequestMessage BuildHttpRequestMessage(OAuthSettings settings)
    {
        var request = new HttpRequestMessage(settings.HttpMethod, settings.Url);

        var authHeader = OAuthRequestSigner.BuildAuthorizationHeader(settings);
        
        request.Headers.Authorization = new AuthenticationHeaderValue("OAuth", authHeader);
        return request;
    }
}