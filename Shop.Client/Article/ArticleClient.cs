using Shop.Client.Dtos;
using System.Net.Http.Json;

namespace Shop.Client.Article;

public class ArticleClient : IArticleClient
{
    private readonly HttpClient _httpClient;

    public ArticleClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ArticleResponse> GetArticle(int id)
    {
        var article = await _httpClient.GetFromJsonAsync<ArticleResponse>($"https://localhost:7207/article{{id}}");
        return article!;
    }
}
