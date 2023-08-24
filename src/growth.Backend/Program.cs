using FluentValidation;
using growth.Backend.Caching;
using growth.Backend.Data;
using growth.Backend.Extensions;
using growth.Backend.Features.Audio;
using growth.Backend.Features.Entry;
using growth.Backend.Features.Unsplash;
using growth.Backend.Middleware;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders().AddConsole();
builder.Services.AddDbContext<GrowthDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Growth"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAudioService, AudioService>();
builder.Services.AddScoped<IValidator<JournalEntry>, JournalEntryValidator>();
builder.Services.AddSingleton<ICacheService, InMemoryCache>();
builder.Services.AddOutputCache(options => 
{
    options.AddBasePolicy(builder => 
    {
        builder.Expire(TimeSpan.FromMinutes(5));
    });
});

builder.Services.AddStackExchangeRedisCache(options => 
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddHttpClient<IPhotoService, UnsplashService>(httpClient => 
{
    httpClient.BaseAddress = new Uri("https://api.unsplash.com/");
});

builder.Services.Configure<JsonOptions>(options => 
{
    options.SerializerOptions.PropertyNameCaseInsensitive = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseOutputCache();
app.MapEndpoints();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseCors(myAllowSpecificOrigins);

app.Run();


public partial class Program { }
