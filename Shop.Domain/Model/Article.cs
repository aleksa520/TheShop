namespace Shop.Domain.Model;

public class Article
{
    public int Id { get; set; }
    public string Name { get; private set; }
    public double Price { get; private set; }
    public bool IsSold { get; set; }
    public DateTime SoldDate { get; set; }
    public int BuyerUserId { get; private set; }

    public Article(int id, string name, double price, bool isSold, DateTime soldDate, int buyerUserId)
    {
        Id = id;
        Name = name;
        Price = price;
        IsSold = isSold;
        SoldDate = soldDate;
        BuyerUserId = buyerUserId;
    }

    public Article()
    {
        // empty construcor for automapper
    }
}
