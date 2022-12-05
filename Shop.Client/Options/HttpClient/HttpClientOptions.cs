namespace Shop.Client.Options.HttpClient;

public class HttpClientOptions
{
    public const string SectionName = "HttpClient";

    public List<Vendor> Vendors { get; set; } = new();
}
