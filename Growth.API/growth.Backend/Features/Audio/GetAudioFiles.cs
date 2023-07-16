using Microsoft.AspNetCore.Mvc;

namespace growth.Backend.Features.Audio;

public static class GetAudioFiles
{
    public static RouteGroupBuilder MapGetAudioFiles(this RouteGroupBuilder app)
    {
        app.MapGet("/", HandleAsync);
        return app;
    }

    public static async Task<IResult> HandleAsync([FromServices]IAudioService audioService)
    {
        var audio = await audioService.CreateBucket();

        return Results.Ok(audio);
    }
}
