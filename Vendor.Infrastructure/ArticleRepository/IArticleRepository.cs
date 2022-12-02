using Vendor.Domain.Model;

namespace Vendor.Infrastructure.ArticleRepository;

public interface IArticleRepository
{
    public Task<bool> ArticleInInventory(int id);
    public Task<Article> GetArticle(int id);
}
