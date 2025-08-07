using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using MusicDBPlayground.DiscogsIntegration.Data;
using MusicDBPlayground.DiscogsIntegration.Security;
using MusicDBPlayground.DiscogsIntegration.Services;

namespace MusicDBPlayground.DiscogsIntegration;

public class DiscogsClient
{
    private readonly DiscogsOAuthClient _authClient;
    private readonly DiscogsApiClient _apiClient;
    private readonly EncryptionService _encryptionService;
    private readonly DiscogsDbContext _db;
    private readonly LocalKeyProvider _keyProvider;


    public DiscogsClient(HttpClient httpClient)
    {
        _apiClient = new DiscogsApiClient();
        _authClient = new DiscogsOAuthClient(httpClient);
        Console.WriteLine($"Working directory: {Environment.CurrentDirectory}");
        _db = new DiscogsDbContext();
        _encryptionService = new EncryptionService();
        // ReSharper disable once JoinDeclarationAndInitializer
        ISecureStorage secureStorage;

#if NET9_0_WINDOWS
        secureStorage = new WindowsSecureStorage();
#else
        throw new PlatformNotSupportedException("Non-Windows Secure Storage not supported yet!");
#endif
        _keyProvider = new LocalKeyProvider(secureStorage);
    }

    public async Task AuthenticateAsync()
    {
        var existingToken = await _db.OAuthTokens.FirstOrDefaultAsync();
        if (existingToken != null)
        {
            Console.WriteLine("Token already exists, don't need to request again!");
            Console.WriteLine(existingToken.EncryptedToken);
            return;
        }
        
        var passphrase = _keyProvider.GetOrCreateKey();
        var salt = EncryptionService.GenerateRandomSalt();
        
        var accessToken = await _authClient.AuthorizeWithOAuth1();

        var encryptedToken = EncryptionService.Encrypt(accessToken.Token, passphrase, salt);
        var encryptedSecret = EncryptionService.Encrypt(accessToken.TokenSecret, passphrase, salt);

        var userOAuthToken = new OAuthTokenEntity()
        {
            EncryptedToken = encryptedToken,
            EncryptedTokenSecret = encryptedSecret,
            Salt = salt
        };
        
        Console.WriteLine("Encrypted new Token! Should not be called again!");
        _db.OAuthTokens.Add(userOAuthToken);
        await _db.SaveChangesAsync();
        Console.WriteLine("Saved changes to Database!");
    }
}