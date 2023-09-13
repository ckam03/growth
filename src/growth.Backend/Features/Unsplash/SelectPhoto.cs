using growth.Backend.Shared;

namespace growth.Backend.Features.Unsplash;

public class SelectPhoto : IEndpoint
{
    //this would need the id to store in the database so whenever the page loads, it hits the api for the specific photo
    public void Map(WebApplication app)
    {
        app.MapPost("/", HandleAsync);
    }

    public async Task<IResult> HandleAsync()
    {
        return Results.Ok();
    }
}
