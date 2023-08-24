namespace growth.Backend.Features.Unsplash;

public static class SelectPhoto
{
    //this would need the id to store in the database so whenever the page loads, it hits the api for the specific photo
    public static RouteGroupBuilder MapSelectPhoto(this RouteGroupBuilder app)
    {
        app.MapPost("/", HandleAsync);
        return app;
    }

    public static async Task<IResult> HandleAsync()
    {
        return Results.Ok();
    }
}
