using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace MusicDBPlayground.DiscogsIntegration.Security;

public class LocalKeyProvider(ISecureStorage secureStorage)
{
    private const string KeyFileName = ".discogs_aes.key";

    public string GetOrCreateKey()
    {
        try
        {
            var key = secureStorage.Load(KeyFileName);
            if (!string.IsNullOrEmpty(key))
                return key;
        }
        catch (FileNotFoundException)
        {
            var keyBytes = RandomNumberGenerator.GetBytes(32);
            var base64Key = Convert.ToBase64String(keyBytes);
            secureStorage.Save(KeyFileName, base64Key);
            return base64Key;
        }

        throw new InvalidOperationException("Wasn't able to create new, or load existing key!");
    }
}