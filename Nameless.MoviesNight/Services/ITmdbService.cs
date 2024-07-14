using Nameless.MoviesNight.Infrastructure;
using Nameless.MoviesNight.Models;

namespace Nameless.MoviesNight.Services {
    public interface ITmdbService {
        Task<Genre[]> GetGenresAsync();

        Task<Trending[]> GetTrendingsAsync(TimeWindow timeWindow);

        Task<SearchResult[]> SearchAsync(string query, int page);

        string GetImageUrl(string path, ImageSize size);
    }
}
