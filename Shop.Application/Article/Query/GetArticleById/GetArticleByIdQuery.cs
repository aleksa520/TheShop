using MediatR;
using Shop.Application.Dtos;

namespace Shop.Application.Article.Query.GetArticleById;

public class GetArticleByIdQuery : IRequest<ArticleResponse>
{
    public int Id { get; }

    public GetArticleByIdQuery(int id)
    {
        Id = id;
    }
}
