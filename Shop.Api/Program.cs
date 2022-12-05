using Common.Logger.DefaultLogger;
using MediatR;
using Shop.Api.Helpers;
using Shop.Api.MapperProfiles;
using Shop.Application.Article.Query.GetArticleById;
using Shop.Application.MapperProfiles;
using Shop.Client.Article;
using Shop.Client.Options.HttpClient;
using Shop.Infrastructure.ArticleRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterEndpoints();

builder.Services.AddMediatR(typeof(GetArticleByIdQuery).Assembly);
builder.Services.AddSingleton<IDefaultLogger, DefaultLogger>();
builder.Services.AddTransient<IArticleRepository, ArticleRepository>();

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

app.Run();