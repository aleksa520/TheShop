using MediatR;
using Shop.Api.Interfaces;
using Shop.Application.Article.Query.GetArticleById;

namespace Shop.Api.Articles;

public class ArticleEndpointGet : IEndpoint
{
    private readonly IMediator _mediator;

    public ArticleEndpointGet(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet($"article/{{articleId}}", async (int articleId) =>
        {
            var article = await _mediator.Send(new GetArticleByIdQuery(articleId));
            return article;
        });
    }
}
