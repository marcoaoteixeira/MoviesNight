using System.Text.Json;
using Nameless.MoviesNight.Infrastructure;
using Nameless.MoviesNight.Models;
using Nameless.MoviesNight.Options;

namespace Nameless.MoviesNight.Services.Impl {
    public class TmdbService : ITmdbService {
        private readonly HttpClient _httpClient;
        private readonly TmdbOptions _options;

        public TmdbService(HttpClient httpClient, TmdbOptions options) {
            _httpClient = httpClient;
            _options = options;
        }

        private async Task<T> GetAsync<T>(string url, JsonSerializerOptions? options = null)
            where T : new() {

            var response = await _httpClient.GetAsync(url);

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(json, options) ?? new T();
        }

        public async Task<Genre[]> GetGenresAsync() {
            var url = $"{_httpClient.BaseAddress}/genre/movie/list?language=en";

            var root = await GetAsync<GenreRoot>(url);

            return root.Items;
        }

        public async Task<Trending[]> GetTrendingsAsync(TimeWindow timeWindow) {
            var url = $"{_httpClient.BaseAddress}/trending/movie/{timeWindow.ToString().ToLowerInvariant()}?language=en-US";

            var options = new JsonSerializerOptions {
                Converters = {
                    new DateOnlyConverter()
                }
            };

            var root = await GetAsync<TrendingRoot>(url, options);

            return root.Items;
        }

        public async Task<SearchResult[]> SearchAsync(string query, int page = 1) {
            var url = $"{_httpClient.BaseAddress}/search/movie?query={query}&include_adult=false&language=en-US&page={page}";

            var root = await GetAsync<SearchResultRoot>(url);

            return root.Items;
        }

        public string GetImageUrl(string path, ImageSize size)
            => $"{_options.ImageBaseUrl}/{size.GetDescription()}{path}";
    }
}
