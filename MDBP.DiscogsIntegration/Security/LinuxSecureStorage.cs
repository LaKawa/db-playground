namespace MusicDBPlayground.DiscogsIntegration.Security;

public class LinuxSecureStorage : ISecureStorage
{
    public void Save(string key, string value)
    {
        throw new NotImplementedException();
    }

    public string Load(string key)
    {
        throw new NotImplementedException();
    }
}