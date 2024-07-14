using Nameless.MoviesNight.Infrastructure;
using Nameless.MoviesNight.Models;

namespace Nameless.MoviesNight.Services.Impl {
    public sealed class NullTmdbService : ITmdbService {
        public static ITmdbService Instance { get; } = new NullTmdbService();

        static NullTmdbService() { }

        private NullTmdbService() { }

        public Task<Genre[]> GetGenresAsync()
            => Task.FromResult(Array.Empty<Genre>());

        public Task<Trending[]> GetTrendingsAsync(TimeWindow timeWindow)
            => Task.FromResult(Array.Empty<Trending>());

        public Task<SearchResult[]> SearchAsync(string query, int page)
            => Task.FromResult(Array.Empty<SearchResult>());

        public string GetImageUrl(string path, ImageSize size)
            => string.Empty;
    }
}
