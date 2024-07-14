using Microsoft.AspNetCore.Components;
using Nameless.MoviesNight.Models;
using Nameless.MoviesNight.Services;
using Nameless.MoviesNight.Services.Impl;

namespace Nameless.MoviesNight.Components {
    public partial class SearchResultItemCard {
        [Inject]
        public ITmdbService TmdbService { get; set; } = NullTmdbService.Instance;

        [Parameter]
        public SearchResult Model { get; set; } = SearchResult.Empty;

        public string GetImageUrl()
            => TmdbService.GetImageUrl(Model.PosterPath, Infrastructure.ImageSize.w185);
    }
}
