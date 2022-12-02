using Common.Logger.DefaultLogger;
using MediatR;
using Vendor.Api.Helpers;
using Vendor.Api.MapperProfiles;
using Vendor.Application.Article.Query.GetArticleById;
using Vendor.Infrastructure.ArticleRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(GetArticleByIdQuery).Assembly);
builder.Services.AddAutoMapper(typeof(ArticleMapperProfile).Assembly);

builder.Services.AddSingleton<IDefaultLogger, DefaultLogger>();
builder.Services.AddTransient<IArticleRepository, ArticleRepository>();

builder.Services.RegisterEndpoints();

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
