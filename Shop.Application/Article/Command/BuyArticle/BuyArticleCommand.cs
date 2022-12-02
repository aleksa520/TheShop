using MediatR;

namespace Shop.Application.Article.Command.BuyArticle;

public class BuyArticleCommand : IRequest<Unit>
{
    public string Name { get; private set; }
    public double Price { get; private set; }
    public int BuyerUserId { get; private set; }

    public BuyArticleCommand(string name, double price, int buyerUserId)
    {
        Name = name;
        Price = price;
        BuyerUserId = buyerUserId;
    }
}
