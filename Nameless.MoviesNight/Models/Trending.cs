using System.Text.Json.Serialization;

namespace Nameless.MoviesNight.Models {
    public record TrendingRoot {
        [JsonPropertyName("page")]
        public int Page { get; init; }

        [JsonPropertyName("results")]
        public Trending[] Items { get; init; } = [];

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; init; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; init; }
    }

    public record Trending {
        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; init; } = string.Empty;

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; } = string.Empty;

        [JsonPropertyName("original_title")]
        public string OriginalTitle { get; init; } = string.Empty;

        [JsonPropertyName("overview")]
        public string Overview { get; init; } = string.Empty;

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; init; } = string.Empty;

        [JsonPropertyName("media_type")]
        public string MediaType { get; init; } = string.Empty;

        [JsonPropertyName("adult")]
        public bool Adult { get; init; }

        [JsonPropertyName("original_language")]
        public string OriginalLanguage { get; init; } = string.Empty;

        [JsonPropertyName("genre_ids")]
        public int[] GenreIds { get; init; } = [];

        [JsonPropertyName("popularity")]
        public decimal Popularity { get; init; }

        [JsonPropertyName("release_date")]
        public DateTimeOffset ReleaseDate { get; init; }

        [JsonPropertyName("video")]
        public bool Video { get; init; }

        [JsonPropertyName("vote_average")]
        public decimal VoteAverage { get; init; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; init; }
    }
}
