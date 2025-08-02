namespace OAuth.OAuth1;

public class OAuthHelper
{
    public static string GenerateNonce()
    {
        throw new NotImplementedException();
    }

    public static string GenerateTimestamp()
    {
        throw new NotImplementedException();
    }

    public static bool IsValidUrl(string url) =>
        Uri.TryCreate(url, UriKind.Absolute, out _);
}