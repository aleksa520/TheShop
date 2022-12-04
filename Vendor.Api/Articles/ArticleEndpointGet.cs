using AutoMapper;
using Common.Logger.DefaultLogger;
using MediatR;
using Vendor.Api.Dtos;
using Vendor.Api.Interfaces;
using Vendor.Application.Article.Query.GetArticleById;
using Vendor.Domain.Model;

namespace Vendor.Api.Articles;

public class ArticleEndpointGet : IEndpoint
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IDefaultLogger _logger;

    public ArticleEndpointGet(IMediator mediator, IMapper mapper, IDefaultLogger logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet($"article/{{articleId}}", async (int articleId) =>
        {
            _logger.Info($"Getting article {articleId} from Vendor");
            var article = await _mediator.Send(new GetArticleByIdQuery(articleId));
            if(article is null )
            {
                _logger.Info($"Article {articleId} is not in inventory");
                return Results.NotFound();
            }
            return Results.Ok(_mapper.Map<Article, ArticleResponse>(article));
        });
    }
}
