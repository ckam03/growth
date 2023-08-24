using System.Text;
using Microsoft.AspNetCore.OutputCaching;

namespace growth.Backend.Caching;

public class InMemoryCache : ICacheService
{
    private readonly IOutputCacheStore _cache;

    public InMemoryCache(IOutputCacheStore cache)
    {
        _cache = cache;
    }

    public async Task SetCacheAsync(string url, CancellationToken cancellationToken)
    {
        var utf8 = new UTF8Encoding();
        byte[] imageUrl = utf8.GetBytes(url);
        //await _cache.SetAsync()
        await _cache.SetAsync("photo", imageUrl, new[] { url }, TimeSpan.MaxValue,cancellationToken);
    }
}
