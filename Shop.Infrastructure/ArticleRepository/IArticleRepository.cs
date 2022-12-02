using Shop.Domain.Model;

namespace Shop.Infrastructure.ArticleRepository;

public interface IArticleRepository
{
    Task<Article> GetArticle(int id);
    Task Save(Article article);
    Task<IReadOnlyCollection<Article>> GetAll();
}
