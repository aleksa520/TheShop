using MediatR;
using Shop.Client.Article;
using Shop.Client.Dtos;

namespace Shop.Application.Article.Query.GetArticleByIdFromVendor;

public class GetArticleByIdFromVendorQueryHandler : IRequestHandler<GetArticleByIdFromVendorQuery, ArticleResponse>
{
    private readonly IArticleClient _articleClient;

    public GetArticleByIdFromVendorQueryHandler(IArticleClient articleClient)
    {
        _articleClient = articleClient;
    }

    public async Task<ArticleResponse> Handle(GetArticleByIdFromVendorQuery request, CancellationToken cancellationToken)
    {
        return await _articleClient.GetArticle(request.Id);
    }
}
