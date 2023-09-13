using growth.Backend.Data;
using growth.Backend.Shared;

namespace growth.Backend.Features.Entry.Endpoints;

public class DeleteJournalEntry : IEndpoint
{
    public void Map(WebApplication app)
    {
        app.MapDelete("/{guid}", HandleAsync);
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
