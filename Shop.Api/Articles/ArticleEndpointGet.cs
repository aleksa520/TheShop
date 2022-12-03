using MediatR;
using Shop.Api.Interfaces;
using Common.Logger.DefaultLogger;
using Shop.Application.Article.Query.GetArticleById;
using Shop.Application.Article.Query.GetAllArticles;
using AutoMapper;
using Shop.Api.Dtos;
using Shop.Application.Article.Query.GetArticleByIdFromVendor;

namespace Shop.Api.Articles;

public class ArticleEndpointGet : IEndpoint
{
    private readonly IMediator _mediator;
    private readonly IDefaultLogger _logger;
    private readonly IMapper _mapper;

    public ArticleEndpointGet(IMediator mediator, IDefaultLogger logger, IMapper mapper)
    {
        _mediator = mediator;
        _logger = logger;
        _mapper = mapper;
    }

    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet($"article/{{articleId}}", async (int articleId) =>
        {
            _logger.Info($"Getting article with id:{articleId}");
            var articleFromShop = await _mediator.Send(new GetArticleByIdQuery(articleId));
            if(articleFromShop == null)
            {
                var articleFromVendor = await _mediator.Send(new GetArticleByIdFromVendorQuery(articleId));
                return _mapper.Map<Client.Dtos.ArticleResponse, Dtos.ArticleResponse>(articleFromVendor);
            }
            return _mapper.Map<Domain.Model.Article, Dtos.ArticleResponse>(articleFromShop);
        });

        app.MapGet($"article", async () =>
        {
            _logger.Info($"Getting all articles");
            var articles = await _mediator.Send(new GetAllArticlesQuery());
            return _mapper.Map<IReadOnlyCollection<ArticleResponse>>(articles);
        });
    }
}
