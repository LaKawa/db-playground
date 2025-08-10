namespace MusicDBPlayground.DiscogsIntegration.Clients.Interfaces;

public interface IDiscogsApi : IDiscogsDatabaseApi, IDiscogsInventoryExportApi, IDiscogsInventoryUploadApi,
    IDiscogsMarketplaceApi, IDiscogsUserIdentityApi, IDiscogsUserListsApi, IDiscogsUserWantlistApi,
    IDiscogsUserCollectionApi
{
   // combines all individual discogs api endpoints into one big interface 
}