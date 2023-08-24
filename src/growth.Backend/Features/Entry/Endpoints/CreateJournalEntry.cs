using FluentValidation;
using growth.Backend.Data;

namespace growth.Backend.Features.Entry;

public static class CreateJournalEntry
{
    public static RouteGroupBuilder MapCreateJournalEntry(this RouteGroupBuilder app)
    {
        app.MapPost("/", HandleAsync);
        return app;
    }

    private async static Task<IResult> HandleAsync(GrowthDbContext context, 
                                                   CreateJournalEntryRequest request, 
                                                   IValidator<JournalEntry> validator)
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

        var validationResult = await validator.ValidateAsync(entry);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        context.JournalEntries.Add(entry);
        await context.SaveChangesAsync();

        return TypedResults.Ok(entry);
    }
}
