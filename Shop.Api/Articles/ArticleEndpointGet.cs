using MediatR;
using Shop.Api.Interfaces;
using Shop.Api.Logger;
using Shop.Application.Article.Query.GetArticleById;

namespace Shop.Api.Articles;

public class ArticleEndpointGet : IEndpoint
{
    private readonly IMediator _mediator;
    private readonly IDefaultLogger _logger;

    public ArticleEndpointGet(IMediator mediator, IDefaultLogger logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet($"article/{{articleId}}", async (int articleId) =>
        {
            _logger.Info($"Getting article with id:{articleId}");
            var article = await _mediator.Send(new GetArticleByIdQuery(articleId));
            return article;
        });
    }
}
