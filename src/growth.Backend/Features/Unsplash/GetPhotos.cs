using growth.Backend.Shared;

namespace growth.Backend.Features.Unsplash;

public class GetPhotos : IEndpoint
{
    public void Map(WebApplication app)
    {
        app.MapGet("/", HandleAsync);
    }

    public async Task<IResult> HandleAsync(IPhotoService unsplashService)
    {
        var photos = await unsplashService.GetPhotos();
        return Results.Ok(photos);
    }
}
