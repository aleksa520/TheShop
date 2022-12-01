using MediatR;
using Shop.Api.Helpers;
using Shop.Api.Logger;
using Shop.Application.Article.Query.GetArticleById;
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