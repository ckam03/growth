using growth.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace growth.Backend.Features.Journals.Endpoints;

public static class GetJournals
{
    public static RouteGroupBuilder MapGetJournals(this RouteGroupBuilder app)
    {
        app.MapGet("/", HandleAsync);
        return app;
    }
    public static async Task<IResult> HandleAsync(GrowthDbContext context) 
    {
        var journals = await context.Journals.Select(Mapper.ToResponse)
                                             .ToListAsync();
        return TypedResults.Ok(journals);
    }
}
 