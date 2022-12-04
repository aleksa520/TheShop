using Flurl;
using Shop.Client.Dtos;
using System.Net.Http.Json;

namespace Shop.Client.Article;

public class ArticleClient : IArticleClient
{
    private readonly HttpClient _httpClient;
    private const string PATH = "article";

    public ArticleClient(HttpClient httpClient)
    {
        _httpClient = httpClient
            ?? throw new ArgumentNullException(nameof(httpClient));     
    }

    public async Task<ArticleResponse?> GetArticle(int id)
    {
        var response = await _httpClient.GetAsync(PATH.AppendPathSegment(id));
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ArticleResponse>();
        }
        else
        {
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound) { return null; }
        }

        throw new Exception("Inner exception");
    }
}
