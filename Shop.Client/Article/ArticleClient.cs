using Shop.Client.Dtos;
using System.Net.Http.Json;

namespace Shop.Client.Article;

public class ArticleClient : IArticleClient
{
    private readonly HttpClient _httpClient;

    public ArticleClient(HttpClient httpClient)
    {
        _httpClient = httpClient
            ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<ArticleResponse> GetArticle(int id)
    {
        var article = await _httpClient.GetFromJsonAsync<ArticleResponse>($"/article/{{id}}");
        return article!;
    }
}
