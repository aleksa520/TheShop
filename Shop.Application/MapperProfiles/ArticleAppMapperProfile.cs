using AutoMapper;
using Shop.Application.Article.Command.BuyArticle;

namespace Shop.Application.MapperProfiles;

public class ArticleAppMapperProfile : Profile
{
    public ArticleAppMapperProfile()
    {
        CreateMap<BuyArticleCommand, Domain.Model.Article>().DisableCtorValidation();
    }
}