using growth.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace growth.Backend.Features.Entry.Endpoints;

public static class GetJournalEntries
{
    public static RouteGroupBuilder MapGetJournalEntries(this RouteGroupBuilder app)
    {
        app.MapGet("/", HandleAsync);
        return app;
    }

    private static async Task<IResult> HandleAsync(GrowthDbContext context, Guid journalId)
    {
        var entries = await context.JournalEntries
            .Where(x => x.JournalId == journalId)
            .ToListAsync();
            
        return Results.Ok(entries);
    }
}
