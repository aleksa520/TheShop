using Shop.Api.Interfaces;

namespace Shop.Api.Articles;

public class ArticleEndpointGet : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("article", () =>
        {
            return "test";
        });
    }
}
