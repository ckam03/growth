using growth.Backend.Data;
using growth.Backend.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace growth.Backend.Features.Journals.Endpoints;

public class GetJournals : IEndpoint
{
    public void Map(WebApplication app)
    {
        app.MapGet("/journal", HandleAsync).WithTags("Journal");
    }

    private async Task <Ok<List<JournalResponse>>> HandleAsync(GrowthDbContext context)
    {
        var journals = await context.Journals.Select(Mapper.ToResponse)
                                             .ToListAsync();

        return TypedResults.Ok(journals);
    }
}
