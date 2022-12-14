using Common.Logger.DefaultLogger;
using FluentValidation;
using MediatR;
using Shop.Api.Helpers;
using Shop.Api.MapperProfiles;
using Shop.Api.Middlewares;
using Shop.Application.Article.Command.BuyArticle;
using Shop.Application.Article.Query.GetArticleById;
using Shop.Application.MapperProfiles;
using Shop.Application.PipelineBehaviours;
using Shop.Client.Article;
using Shop.Client.Options.HttpClient;
using Shop.Infrastructure.ArticleRepository;
using Shop.Infrastructure.LocalCache;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.RegisterEndpoints();

builder.Services.AddMediatR(typeof(GetArticleByIdQuery).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddValidatorsFromAssembly(typeof(BuyArticleCommand).Assembly);

builder.Services.AddSingleton<IDefaultLogger, DefaultLogger>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ICachedSupplier, CachedSupplier>();

builder.Services.AddAutoMapper(typeof(ArticleMapperProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ArticleAppMapperProfile).Assembly);

builder.Services.Configure<HttpClientOptions>(
    builder.Configuration.GetSection(HttpClientOptions.SectionName));

builder.Services.AddHttpClientsFromConfig(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddEndpoints();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();