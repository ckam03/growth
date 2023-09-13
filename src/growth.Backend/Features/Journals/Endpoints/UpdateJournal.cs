using growth.Backend.Data;
using growth.Backend.Shared;
using Microsoft.AspNetCore.Http.HttpResults;

namespace growth.Backend.Features.Journals.Endpoints;

public class UpdateJournal : IEndpoint
{
    public void Map(WebApplication app)
    {
        app.MapPut("/journal", HandleAsync);
    }

    private async Task<Results<Ok<Journal>, BadRequest<Guid>>> HandleAsync(GrowthDbContext context, 
                                                                           UpdateJournalRequest request)
    {
        var journal = await context.Journals.FindAsync(request.Id);

        if (journal is null) { return TypedResults.BadRequest(request.Id); }

        journal.Name = request.Name;
        context.Journals.Update(journal);
        await context.SaveChangesAsync();

        return TypedResults.Ok(journal);
    }
}

public record UpdateJournalRequest(Guid Id, string Name);