using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Client.Options.HttpClient;

namespace Shop.Client.Article;

public static class ServiceCollectionExtensions
{
    public static void AddHttpClientsFromConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var clientOptions = new HttpClientOptions();

        configuration.GetSection(HttpClientOptions.SectionName).Bind(clientOptions);

        foreach(var vendor in clientOptions.Vendors)
        {
            services.AddHttpClient(vendor.Name, client =>
            {
                client.BaseAddress = new(vendor.BaseUrl);
            });
        }
    }
}
