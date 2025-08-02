namespace OAuth.OAuth1;

public class OAuthToken
{
    public string Token { get; set; } = "";
    public string TokenSecret { get; set; } = "";
    public string Verifier { get; set; } = "";
}