using System.Net.Http.Headers;
using Nameless.MoviesNight.Options;
using Nameless.MoviesNight.Services;
using Nameless.MoviesNight.Services.Impl;

namespace Nameless.MoviesNight {
    public static class ServiceCollectionExtension {
        public static IServiceCollection RegisterOptions(this IServiceCollection self)
            => self.AddSingleton(provider => {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var tmdbSection = configuration.GetSection(nameof(TmdbOptions));
                return tmdbSection.Get<TmdbOptions>() ?? new TmdbOptions();
            });

        public static IServiceCollection RegisterTmdbService(this IServiceCollection self) {
            self.AddHttpClient<ITmdbService, TmdbService>((provider, httpClient) => {
                var tmdbOptions = provider.GetRequiredService<TmdbOptions>();

                httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tmdbOptions.Token);
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return self.Decorate<ITmdbService, CacheTmdbService>();
        }

        public static IServiceCollection RegisterMemoryCache(this IServiceCollection self)
            => self.AddMemoryCache();
    }
}
