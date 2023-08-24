using growth.Backend.Data;

namespace growth.Backend.Features.Entry;

public static class UpdateJournalEntry
{
    public static RouteGroupBuilder MapUpdateJournalEntry(this RouteGroupBuilder app)
    {
        app.MapPut("/", HandleAsync);
        return app;
    }

    private static async Task<IResult> HandleAsync(GrowthDbContext context,
                                                   UpdateJournalEntryRequest request)
    {
        var entry = await context.JournalEntries.FindAsync(request.Id);
        if (entry is null) { return Results.NotFound(); }

        entry.Name = request.Name;
        entry.Entry = request.Entry;
        entry.JournalDate = request.Date;

        context.JournalEntries.Update(entry);
        await context.SaveChangesAsync();

        return Results.Ok(entry);
    }
}
