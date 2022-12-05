﻿using AutoMapper;
using MediatR;
using Shop.Api.Interfaces;
using Common.Logger.DefaultLogger;
using Shop.Application.Article.Command.BuyArticle;
using Shop.Application.Dtos;

namespace Shop.Api.Articles
{
    public class ArticleEndpointPost : IEndpoint
    {
        private readonly IMediator _mediator;
        private readonly IDefaultLogger _logger;
        private readonly IMapper _mapper;

        public ArticleEndpointPost(IMediator mediator, IDefaultLogger logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            app.MapPost($"article", async (ArticleRequest articleRequest) =>
            {
                var buyArticleCommand = _mapper.Map<BuyArticleCommand>(articleRequest);
                await _mediator.Send(buyArticleCommand);
            });
        }
    }
}
