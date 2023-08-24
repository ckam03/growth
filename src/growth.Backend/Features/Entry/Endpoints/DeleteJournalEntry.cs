using growth.Backend.Data;

namespace growth.Backend.Features.Entry;

public static class DeleteJournalEntry
{
    public static RouteGroupBuilder MapDeleteJournalEntry(this RouteGroupBuilder app)
    {
        app.MapDelete("/{guid}", HandleAsync);
        return app;
    }

    private static async Task<IResult> HandleAsync(GrowthDbContext context, Guid id)
    {
        var entry = await context.JournalEntries.FindAsync(id);

        if (entry is null) { return Results.NotFound(); }

        context.JournalEntries.Remove(entry);
        await context.SaveChangesAsync();

        return Results.Ok();
    }
}
