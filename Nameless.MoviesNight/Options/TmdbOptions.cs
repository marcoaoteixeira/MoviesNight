namespace Nameless.MoviesNight.Options {
    public record TmdbOptions {
        public string Token { get; init; } = string.Empty;
        public string ImageBaseUrl { get; init; } = string.Empty;
    }
}
