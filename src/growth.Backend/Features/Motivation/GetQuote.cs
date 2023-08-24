using growth.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace growth.Backend.Features.Motivation;

public static class GetQuote
{
    //need to make this cache at the start of a new day
    public static RouteGroupBuilder MapGetQuote(this RouteGroupBuilder app)
    {
        app.MapGet("/", HandleAsync).CacheOutput();
        return app;
    }

    public static async Task<IResult> HandleAsync(GrowthDbContext context)
    {
        Random rand = new();  
        int skipper = rand.Next(0, context.Quotes.Count() - 1);
    
        var quote = await context.Quotes
            .OrderBy(quote => EF.Functions.Random())
            .Skip(skipper)
            .Take(1)
            .FirstOrDefaultAsync();

        return Results.Ok(quote);
    }
}
