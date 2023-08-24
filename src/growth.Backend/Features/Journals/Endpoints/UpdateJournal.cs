using growth.Backend.Data;

namespace growth.Backend.Features.Journals.Endpoints;

public static class UpdateJournal
{
    public static RouteGroupBuilder MapUpdateJournal(this RouteGroupBuilder app)
    {
        app.MapPut("/", HandleAsync);
        return app;
    }

    public static async Task<IResult> HandleAsync(GrowthDbContext context, UpdateJournalRequest request)
    {
        var journal = await context.Journals.FindAsync(request.Id);

        if (journal is null) { return Results.BadRequest(request.Id); }

        journal.Name = request.Name;
        context.Journals.Update(journal);
        await context.SaveChangesAsync();

        return Results.Ok(journal);
    }
}
