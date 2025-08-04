using System.Security.Cryptography;
using System.Text;

namespace OAuth.OAuth1;

public static class OAuthHelper
{
    public static string GenerateNonce()
    {
        using var rng = RandomNumberGenerator.Create();
        var bytes = new byte[16];
        rng.GetBytes(bytes);
        var sb = new StringBuilder(32); // extra space for hexadecimal encoding
        foreach (var b in bytes)
            sb.Append(b.ToString("X2"));
        return sb.ToString();
    }

    public static string GenerateTimestamp()
    {
        var secondsSinceEpoch = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return secondsSinceEpoch.ToString();
    }

    public static bool IsValidUrl(string url) =>
        Uri.TryCreate(url, UriKind.Absolute, out _);
}