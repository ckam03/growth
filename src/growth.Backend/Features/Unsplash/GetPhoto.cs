using System.Text;
using growth.Backend.Shared;
using Microsoft.AspNetCore.OutputCaching;

namespace growth.Backend.Features.Unsplash;

public class GetPhoto : IEndpoint
{
    //make this a photo of the day
    public void Map(WebApplication app)
    {
        app.MapGet("/", HandleAsync);
    }
 
    private async Task<IResult> HandleAsync(HttpContext context)
    {
        await context.Response.WriteAsJsonAsync("https://images.unsplash.com/photo-1568745515327-eedc40b0b3cf?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3wyOTQ1NTd8MHwxfGNvbGxlY3Rpb258MXxjNW44Nm0xYlBVa3x8fHx8Mnx8MTY5MDY0NjAyOHw&ixlib=rb-4.0.3&q=80&w=200");
        return Results.Ok();
    }
}
