using growth.Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace growth.Backend.Features.Journals;

public static class GetJournal
{
    public static RouteGroupBuilder MapGetJournal(this RouteGroupBuilder app)
    {
        app.MapGet("/{name}", GetByNameAsync);
        return app;
    }

    private static async Task<IResult> GetByNameAsync(GrowthDbContext context, string name)
    {
        var journal = await context.Journals.Where(x => x.Name == name)
                                            .Select(JournalMapper.MapToResponse)
                                            .FirstOrDefaultAsync();

        return journal is null ? Results.NotFound(name) : TypedResults.Ok(journal);
    }
    // private static async Task<IResult> GetByIdAsync(GrowthDbContext context, Guid id)
    // {
    //     var journal = await context.Journals.Where(x => x.Id == id)
    //                                         .Select(JournalMapper.MapToResponse)
    //                                         .FirstOrDefaultAsync();

    //     return journal is null ? Results.NotFound(id) : TypedResults.Ok(journal);
    // }
}
