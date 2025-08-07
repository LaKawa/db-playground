using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace MusicDBPlayground.DiscogsIntegration.Security;

public class LocalKeyProvider
{
    private const string KeyFileName = ".discogs_aes.key";

    public static string GetOrCreateKey()
    {
        var keyFilePath = GetKeyFilePath();
        
        if(File.Exists(keyFilePath))
            return File.ReadAllText(keyFilePath);
        
        var keyBytes = RandomNumberGenerator.GetBytes(32);
        var base64Key = Convert.ToBase64String(keyBytes);

        Directory.CreateDirectory(Path.GetDirectoryName(keyFilePath)!);
        
        File.WriteAllText(keyFilePath, base64Key);
        
        if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            File.SetAttributes(keyFilePath, File.GetAttributes(keyFilePath) | FileAttributes.Hidden);
        
        return base64Key;
    }

    private static string GetKeyFilePath()
    {
        string baseDir;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            baseDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(baseDir, "DiscogsIntegration", KeyFileName);
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            baseDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(baseDir, "DiscogsIntegration", KeyFileName);
        }

        baseDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), ".config");
        return Path.Combine(baseDir, "discogs-integration", KeyFileName);
    }
}