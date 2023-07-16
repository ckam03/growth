using growth.Backend.Data;

namespace growth.Backend.Features.Journals;

public static class CreateJournal
{
    public static RouteGroupBuilder MapCreateJournal(this RouteGroupBuilder app)
    {
        app.MapPost("/", HandleAsync);
        return app;
    }

    public static async Task<IResult> HandleAsync(GrowthDbContext context, JournalRequest request)
    {
        var journal = new Journal { Id = Guid.NewGuid(), Name = request.Name };
        context.Journals.Add(journal);
        await context.SaveChangesAsync();

        return TypedResults.Ok(journal);
    }
}
