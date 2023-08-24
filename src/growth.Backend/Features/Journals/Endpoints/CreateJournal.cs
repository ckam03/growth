using growth.Backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace growth.Backend.Features.Journals.Endpoints;

public static class CreateJournal
{
    public static RouteGroupBuilder MapCreateJournal(this RouteGroupBuilder app)
    {
        app.MapPost("/", HandleAsync);
        return app;
    }

    private static async Task<IResult> HandleAsync(GrowthDbContext context, [FromBody]string name)
    {
        var journal = new Journal { Id = Guid.NewGuid(), Name = name };

        context.Journals.Add(journal);
        await context.SaveChangesAsync();

        return TypedResults.Ok(journal);
    }
}
