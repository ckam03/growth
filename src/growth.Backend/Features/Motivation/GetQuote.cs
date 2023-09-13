using growth.Backend.Data;
using growth.Backend.Shared;
using Microsoft.EntityFrameworkCore;

namespace growth.Backend.Features.Motivation;

public class GetQuote : IEndpoint
{
    //need to make this cache at the start of a new day
    public void Map(WebApplication app)
    {
        app.MapGet("/", HandleAsync).CacheOutput();
    }

    public async Task<IResult> HandleAsync(GrowthDbContext context)
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
