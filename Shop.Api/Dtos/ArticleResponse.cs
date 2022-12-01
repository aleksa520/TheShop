namespace Shop.Api.Dtos;

public record ArticleResponse(int Id, string Name, double Price, bool IsSold, DateTime SoldDate, int BuyerUserId);
