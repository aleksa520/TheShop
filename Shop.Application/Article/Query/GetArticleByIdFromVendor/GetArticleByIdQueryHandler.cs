using Flurl;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Shop.Client.Dtos;
using Shop.Client.Options.HttpClient;
using System.Net.Http.Json;

namespace Shop.Application.Article.Query.GetArticleByIdFromVendor;

public class GetArticleByIdFromVendorQueryHandler : IRequestHandler<GetArticleByIdFromVendorQuery, ArticleResponse?>
{
    private readonly IHttpClientFactory _httpClient;
    private readonly HttpClientOptions _options;
    private const string PATH = "article";


    public GetArticleByIdFromVendorQueryHandler(IHttpClientFactory httpClient, IOptions<HttpClientOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<ArticleResponse?> Handle(GetArticleByIdFromVendorQuery request, CancellationToken cancellationToken)
    {
        foreach (var vendor in _options.Vendors)
        {
            var httpClient = _httpClient.CreateClient(vendor.Name);
            var response = await httpClient.GetAsync(PATH.AppendPathSegment(request.Id));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ArticleResponse>();
            }
        }

        return null;
    }
}
