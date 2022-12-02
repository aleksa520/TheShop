using AutoMapper;
using Vendor.Api.Dtos;
using Vendor.Domain.Model;

namespace Vendor.Api.MapperProfiles;

public class ArticleMapperProfile : Profile
{
    public ArticleMapperProfile()
    {
        CreateMap<Article, ArticleResponse>();
    }
}
