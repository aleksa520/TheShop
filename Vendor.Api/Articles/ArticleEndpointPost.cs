using AutoMapper;
using MediatR;
using Vendor.Api.Interfaces;

namespace Vendor.Api.Articles
{
    public class ArticleEndpointPost : IEndpoint
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ArticleEndpointPost(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            //app.MapPost($"article", async (ArticleRequest articleRequest) =>
            //{
            //    var buyArticleCommand = _mapper.Map<BuyArticleCommand>(articleRequest);
            //    await _mediator.Send(buyArticleCommand);
            //});
        }
    }
}
