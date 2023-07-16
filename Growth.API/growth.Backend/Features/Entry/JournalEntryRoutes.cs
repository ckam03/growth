using growth.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace growth.Backend.Features.Entry;

public static class JournalEntryRoutes
{
    public static RouteGroupBuilder MapJournalEntryRoutes(this RouteGroupBuilder app)
    {
        app.MapGet("/", GetJournalsAsync);
        app.MapGet("/{id}", GetByIdAsync);
        app.MapPost("/", CreateJournalEntry);
        app.MapPut("/", UpdateJournalEntry);

        return app;
    }

    private static async Task<IResult> GetJournalsAsync(GrowthDbContext context)
    {
        List<JournalEntry> entries = await context.JournalEntries.ToListAsync();
        return Results.Ok(entries);
    }

    private static async Task<IResult> GetByIdAsync(GrowthDbContext context, Guid id)
    {
        var journal = await context.JournalEntries.FindAsync(id);
        return Results.Ok(journal);
    }

    private static async Task<IResult> CreateJournalEntry(GrowthDbContext context, CreateJournalRequest request)
    {
        var journal = await context.Journals.FindAsync(request.JournalId);

        if (journal is null) { return Results.NotFound(); }
        
        var entry = new JournalEntry
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Entry = request.Entry,
            JournalDate = DateOnly.FromDateTime(DateTime.Now),
            JournalId = journal.Id,
        };

        context.JournalEntries.Add(entry);
        await context.SaveChangesAsync();

        return TypedResults.Ok(entry);
    }

    private static async Task<IResult> UpdateJournalEntry(GrowthDbContext context, CreateJournalRequest request)
    {
        return Results.Ok();
    }
}