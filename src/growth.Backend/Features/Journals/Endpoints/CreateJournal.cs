using growth.Backend.Data;
using growth.Backend.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace growth.Backend.Features.Journals.Endpoints;

public class CreateJournal : IEndpoint
{
    public void Map(WebApplication app)
    {
        app.MapPost("/journal", HandleAsync);
    }

    private async Task<Ok<Journal>> HandleAsync(GrowthDbContext context, [FromBody] string name)
    {
        var journal = new Journal { Id = Guid.NewGuid(), Name = name };

        context.Journals.Add(journal);
        await context.SaveChangesAsync();

        return TypedResults.Ok(journal);
    }
}
