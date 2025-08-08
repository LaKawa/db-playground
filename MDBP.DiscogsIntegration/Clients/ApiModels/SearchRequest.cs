namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

// Request container for /database/search
public sealed class SearchRequest
{
    // General search query (q)
    public string? Query { get; init; }

    // Filters (all optional)
    public string? Type { get; init; }                 // release | master | artist | label
    public string? Title { get; init; }                // "Artist Name - Release Title"
    public string? ReleaseTitle { get; init; }
    public string? Credit { get; init; }
    public string? Artist { get; init; }
    public string? Anv { get; init; }
    public string? Label { get; init; }
    public string? Genre { get; init; }
    public string? Style { get; init; }
    public string? Country { get; init; }
    public string? Year { get; init; }
    public string? Format { get; init; }
    public string? CatNo { get; init; }
    public string? Barcode { get; init; }
    public string? Track { get; init; }
    public string? Submitter { get; init; }
    public string? Contributor { get; init; }

    // Pagination
    public int? Page { get; init; }
    public int? PerPage { get; init; }
}

