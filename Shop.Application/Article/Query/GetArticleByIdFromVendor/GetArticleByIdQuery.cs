using MediatR;
using Shop.Client.Dtos;

namespace Shop.Application.Article.Query.GetArticleByIdFromVendor;

public class GetArticleByIdFromVendorQuery : IRequest<ArticleResponse>
{
    public int Id { get; }

    public GetArticleByIdFromVendorQuery(int id)
    {
        Id = id;
    }
}
