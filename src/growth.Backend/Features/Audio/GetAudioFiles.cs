using growth.Backend.Shared;
using Microsoft.AspNetCore.Mvc;

namespace growth.Backend.Features.Audio;

public class GetAudioFiles : IEndpoint
{
    public void Map(WebApplication app)
    {
        app.MapGet("/", HandleAsync);
    }

    public async Task<IResult> HandleAsync([FromServices]IAudioService audioService)
    {
        var audio = await audioService.CreateBucket();

        return Results.Ok(audio);
    }
}
