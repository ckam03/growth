using growth.Backend.Data;
using growth.Backend.Shared;

namespace growth.Backend.Features.Entry.Endpoints;

public class GetJournalEntry : IEndpoint
{
    public void Map(WebApplication app)
    {
        app.MapGet("/{guid}", HandleAsync);
    }

    private async Task<IResult> HandleAsync(GrowthDbContext context, Guid id)
    {
        var entry = await context.JournalEntries.FindAsync(id);
        return entry is null ? Results.NotFound() : Results.Ok(entry);
    }
}
