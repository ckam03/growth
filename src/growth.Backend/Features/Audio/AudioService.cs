using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;

namespace growth.Backend.Features.Audio;

public class AudioService : IAudioService
{
    private readonly string _projectId = "growth-f53da";
    private readonly string _bucketName = "growth-f53da.appspot.com";
    private readonly ILogger _logger;
    private readonly StorageClient _storageClient;
    public AudioService(ILogger<AudioService> logger)
    {
        _logger = logger;
    }

    public async Task<Bucket> CreateBucket()
    {
        StorageClient storage = await StorageClient.CreateAsync();
        var file = await storage.GetBucketAsync(_bucketName);
        _logger.LogInformation(file.Id, file.Location);
        return file;
    }
}

public interface IAudioService
{
    Task<Bucket> CreateBucket();
}