using growth.Backend.Data;
using growth.Backend.Features.Audio;
using growth.Backend.Features.Entry;
using growth.Backend.Features.Journals;
using Microsoft.EntityFrameworkCore;


var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders().AddConsole();
builder.Services.AddDbContext<GrowthDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Growth"));
});

builder.Services.AddScoped<IAudioService, AudioService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

var app = builder.Build();

app.MapGroup("/journalEntry").MapJournalEntryRoutes();

app.MapGroup("/audio").MapGetAudioFiles();

app.MapGroup("/journal").MapGetJournal()
                        .MapGetJournals()
                        .MapCreateJournal()
                        .MapDeleteJournal();

app.UseCors(myAllowSpecificOrigins);

app.Run();


public partial class Program { }
