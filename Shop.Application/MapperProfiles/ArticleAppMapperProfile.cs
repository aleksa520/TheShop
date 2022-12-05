using AutoMapper;
using Shop.Application.Article.Command.BuyArticle;
using Shop.Application.Dtos;

namespace Shop.Application.MapperProfiles;

public class ArticleAppMapperProfile : Profile
{
    public ArticleAppMapperProfile()
    {
        CreateMap<BuyArticleCommand, Domain.Model.Article>().DisableCtorValidation();

        CreateMap<Domain.Model.Article, ArticleResponse>().DisableCtorValidation();
    }
}