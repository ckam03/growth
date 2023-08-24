namespace growth.Backend.Caching;

public interface ICacheService
{
    Task SetCacheAsync(string url, CancellationToken cancellationToken);
}
