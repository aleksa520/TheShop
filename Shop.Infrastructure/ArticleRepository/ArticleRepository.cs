using Shop.Domain.Model;

namespace Shop.Infrastructure.ArticleRepository;

public class ArticleRepository : IArticleRepository
{
    private static List<Article> _articles = new()
    { 
        new Article(1, "Guitar", 990, false, default, 1),
        new Article(2, "BMW X1", 76900, false, default, 2)
    };

    public async Task<Article> GetArticleById(int id)
    {
        var article =  _articles.FirstOrDefault(article => article.Id == id);
        return await Task.FromResult(article!);
    }

    public async Task Save(Article article)
    {
        article.Id = _articles.Count + 1;
        article.IsSold = true;
        article.SoldDate = DateTime.Now;
        _articles.Add(article);
    }
}
