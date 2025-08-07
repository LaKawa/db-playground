using MusicDBPlayground.DiscogsIntegration.Services;

namespace MDBP.Tests;

public class EncryptionServiceTests
{
    [Fact]
    public void Encrypt_Then_Decrypt_ReturnsOriginalText()
    {
        const string passphrase = "test-passphrase";
        var service = new EncryptionService();
        var salt = EncryptionService.GenerateRandomSalt();
        const string originalText = "Hello Discogs!";
    
        var encrypted = EncryptionService.Encrypt(originalText, passphrase, salt);
        var decrypted = EncryptionService.Decrypt(encrypted, passphrase, salt);
    
        Assert.Equal(originalText, decrypted);
    }
}