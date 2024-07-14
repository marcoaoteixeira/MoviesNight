using Microsoft.AspNetCore.Components;
using Nameless.MoviesNight.Models;
using Nameless.MoviesNight.Services;
using Nameless.MoviesNight.Services.Impl;

namespace Nameless.MoviesNight.Components.Pages {
    public partial class Search {
        [Inject]
        public ITmdbService TmdbService { get; set; } = NullTmdbService.Instance;

        public string? Query { get; set; }

        public SearchResult[] SearchResults { get; set; } = [];

        public async Task HandleSearch() {
            if (string.IsNullOrWhiteSpace(Query))
                return;

            SearchResults = await TmdbService.SearchAsync(Query, page: 1);
        }
    }
}
