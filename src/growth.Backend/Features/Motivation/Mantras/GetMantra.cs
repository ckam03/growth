using growth.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace growth.Backend.Features.Motivation.Mantras;

public static class GetMantra
{
    public static RouteGroupBuilder MapGetMantra(this RouteGroupBuilder app)
    {
        app.MapGet("/", HandleAsync).CacheOutput();
        return app;
    }

    public static async Task<IResult> HandleAsync(GrowthDbContext context)
    {
        var mantra = await context.Mantras
            .OrderBy(Mantras => Guid.NewGuid())
            .ToListAsync();

        return Results.Ok(mantra);
    }
}
