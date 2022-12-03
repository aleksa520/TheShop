namespace Shop.Client.Article;

public class ArticleClientFactory
{
    public static void ConfigureHttpClient(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));
    }
}
