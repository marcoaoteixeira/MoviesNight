using System.Text.Json.Serialization;

namespace Nameless.MoviesNight.Models {
    public record SearchResultRoot {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public SearchResult[] Items { get; set; } = [];

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }

    public record SearchResult {
        public static SearchResult Empty { get; } = new() {
            Title = "NO TITLE",
            OriginalTitle = "NO TITLE",
            Overview = "NO OVERVIEW",
            ReleaseDate = DateOnly.MinValue.ToString("O")
        };

        [JsonPropertyName("adult")]
        public bool Adult { get; init; }

        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; init; } = string.Empty;

        [JsonPropertyName("genre_ids")]
        public int[] GenreIds { get; init; } = [];

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("original_language")]
        public string OriginalLanguage { get; init; } = string.Empty;

        [JsonPropertyName("original_title")]
        public string OriginalTitle { get; init; } = string.Empty;

        [JsonPropertyName("overview")]
        public string Overview { get; init; } = string.Empty;

        [JsonPropertyName("popularity")]
        public decimal Popularity { get; init; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; init; } = string.Empty;

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; init; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; init; } = string.Empty;

        [JsonPropertyName("video")]
        public bool Video { get; init; }

        [JsonPropertyName("vote_average")]
        public decimal VoteAverage { get; init; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; init; }
    }
}
