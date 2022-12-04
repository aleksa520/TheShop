using Shop.Client.Dtos;

namespace Shop.Client.Article;

public interface IArticleClient
{
    Task<ArticleResponse?> GetArticle(int id);
}
