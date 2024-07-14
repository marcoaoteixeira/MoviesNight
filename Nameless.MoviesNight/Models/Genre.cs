using System.Text.Json.Serialization;

namespace Nameless.MoviesNight.Models {
    public record GenreRoot {
        [JsonPropertyName("genres")]
        public Genre[] Items { get; init; } = [];
    }

    public record Genre {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = string.Empty;
    }
}
