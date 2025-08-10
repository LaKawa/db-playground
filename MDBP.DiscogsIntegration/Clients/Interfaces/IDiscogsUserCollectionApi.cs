using MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

namespace MusicDBPlayground.DiscogsIntegration.Clients.Interfaces;

public interface IDiscogsUserCollectionApi
{
    /// GET. Retrieves the collection folders for a specified user on Discogs.
    /// Folders have an ID, so do individual releases in the folders as they might appear in different ones.
    /// ID 0 always is the "All" folder.
    /// ID 1 always is the Uncategorized folder.
    /// If the collection is private, Authentication is required!
    /// <param name="username">
    /// The username of the Discogs account whose collection folders are to be retrieved.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to observe while waiting for the task to complete. Can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains the user's collection folders
    /// or null if the folders cannot be retrieved.
    /// </returns>
    Task<UserCollectionFolders?> GetUserCollectionFoldersAsync(string username, CancellationToken cancellationToken);

    /// POST. Creates a new collection folder for a specified user on Discogs.
    /// The folder will have a unique ID and name, and it can store individual releases organized by the user.
    /// Folder names must be unique within the user's collection.
    /// Authentication is required!
    /// <param name="username">
    /// The username of the Discogs account for whom the collection folder is to be created.
    /// </param>
    /// <param name="folderName">
    /// The name of the folder to create.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to observe while waiting for the task to complete. Can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains the created collection folder
    /// or null if the folder could not be created.
    /// </returns>
    Task<UserCollectionFolder?> CreateUserCollectionFolderAsync(string username, string? folderName,
        CancellationToken cancellationToken);


    /// GET. Retrieves a specific collection folder for a specified user on Discogs.
    /// Each folder contains an ID, name, release count, and associated data.
    /// Includes information such as folder ID and the folder's content details.
    /// Authentication is required!
    /// <param name="username">
    /// The username of the Discogs account whose specific collection folder is to be retrieved.
    /// </param>
    /// <param name="folderId">
    /// The unique ID of the folder within the user's collection to retrieve.
    /// ID 0 always corresponds to "All," and ID 1 corresponds to "Uncategorized."
    /// </param>
    /// <param name="cancellationToken">
    /// A token to observe while waiting for the task to complete. Can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains the folder information
    /// or null if the folder cannot be retrieved.
    /// </returns>
    Task<UserCollectionFolder?> GetUserCollectionFolderAsync(string username, int folderId,
        CancellationToken cancellationToken);

    /// POST. Updates the details of a user's specific collection folder on Discogs.
    /// This operation primarily allows changing folder properties such as its name.
    /// Authentication is required!
    /// <param name="username">
    /// The username of the Discogs account whose collection folder is to be updated.
    /// </param>
    /// <param name="folderId">
    /// The unique identifier of the folder to be updated.
    /// ID 0 always corresponds to "All", ID 1 corresponds to "Uncategorized" and cannot be updated.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to observe while waiting for the task to complete. Can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains the updated collection folder details
    /// or null if the update operation fails.
    /// </returns>
    Task<UserCollectionFolder?> UpdateUserCollectionFolderAsync(string username, int folderId,
        CancellationToken cancellationToken);

    /// DELETE. Deletes a specified collection folder for a user on Discogs.
    /// Only custom folders can be deleted. Default folders such as "All" and "Uncategorized" cannot be removed.
    /// Releases in the deleted folder will be moved to the "Uncategorized" folder.
    /// Authentication is required!
    /// <param name="username">
    /// The username of the Discogs account whose collection folder is to be deleted.
    /// </param>
    /// <param name="folderId">
    /// The ID of the collection folder to delete.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to observe while waiting for the task to complete. Can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. The task completes when the folder is successfully deleted
    /// or if the deletion fails.
    /// </returns>
    Task DeleteUserCollectionFolderAsync(string username, int folderId, CancellationToken cancellationToken);

    /// GET. Retrieves all collection items for a specified user and release ID on Discogs.
    /// This allows querying specific items tied to a release across various folders.
    /// If the collection is private, Authentication is required.
    /// <param name="username">
    /// The username of the Discogs account whose collection items for the specified release are to be retrieved.
    /// </param>
    /// <param name="releaseId">
    /// The unique identifier of the release for which the collection items should be fetched.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to observe while waiting for the task to complete. Can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains the collection items related to the
    /// specified release or null if the items cannot be retrieved.
    /// </returns>
    Task<UserCollectionReleasesResponse?> GetCollectionItemsByReleaseAsync(string username, int releaseId,
        CancellationToken cancellationToken);

    /// GET. Retrieves the collection items within a specific folder for a specified user on Discogs.
    /// Allows sorting and pagination of the results.
    /// If the collection is private, authentication is required.
    /// <param name="username">
    /// The username of the Discogs account whose collection folder items are to be retrieved.
    /// </param>
    /// <param name="folderId">
    /// The ID of the folder within the user's collection.
    /// </param>
    /// <param name="sort">
    /// The parameter to sort the results by (e.g., label, artist, title, catno, format, rating, added, year).
    /// </param>
    /// <param name="sortOrder">
    /// The order to sort the results in, either ascending (asc) or descending (desc).
    /// </param>
    /// <param name="page">
    /// The page number of the paginated results to retrieve.
    /// </param>
    /// <param name="perPage">
    /// The number of items per page for the paginated results.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to observe while waiting for the task to complete. Can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains the collection folder items and associated pagination information
    /// or null if the items cannot be retrieved.
    /// </returns>
     
    Task<UserCollectionFolderReleases?> GetCollectionItemsByFolderAsync(
        string username,
        long folderId,
        string? sort = null,
        string? sortOrder = null,
        int? page = null,
        int? perPage = null,
        CancellationToken cancellationToken = default);
    /// <summary>POST. Requires authentication as the collection owner. folder_id must be non-zero.
    /// Adds a release to a specified folder in the user's Discogs collection.
    /// Requires authentication as the collection owner. The folder ID must be non-zero.
    /// Using ID 1 is fine for "Uncategorized".</summary>
    /// <param name="username">
    /// The username of the Discogs account where the collection folder resides.
    /// </param>
    /// <param name="folderId">
    /// The ID of the folder to which the release will be added. Must be non-zero.
    /// 1 is okay for "Uncategorized".
    /// </param>
    /// <param name="releaseId">
    /// The ID of the release to be added to the folder.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to observe while waiting for the task to complete. Can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains information about the
    /// addition of the release to the folder, including an instance ID and resource URL,
    /// or null if the operation fails.
    /// </returns>
    Task<AddToCollectionFolderResponse?> AddReleaseToCollectionFolderAsync(
        string username,
        long folderId,
        long releaseId,
        CancellationToken cancellationToken = default);

    // TODO: this and MoveReleaseToFolder use the same endpoint - test! 
    /// <summary>
    /// POST. Updates the rating of a specific collection instance.
    /// </summary>
    /// <param name="username">Collection owner.</param>
    /// <param name="releaseId">Release ID.</param>
    /// <param name="instanceId">Instance ID.</param>
    /// <param name="rating">New rating (0–5; 0 typically means "no rating").</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete. Can be used to cancel the operation.</param>
    Task UpdateReleaseUserRatingAsync(
        string username,
        long releaseId,
        long instanceId,
        int rating,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// POST. Moves a specific collection instance to another folder.
    /// </summary>
    /// <param name="username">Collection owner.</param>
    /// <param name="currentFolderId">Folder in the URL (current folder context).</param>
    /// <param name="releaseId">Release ID.</param>
    /// <param name="instanceId">Instance ID.</param>
    /// <param name="targetFolderId">Destination folder ID (must be non-zero).</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete. Can be used to cancel the operation.</param>
    Task MoveReleaseToFolderAsync(
        string username,
        long currentFolderId,
        long releaseId,
        long instanceId,
        long targetFolderId,
        CancellationToken cancellationToken = default);


    /// <summary>
    /// DELETE. Deletes a specific collection instance from the given folder.
    /// Returns 204 on success. Returns 403 (with an error message) if not authorized.
    /// </summary>
    /// <param name="username">Collection owner.</param>
    /// <param name="folderId">Folder from which to delete.</param>
    /// <param name="releaseId">Release ID.</param>
    /// <param name="instanceId">Instance ID to remove.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete. Can be used to cancel the operation</param>
    Task DeleteReleaseFromFolderAsync(
        string username,
        long folderId,
        long releaseId,
        long instanceId,
        CancellationToken cancellationToken = default);


    /// GET. Retrieves user-defined collection fields for the specified user.
    /// If not authenticated as the owner, only fields with public = true are returned.
    /// Example:  "name": "Media",
    /// "options": [
    /// "Mint (M)",
    /// "Near Mint (NM or M-)",
    /// "Very Good Plus (VG+)", and so on
    /// <param name="username">
    /// The username of the Discogs account whose collection fields are to be retrieved.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to observe while waiting for the task to complete. Can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains the user's collection fields
    /// or null if the fields cannot be retrieved.
    /// </returns>
    Task<UserCollectionFields?> GetUserCollectionFieldsAsync(
        string username,
        CancellationToken cancellationToken = default);


    /// POST. Updates the value of a notes field for a specific collection instance in a user's collection.
    /// For dropdown fields, the value must match one of the field's pre-defined options.
    /// Returns an HTTP 204 status code on success, indicating the operation was completed successfully.
    /// Authentication is required for this operation.
    /// <param name="username">
    /// The username of the Discogs account for which the collection instance field is being updated.
    /// </param>
    /// <param name="folderId">
    /// The ID of the folder containing the release whose instance field is being updated.
    /// </param>
    /// <param name="releaseId">
    /// The ID of the release in the collection.
    /// </param>
    /// <param name="instanceId">
    /// The ID of the specific release instance in the collection.
    /// </param>
    /// <param name="fieldId">
    /// The ID of the field to be updated.
    /// </param>
    /// <param name="value">
    /// The new value to set for the specified field. For dropdown fields, the value must match an existing option.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to observe while waiting for the task to complete. Can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation, which completes successfully if the operation succeeds.
    /// </returns>
    Task UpdateReleaseInstanceFieldAsync(
        string username,
        long folderId,
        long releaseId,
        long instanceId,
        long fieldId,
        string value,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// GET. Returns the minimum, median, and maximum value of a user's collection.
    /// Authentication as the collection owner is required.
    /// </summary>
    Task<UserCollectionValue?> GetUserCollectionValueAsync(
        string username,
        CancellationToken cancellationToken = default);
}