using growth.Backend.Data;
using growth.Backend.Shared;
using Microsoft.AspNetCore.Mvc;

namespace growth.Backend.Features.Journals.Endpoints;

public class DeleteJournal : IEndpoint
{
    public void Map(WebApplication app)
    {
        app.MapDelete("/journal/{id}", HandleAsync).WithTags("Journal");
    }

    private async Task<IResult> HandleAsync([FromRoute] Guid id, GrowthDbContext context)
    {
        var journal = await context.Journals.FindAsync(id);

        if (journal is null) { return Results.NotFound(); }

        context.Journals.Remove(journal);
        await context.SaveChangesAsync();

        return TypedResults.Ok();
    }
}
