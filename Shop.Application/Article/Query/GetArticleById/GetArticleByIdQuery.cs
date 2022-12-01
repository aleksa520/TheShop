using MediatR;

namespace Shop.Application.Article.Query.GetArticleById;

public class GetArticleByIdQuery : IRequest<Domain.Model.Article>
{
    public int Id { get; }

    public GetArticleByIdQuery(int id)
    {
        Id = id;
    }
}
