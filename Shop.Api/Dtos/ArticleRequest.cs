namespace Shop.Api.Dtos;

public record ArticleRequest(int Id, string Name, double Price, bool IsSold, DateTime SoldDate, int BuyerUserId);