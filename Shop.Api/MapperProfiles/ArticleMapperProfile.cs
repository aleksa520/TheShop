using AutoMapper;
using Shop.Application.Article.Command.BuyArticle;
using Shop.Application.Dtos;
using Shop.Domain.Model;

namespace Shop.Api.MapperProfiles;

public class ArticleMapperProfile : Profile
{
	public ArticleMapperProfile()
	{
		CreateMap<ArticleRequest, BuyArticleCommand>();

        CreateMap<Client.Dtos.ArticleResponse, ArticleResponse>();

        CreateMap<Article, ArticleResponse>();
    }
}
