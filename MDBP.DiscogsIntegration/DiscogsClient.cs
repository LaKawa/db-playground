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


    public DiscogsClient(HttpClient httpClient)
    {
        _apiClient = new DiscogsApiClient();
        _authClient = new DiscogsOAuthClient(httpClient);
        _db = new DiscogsDbContext();

       // var key = GetOrCreateKey();
        _encryptionService = new EncryptionService();
    }

    public async Task AuthenticateAsync()
    {
        var accessToken = await _authClient.AuthorizeWithOAuth1();

        var salt = _encryptionService.GenerateRandomSalt();
        //var encryptedToken = _encryptionService.Encrypt(accessToken, salt);
    }
}