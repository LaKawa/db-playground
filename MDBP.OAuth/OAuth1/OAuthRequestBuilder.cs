using System.Net.Http.Headers;
using OAuth.OAuth1.Models;

namespace OAuth.OAuth1;

internal static class OAuthRequestBuilder
{
    internal static HttpRequestMessage BuildHttpRequestMessage(OAuthRequestSettings settings)
    {
        var request = new HttpRequestMessage(settings.HttpMethod, settings.Url);

        var authHeader = BuildAuthorizationHeader(settings);
        
        request.Headers.Authorization = new AuthenticationHeaderValue("OAuth", authHeader);
        return request;
    }

    private static string BuildAuthorizationHeader(OAuthRequestSettings settings)
    {
        var nonce = OAuthUtils.GenerateNonce();
        var timestamp = OAuthUtils.GenerateTimestamp();
        
        var parameters = new Dictionary<string, string>
        {
            ["oauth_consumer_key"] = settings.ConsumerKey,
            ["oauth_nonce"] = nonce,
            ["oauth_signature_method"] = settings.OAuthSignatureMethod.ToString(),
            ["oauth_timestamp"] = timestamp,
            ["oauth_version"] = "1.0"
        };
        
        if (!string.IsNullOrEmpty(settings.CallbackUrl))
            parameters["oauth_callback"] = settings.CallbackUrl;
        if (!string.IsNullOrEmpty(settings.Verifier))
            parameters["oauth_verifier"] = settings.Verifier;
        if (!string.IsNullOrEmpty(settings.Token))
            parameters["oauth_token"] = settings.Token;
        
        var signature = settings.OAuthSignatureMethod switch
        {
            OAuthSignatureMethod.PLAINTEXT => 
                $"{settings.ConsumerSecret}&{settings.TokenSecret ?? string.Empty}",
            OAuthSignatureMethod.HMACSHA1 =>
                throw new NotImplementedException("HMAC-SHA1 is not implemented yet"),
            _ => throw new NotSupportedException("Unsupported OAuth signature method"),
        };
        parameters["oauth_signature"] = signature;
            
        // TODO: needs to be sorted when we implement HMACSHA1
        var headerParams = parameters
            .Where(kvp => kvp.Key.StartsWith("oauth_"))
            .Select(kvp => $"{kvp.Key}=\"{kvp.Value}\"");
                    
        var header = string.Join(", ", headerParams);
                
        return header;
    }
}