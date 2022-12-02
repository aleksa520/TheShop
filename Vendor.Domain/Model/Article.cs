namespace Vendor.Domain.Model;

public class Article
{
    public int Id { get; set; }
    public string Name { get; private set; }
    public double Price { get; private set; }

    public Article(int id, string name, double price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public Article()
    {
        // empty construcor for automapper
    }
}
