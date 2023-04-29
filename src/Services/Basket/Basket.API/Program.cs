using Basket.API.Repositories;
using Microsoft.OpenApi.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddStackExchangeRedisCache(option => { option.Configuration = "localhost:6379"; });
//builder.Services.AddStackExchangeRedisCache(option =>
//{
//    IConfiguration configuration = null;
//    option.Configuration = ConfigurationBinder.GetValue<string>(configuration, "CacheSettings:ConnectionString");
//    //option.Configuration = configuration.GetValue<string>("CacheSettings:ConnectionString");
//});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket.API", Version = "v1" });
});
// Add a custom scoped service.
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket.API v1");
        //options.RoutePrefix = string.Empty;
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
