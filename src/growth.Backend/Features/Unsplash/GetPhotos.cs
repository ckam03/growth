namespace growth.Backend.Features.Unsplash;

public static class GetPhotos
{
    public static RouteGroupBuilder MapGetPhotos(this RouteGroupBuilder app)
    {
        app.MapGet("/", HandleAsync);
        return app;
    }

    public static async Task<IResult> HandleAsync(IPhotoService unsplashService)
    {
        var photos = await unsplashService.GetPhotos();
        return Results.Ok(photos);
    }
}
