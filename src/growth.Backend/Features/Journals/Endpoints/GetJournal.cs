using growth.Backend.Data;
using growth.Backend.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace growth.Backend.Features.Journals.Endpoints;

public class GetJournal : IEndpoint
{
    public void Map(WebApplication app)
    {
        app.MapGet("/journal/{name}", HandleAsync);
    }

    private async Task<Results<Ok<JournalResponse>, NotFound<string>>> HandleAsync(GrowthDbContext context,
                                                                                   string name)
    {
        var journal = await context.Journals.Where(x => x.Name == name)
                                            .Select(Mapper.ToResponse)
                                            .FirstOrDefaultAsync();

        return journal is null ? TypedResults.NotFound(name) : TypedResults.Ok(journal);
    }
}
