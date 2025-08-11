using MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

namespace MusicDBPlayground.DiscogsIntegration.Clients.Interfaces;

public interface IDiscogsUserIdentityApi
{
    /// GET. Retrieves the user identity details you're authorized for via OAuth.
    /// Needs the proper OAuth signature.
    /// <returns>
    /// A task that represents the asynchronous operation. The task's result contains
    /// a UserIdentity object with the user's details if successful, or null if the operation fails.
    /// </returns>
    Task<UserIdentity?> GetUserIdentityAsync(CancellationToken? cancellationToken = default);

    /// GET. Retrieves the profile details of a specified user from the Discogs API.
    /// Requires a valid OAuth signature for authorized access.
    /// <param name="username">The username of the user whose profile is to be retrieved.</param>
    /// <param name="cancellationToken">An optional cancellation token to cancel the ongoing operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task's result contains
    /// a UserProfile object with the user's profile details if successful, or null if the user is not found or the operation fails.
    /// </returns>
    Task<UserProfile?> GetUserProfileAsync(string username, CancellationToken cancellationToken = default);

    /// POST. Updates the profile details of a specified user in the Discogs API.
    /// Authentication is required.
    /// <param name="username">The username of the user whose profile is to be updated.</param>
    /// <param name="name">The real name of the user, or null to leave it unchanged.</param>
    /// <param name="homepage">The new homepage URL for the user, or null to leave it unchanged.</param>
    /// <param name="location">The new location for the user, or null to leave it unchanged.</param>
    /// <param name="profileInfo">The new profile description for the user, or null to leave it unchanged.</param>
    /// <param name="currAbbr">The new currency abbreviation for the user, or null to leave it unchanged.
    /// USD GBP EUR CAD AUD JPY CHF MXN BRL NZD SEK ZAR</param>
    /// <param name="cancellationToken">An optional cancellation token to cancel the ongoing operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task's result is a boolean indicating
    /// whether the profile update succeeded.
    /// </returns>
    Task<UserProfileUpdateResponse?> UpdateUserProfileAsync(string username, string? name, string? homepage, string? location, string? profileInfo,
        string? currAbbr, CancellationToken cancellationToken = default);

    /// GET. Retrieves the submissions made by a specified user.
    /// <param name="username">The username of the user whose submissions are to be retrieved.</param>
    /// <param name="cancellationToken">An optional cancellation token to cancel the ongoing operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task's result contains
    /// a UserSubmissionsResponse object with the user's submissions' details if successful, or null if the user is not found or the operation fails.
    /// </returns>
    Task<UserSubmissionsResponse?> GetUserSubmissionsAsync(string username, CancellationToken cancellationToken = default);

    /// GET. Retrieves the list of contributions made by the specified user.
    /// <param name="username">The username of the user whose contributions are to be retrieved.</param>
    /// <param name="sort">The sorting criteria for the contributions.
    /// Options: label, artist, title, catno, format, rating, year, added</param>
    /// <param name="sortOrder">The sorting order, either ascending or descending (asc, desc).</param>
    /// <param name="cancellationToken">An optional cancellation token to cancel the ongoing operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task's result contains
    /// a UserContributionsResponse object with a list of contributions and pagination details if successful,
    /// or null if the user is not found or the operation fails.
    /// </returns>
    Task<UserContributionsResponse?> GetUserContributionsAsync(string username, string? sort, string? sortOrder, CancellationToken cancellationToken = default);
}