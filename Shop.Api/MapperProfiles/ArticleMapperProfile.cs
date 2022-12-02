using AutoMapper;
using Shop.Api.Dtos;
using Shop.Application.Article.Command.BuyArticle;
using Shop.Domain.Model;

namespace Shop.Api.MapperProfiles;

public class ArticleMapperProfile : Profile
{
	public ArticleMapperProfile()
	{
		CreateMap<ArticleRequest, BuyArticleCommand>();

        CreateMap<Article, ArticleResponse>();
    }
}
