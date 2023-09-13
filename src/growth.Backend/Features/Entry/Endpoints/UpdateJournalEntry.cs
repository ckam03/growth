using growth.Backend.Data;
using growth.Backend.Shared;
using Microsoft.AspNetCore.Http.HttpResults;

namespace growth.Backend.Features.Entry.Endpoints;

public class UpdateJournalEntry : IEndpoint
{
    public void Map(WebApplication app)
    {
        app.MapPut("/", HandleAsync);
    }

    private async Task<Results<Ok<JournalEntry>, NotFound>> HandleAsync(GrowthDbContext context,
                                                                        UpdateJournalEntryRequest request)
    {
        var entry = await context.JournalEntries.FindAsync(request.Id);
        if (entry is null) { return TypedResults.NotFound(); }

        entry.Name = request.Name;
        entry.Entry = request.Entry;
        entry.JournalDate = request.Date;

        context.JournalEntries.Update(entry);
        await context.SaveChangesAsync();

        return TypedResults.Ok(entry);
    }
}

public record UpdateJournalEntryRequest(
    Guid Id,
    string Name,
    string Entry,
    DateOnly Date);
