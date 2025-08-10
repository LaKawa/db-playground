using MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

namespace MusicDBPlayground.DiscogsIntegration.Clients.Interfaces;

public interface IDiscogsUserCollectionApi
{
    //TODO
    /// Retrieves the collection folders for a specified user on Discogs.
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

    /// Creates a new collection folder for a specified user on Discogs.
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
    Task<UserCollectionFolder?> CreateUserCollectionFolderAsync(string username, string? folderName, CancellationToken cancellationToken);


    /// Retrieves a specific collection folder for a specified user on Discogs.
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
    Task<UserCollectionFolder?> GetUserCollectionFolderAsync(string username, int folderId, CancellationToken cancellationToken);

    /// Updates the details of a user's specific collection folder on Discogs.
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
    Task<UserCollectionFolder?> UpdateUserCollectionFolderAsync(string username, int folderId, CancellationToken cancellationToken);

    /// Deletes a specified collection folder for a user on Discogs.
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
    
   // TODO continue with CollectionItemsByRelease 
}