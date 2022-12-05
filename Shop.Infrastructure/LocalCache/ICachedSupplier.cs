using Shop.Domain.Model;

namespace Shop.Infrastructure.LocalCache;

public interface ICachedSupplier
{
    Article? GetArticle(int id);
    void SetArticle(Article article);
}
