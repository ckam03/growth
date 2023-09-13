using growth.Backend.Shared;

namespace growth.Backend.Features.Unsplash;

public class UnsplashService : IPhotoService
{
    private readonly HttpClient _httpClient;
    private readonly string? _apiKey;

    public UnsplashService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["Unsplash:ApiKey"];
    }

    public async Task<Result<List<UnsplashResponse>>> GetPhotos()
    {
        var result = await _httpClient.GetFromJsonAsync<List<UnsplashResponse>>(
            $"collections/c5n86m1bPUk/photos/?client_id={_apiKey}");

        return result is null ? Result<List<UnsplashResponse>>.Failure("No photos found") 
                              : Result<List<UnsplashResponse>>.Success(result);
    }

    public async Task LikePhoto()
    {
        await Task.Delay(50);
    }

    public async Task<Result<List<UnsplashResponse>>> SearchPhotos(string search)
    {
        var result = await _httpClient.GetFromJsonAsync<List<UnsplashResponse>>(search);

        return result is null ? Result<List<UnsplashResponse>>.Failure("No photos found")
                              : Result<List<UnsplashResponse>>.Success(result);
    }
}


public interface IPhotoService
{
    Task<Result<List<UnsplashResponse>>> GetPhotos();
    Task<Result<List<UnsplashResponse>>> SearchPhotos(string search);
    Task LikePhoto();
}
