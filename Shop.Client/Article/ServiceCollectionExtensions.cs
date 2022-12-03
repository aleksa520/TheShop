using Microsoft.Extensions.DependencyInjection;

namespace Shop.Client.Article;

public static class ServiceCollectionExtensions
{
    public static void AddArticleApiClient(
        this IServiceCollection services,
        Action<HttpClient> configureClient) =>
            services.AddHttpClient<IArticleClient, ArticleClient>((httpClient) =>
            {
                ArticleClientFactory.ConfigureHttpClient(httpClient);
                configureClient(httpClient);
            });
}
