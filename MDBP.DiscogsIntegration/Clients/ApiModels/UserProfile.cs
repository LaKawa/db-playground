using System.Text.Json.Serialization;

namespace MusicDBPlayground.DiscogsIntegration.Clients.ApiModels;

public sealed record UserProfile
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("username")]
    public string Username { get; init; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("profile")]
    public string Profile { get; init; } = string.Empty;

    [JsonPropertyName("home_page")]
    public string HomePage { get; init; } = string.Empty;

    [JsonPropertyName("location")]
    public string Location { get; init; } = string.Empty;

    [JsonPropertyName("avatar_url")]
    public Uri AvatarUrl { get; init; } = new Uri("https://example.invalid/");

    [JsonPropertyName("banner_url")]
    public Uri? BannerUrl { get; init; }

    [JsonPropertyName("uri")]
    public Uri ProfileUri { get; init; } = new Uri("https://example.invalid/");

    [JsonPropertyName("resource_url")]
    public Uri ResourceUrl { get; init; } = new Uri("https://example.invalid/");

    [JsonPropertyName("wantlist_url")]
    public Uri WantlistUrl { get; init; } = new Uri("https://example.invalid/");

    [JsonPropertyName("inventory_url")]
    public Uri InventoryUrl { get; init; } = new Uri("https://example.invalid/");

    [JsonPropertyName("collection_folders_url")]
    public Uri CollectionFoldersUrl { get; init; } = new Uri("https://example.invalid/");

    [JsonPropertyName("collection_fields_url")]
    public Uri CollectionFieldsUrl { get; init; } = new Uri("https://example.invalid/");

    [JsonPropertyName("registered")]
    public DateTimeOffset Registered { get; init; }

    [JsonPropertyName("rank")]
    public int Rank { get; init; }

    [JsonPropertyName("rating_avg")]
    public double RatingAverage { get; init; }

    [JsonPropertyName("releases_contributed")]
    public int ReleasesContributed { get; init; }

    [JsonPropertyName("releases_rated")]
    public int ReleasesRated { get; init; }

    [JsonPropertyName("num_pending")]
    public int NumPending { get; init; }

    [JsonPropertyName("num_for_sale")]
    public int NumForSale { get; init; }

    // Visible if authenticated as the user or if the user's collection is public.
    [JsonPropertyName("num_collection")]
    public int? NumCollection { get; init; }

    // Visible if authenticated as the user or if the user's wantlist is public.
    [JsonPropertyName("num_wantlist")]
    public int? NumWantlist { get; init; }

    [JsonPropertyName("num_lists")]
    public int NumLists { get; init; }

    [JsonPropertyName("buyer_rating")]
    public double BuyerRating { get; init; }

    [JsonPropertyName("buyer_rating_stars")]
    public int BuyerRatingStars { get; init; }

    [JsonPropertyName("buyer_num_ratings")]
    public int BuyerNumRatings { get; init; }

    [JsonPropertyName("seller_rating")]
    public double SellerRating { get; init; }

    [JsonPropertyName("seller_rating_stars")]
    public int SellerRatingStars { get; init; }

    [JsonPropertyName("seller_num_ratings")]
    public int SellerNumRatings { get; init; }

    [JsonPropertyName("curr_abbr")]
    public string CurrencyAbbreviation { get; init; } = string.Empty;

    // Visible only when authenticated as the requested user.
    [JsonPropertyName("email")]
    public string? Email { get; init; }
}