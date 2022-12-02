using AutoMapper;
using MediatR;
using Vendor.Api.Dtos;
using Vendor.Api.Interfaces;
using Vendor.Application.Article.Query.GetArticleById;
using Vendor.Domain.Model;

namespace Vendor.Api.Articles;

public class ArticleEndpointGet : IEndpoint
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ArticleEndpointGet(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet($"article/{{articleId}}", async (int articleId) =>
        {
            var article = await _mediator.Send(new GetArticleByIdQuery(articleId));
            return _mapper.Map<Article, ArticleResponse>(article);
        });
    }
}
