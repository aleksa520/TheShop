namespace Shop.Api.Dtos;

public record ArticleRequest(string Name, double Price, int BuyerUserId);