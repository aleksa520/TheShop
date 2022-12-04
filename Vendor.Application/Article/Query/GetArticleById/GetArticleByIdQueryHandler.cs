using MediatR;
using Vendor.Infrastructure.ArticleRepository;

namespace Vendor.Application.Article.Query.GetArticleById;

public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, Domain.Model.Article?>
{
    private readonly IArticleRepository _articleRepository;

    public GetArticleByIdQueryHandler(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task<Domain.Model.Article?> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        if (await _articleRepository.ArticleInInventory(request.Id))
        {
            return await _articleRepository.GetArticle(request.Id);
        }
        return null;
    }
}
