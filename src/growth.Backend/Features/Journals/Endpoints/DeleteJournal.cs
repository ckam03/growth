using growth.Backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace growth.Backend.Features.Journals.Endpoints;

public static class DeleteJournal
{
    public static RouteGroupBuilder MapDeleteJournal(this RouteGroupBuilder app)
    {
        app.MapDelete("/{id}", HandleAsync);
        
        return app;
    }

    public static async Task<IResult> HandleAsync([FromRoute]Guid id, GrowthDbContext context)
    {
        var journal = await context.Journals.FindAsync(id);

        if (journal is null) { return Results.NotFound(); }

        context.Journals.Remove(journal);
        await context.SaveChangesAsync();

        return TypedResults.Ok();
    }
}
