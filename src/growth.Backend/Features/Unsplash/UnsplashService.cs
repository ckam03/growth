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

    public async Task<List<UnsplashResponse>> GetPhotos()
    {
        return await _httpClient.GetFromJsonAsync<List<UnsplashResponse>>(
            $"collections/c5n86m1bPUk/photos/?client_id={_apiKey}") ?? throw new Exception();
    }

    public Task LikePhoto()
    {
        throw new NotImplementedException();
    }

    public async Task<List<UnsplashResponse>> SearchPhotos(string search)
    {
        return await _httpClient.GetFromJsonAsync<List<UnsplashResponse>>($"");
    }
}


public interface IPhotoService
{
    Task<List<UnsplashResponse>> GetPhotos();
    Task<List<UnsplashResponse>> SearchPhotos(string search);
    Task LikePhoto();
}
