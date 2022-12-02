using Vendor.Domain.Model;

namespace Vendor.Infrastructure.ArticleRepository;

public class ArticleRepository : IArticleRepository
{
    public async Task<bool> ArticleInInventory(int id)
    {
        return new Random().NextDouble() >= 0.5;
    }

    public async Task<Article> GetArticle(int id)
    {
        return new Article(id, $"Article {id}", new Random().Next(100, 500));
    }
}
