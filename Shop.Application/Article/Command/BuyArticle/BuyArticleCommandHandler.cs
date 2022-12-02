using AutoMapper;
using MediatR;
using Shop.Infrastructure.ArticleRepository;

namespace Shop.Application.Article.Command.BuyArticle;

public class BuyArticleCommandHandler : IRequestHandler<BuyArticleCommand, Unit>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IMapper _mapper;

    public BuyArticleCommandHandler(IArticleRepository articleRepository, IMapper mapper)
    {
        _articleRepository = articleRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(BuyArticleCommand request, CancellationToken cancellationToken)
    {
        var article = _mapper.Map<BuyArticleCommand, Domain.Model.Article>(request);

        await _articleRepository.Save(article);

        return Unit.Value;
    }
}
