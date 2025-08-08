namespace MusicDBPlayground.DiscogsIntegration.Clients;

public class DiscogsApiClient
{
    private HttpClient _httpClient;
    private DiscogsOAuthClient _oAuthClient;

    public DiscogsApiClient(HttpClient httpClient, DiscogsOAuthClient oAuthClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _oAuthClient = oAuthClient ?? throw new ArgumentNullException(nameof(oAuthClient));
        
        //_httpClient.DefaultRequestHeaders.Add 
    }
    
    public async Task<string> GetIdentityAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://api.discogs.com/oauth/identity");
        
        _oAuthClient.SignRequest(request);
        
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadAsStringAsync();
    }
}
