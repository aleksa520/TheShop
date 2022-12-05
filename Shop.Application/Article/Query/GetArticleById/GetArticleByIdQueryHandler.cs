using AutoMapper;
using Flurl;
using MediatR;
using Microsoft.Extensions.Options;
using Shop.Application.Dtos;
using Shop.Client.Options.HttpClient;
using Shop.Infrastructure.ArticleRepository;
using System.Net.Http.Json;

namespace Shop.Application.Article.Query.GetArticleById;

public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, ArticleResponse?>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _httpClient;
    private readonly HttpClientOptions _options;
    private const string PATH = "article";

    public GetArticleByIdQueryHandler(IArticleRepository articleRepository, IMapper mapper,
        IHttpClientFactory httpClient, IOptions<HttpClientOptions> options)
    {
        _articleRepository = articleRepository;
        _mapper = mapper;
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<ArticleResponse?> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        var articleFromDatabase = await _articleRepository.GetArticle(request.Id);

        if(articleFromDatabase is not null) 
        {
            return _mapper.Map<ArticleResponse>(articleFromDatabase);
        }

        foreach (var vendor in _options.Vendors)
        {
            var httpClient = _httpClient.CreateClient(vendor.Name);
            var response = await httpClient.GetAsync(PATH.AppendPathSegment(request.Id));

            if (response.IsSuccessStatusCode)
            {
                var articleFromVendor = await response.Content.ReadFromJsonAsync<Client.Dtos.ArticleResponse>();
                return _mapper.Map<ArticleResponse>(articleFromVendor);
            }
        }

        return null;
    }
}
