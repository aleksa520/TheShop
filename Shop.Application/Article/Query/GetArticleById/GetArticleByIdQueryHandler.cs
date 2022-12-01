using MediatR;

namespace Shop.Application.Article.Query.GetArticleById;

public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, Domain.Model.Article>
{
    public Task<Domain.Model.Article> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        var a = new Domain.Model.Article(1, "test", 123, true, DateTime.Now, 1);
        return Task.FromResult(a);
    }
}
