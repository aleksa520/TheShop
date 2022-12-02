using MediatR;
using Vendor.Api.Interfaces;

namespace Vendor.Api.Articles;

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
            //_logger.Info($"Getting article with id:{articleId}");
            //var article = await _mediator.Send(new GetArticleByIdQuery(articleId));
            //return article;
        });
    }
}
