using MediatR;
using Shop.Infrastructure.ArticleRepository;

namespace Shop.Application.Article.Query.GetArticleById;

public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, Domain.Model.Article>
{
    private readonly IArticleRepository _articleRepository;

    public GetArticleByIdQueryHandler(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task<Domain.Model.Article> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        return await _articleRepository.GetArticleById(request.Id);
    }
}
