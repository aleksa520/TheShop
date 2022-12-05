namespace Shop.Application.Dtos;

public record ArticleRequest(string Name, double Price, int BuyerUserId);