using growth.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace growth.Backend.Features.Journals.Endpoints;

public static class GetJournal
{
    public static RouteGroupBuilder MapGetJournal(this RouteGroupBuilder app)
    {
        app.MapGet("/{name}", GetByNameAsync);
        return app;
    }

    private static async Task<IResult> GetByNameAsync(GrowthDbContext context, string name)
    {
        var journal = await context.Journals.Where(x => x.Name == name)
                                            .Select(Mapper.ToResponse)
                                            .FirstOrDefaultAsync();

        return journal is null ? Results.NotFound(name) : TypedResults.Ok(journal);
    }
}
