using MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

namespace MusicDBPlayground.DiscogsIntegration.Clients.Interfaces;

public interface IDiscogsDatabaseApi
{
    #region Release

    /// <summary>
    /// Gets a release by its Discogs release ID.
    /// </summary>
    /// <param name="releaseId">The release ID.</param>
    /// <param name="currAbbr">Optional: currency abbreviation for marketplace data.
    /// Defaults to the current users default currency.</param>
    /// <param name="cancellationToken">A token to abort the async operation.</param>
    /// <returns>The release data, or null if not found.</returns>
    Task<Release?> GetReleaseAsync(int releaseId, string? currAbbr = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the number of users who have or want the release.
    /// </summary>
    /// <param name="releaseId">The release ID.</param>
    /// <param name="cancellationToken">A token to abort the async operation.</param>
    /// <returns>The ReleaseStats (want/have), or null if not found.</returns>
    Task<ReleaseStats?> GetReleaseStatsAsync(int releaseId, CancellationToken cancellationToken = default);
    
    #endregion
    
    #region ReleaseRating

    /// <summary>
    /// Gets the release rating from a given user.
    /// </summary>
    /// <param name="releaseId">The release ID.</param>
    /// <param name="username">The username of the rating you want to request.</param>
    /// <param name="cancellationToken">A token to abort the async operation.</param>
    /// <returns>The release user rating data, or null if not found.</returns>
    Task<ReleaseUserRating?> GetReleaseUserRatingAsync(int releaseId, string username, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the release's rating for a given user. Authentication required!
    /// </summary>
    /// <param name="releaseId">The release ID.</param>
    /// <param name="username">The username for whom to set the release rating.</param>
    /// <param name="rating">The rating (1 to 5).</param>
    /// <param name="cancellationToken">A token to abort the async operation.</param>
    /// <returns>The release user rating data, or null if not found.</returns>
    Task<ReleaseUserRating?> SetReleaseUserRatingAsync(int releaseId, string username, int rating,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the release's rating for a given user. (204) status code if successful. Authentication required!
    /// </summary>
    /// <param name="releaseId">The ID of the release.</param>
    /// <param name="username">The username for whom to delete the release rating.</param>
    /// <param name="cancellationToken">A token to cancel the async operation.</param>
    /// <returns>A task that represents the asynchronous delete operation.</returns>
    Task DeleteReleaseUserRatingAsync(int releaseId, string username, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the community rating for a release by its Discogs release ID.
    /// </summary>
    /// <param name="releaseId">The release ID.</param>
    /// <param name="cancellationToken">A token to abort the async operation.</param>
    /// <returns>The community rating data for the release, or null if not found.</returns>
    Task<ReleaseCommunityRating?> GetReleaseCommunityRatingAsync(int releaseId, CancellationToken cancellationToken = default);
    
    #endregion
    
    #region MasterReleases
    
    /// <summary>
    /// Gets a MasterRelease by its Discogs MasterRelease ID.
    /// A set of similar releases have a main release, often the chronologically earliest.
    /// </summary>
    /// <param name="masterId">The MasterRelease ID.</param>
    /// <param name="cancellationToken">A token to abort the async operation.</param>
    /// <returns>The MasterRelease data, or null if not found.</returns>
    Task<MasterRelease?> GetMasterReleaseAsync(int masterId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a list of all releases that are versions of a MasterRelease.
    /// </summary>
    /// <param name="masterId">The MasterRelease ID.</param>
    /// <param name="page">Page number (optional).</param>
    /// <param name="perPage">Items per page (optional).</param>
    /// <param name="format">Filter by format (e.g., "Vinyl").</param>
    /// <param name="label">Filter by label.</param>
    /// <param name="released">Filter by release year (e.g., "1992").</param>
    /// <param name="country">Filter by country.</param>
    /// <param name="sort">Sort by one of: released, title, format, label, catno, country.</param>
    /// <param name="sortOrder">Sort order: "asc" or "desc".</param>
    /// <param name="ct">Cancellation token.</param>
    Task<MasterReleaseVersionsResponse> GetMasterReleaseVersionsAsync(
        int masterId,
        int? page = null,
        int? perPage = null,
        string? format = null,
        string? label = null,
        string? released = null,
        string? country = null,
        string? sort = null,
        string? sortOrder = null,
        CancellationToken ct = default);
    
    #endregion
    
    #region Artist

    /// <summary>
    /// Get the Artist resource which represents a person in the Discogs database who contributed to a Release in some capacity.
    /// </summary>
    /// <param name="artistId">The artist ID.</param>
    /// <param name="cancellationToken">A token to abort the async operation.</param>
    /// <returns>The artist data, or null if not found.</returns>
    Task<Artist?> GetArtistAsync(int artistId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of releases and masters for a specified artist, optionally sorted by the provided parameters.
    /// </summary>
    /// <param name="artistId">The ID of the artist.</param>
    /// <param name="sort">Optional: the field by which to sort the releases (e.g., year, title).</param>
    /// <param name="sortOrder">Sort order: "asc" or "desc"</param>
    /// <param name="cancellationToken">A token to cancel the async operation.</param>
    /// <returns>A response containing the artist's releases and pagination information, or null if not found.</returns>
    Task<ArtistReleasesResponse?> GetArtistReleasesAsync(int artistId, string? sort, string? sortOrder,
        CancellationToken cancellationToken = default);

    #endregion
    
    #region Label
    
    /// <summary>
    /// Retrieves a label/entity by ID.
    /// </summary>
    /// <param name="labelId">The Label ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task<Label?> GetLabelAsync(int labelId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a list of releases associated with a label.
    /// </summary>
    /// <param name="labelId">The Label ID.</param>
    /// <param name="page">Page number (optional).</param>
    /// <param name="perPage">Items per page (optional).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task<LabelReleasesResponse> GetLabelReleasesAsync(
        int labelId,
        int? page = null,
        int? perPage = null,
        CancellationToken cancellationToken = default);
    
    #endregion
    
    /// <summary>
    /// Issues a search query against the Discogs database. Authentication as any user required!
    /// </summary>
    /// <param name="request">Search parameters (all optional).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task<SearchResponse> SearchAsync(SearchRequest request, CancellationToken cancellationToken = default);
}