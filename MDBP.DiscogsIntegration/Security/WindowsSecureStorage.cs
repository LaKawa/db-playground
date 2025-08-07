#if NET9_0_WINDOWS
using System.Security.Cryptography;

using System.Text;

namespace MusicDBPlayground.DiscogsIntegration.Security;

public class WindowsSecureStorage : ISecureStorage
{
    private static string GetPath(string key)
    {
        var dir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "DiscogsIntegration", "Secrets");

        Directory.CreateDirectory(dir);
        return Path.Combine(dir, key);
    }

    public void Save(string key, string value)
    {
        var data = Encoding.UTF8.GetBytes(value);
        var encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
        File.WriteAllBytes(GetPath(key), encrypted);
    }

    public string Load(string key)
    {
        var path = GetPath(key);
        if (!File.Exists(path)) throw new FileNotFoundException($"Secure storage key file not found {path}");
        
        var encrypted = File.ReadAllBytes(path);
        var decrypted = ProtectedData.Unprotect(encrypted, null, DataProtectionScope.CurrentUser);
        return Encoding.UTF8.GetString(decrypted);
    }
}
#endif