using Microsoft.Extensions.Caching.Memory;
using Nameless.MoviesNight.Infrastructure;
using Nameless.MoviesNight.Models;

namespace Nameless.MoviesNight.Services.Impl {
    public class CacheTmdbService : ITmdbService {
        private readonly ITmdbService _tmdbService;
        private readonly IMemoryCache _memoryCache;

        public CacheTmdbService(ITmdbService tmdbService, IMemoryCache memoryCache) {
            _tmdbService = tmdbService;
            _memoryCache = memoryCache;
        }

        private async Task<T> GetFromCache<T>(string key, Task<T> factory)
            where T : class {
            if (_memoryCache.TryGetValue<T>(key, out var value) && value is not null) {
                return value;
            }

            var memoryCacheEntryOptions = new MemoryCacheEntryOptions {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
            };

            return _memoryCache.Set(key: key,
                                    value: await factory,
                                    options: memoryCacheEntryOptions);
        }

        public async Task<Genre[]> GetGenresAsync()
            => await GetFromCache(key: "cached-movie-genres",
                                  factory: _tmdbService.GetGenresAsync());

        public async Task<Trending[]> GetTrendingsAsync(TimeWindow timeWindow)
            => await GetFromCache(key: "cached-movie-trendings",
                                  factory: _tmdbService.GetTrendingsAsync(timeWindow));

        public async Task<SearchResult[]> SearchAsync(string query, int page = 1)
            => await GetFromCache(key: $"cached-movie-search-{query}-{page}",
                                  factory: _tmdbService.SearchAsync(query, page));

        public string GetImageUrl(string path, ImageSize size)
            => _tmdbService.GetImageUrl(path, size);
    }
}
