using growth.Backend.Data;

namespace growth.Backend.Features.Entry;

public static class GetJournalEntry
{
    public static RouteGroupBuilder MapGetJournalEntry(this RouteGroupBuilder app)
    {
        app.MapGet("/{guid}", HandleAsync);
        return app;
    }

    private static async Task<IResult> HandleAsync(GrowthDbContext context, Guid id)
    {
        var entry = await context.JournalEntries.FindAsync(id);
        return entry is null ? Results.NotFound() : Results.Ok(entry);
    }
}
