using MediatR;

namespace Shop.Application.Article.Query.GetAllArticles;

public class GetAllArticlesQuery : IRequest<IReadOnlyCollection<Domain.Model.Article>>
{

}
