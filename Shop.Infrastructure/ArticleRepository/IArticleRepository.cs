using Shop.Domain.Model;

namespace Shop.Infrastructure.ArticleRepository;

public interface IArticleRepository
{
    Task<Article> GetArticleById(int id);
}
