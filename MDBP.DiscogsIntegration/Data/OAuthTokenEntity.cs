namespace MusicDBPlayground.DiscogsIntegration.Data;

public class OAuthTokenEntity
{
    public int Id { get; set; }
    
    public string EncryptedToken { get; set; }
    public string EncryptedTokenSecret { get; set; }
    
    public string Salt { get; set; }
}