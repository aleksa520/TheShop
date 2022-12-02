using MediatR;
using Shop.Infrastructure.ArticleRepository;

namespace Shop.Application.Article.Query.GetAllArticles;

public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, IReadOnlyCollection<Domain.Model.Article>>
{
    private readonly IArticleRepository _articleRepository;

    public GetAllArticlesQueryHandler(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task<IReadOnlyCollection<Domain.Model.Article>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
    {
        return await _articleRepository.GetAll();
    }
}
