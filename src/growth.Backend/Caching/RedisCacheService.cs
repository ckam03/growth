using Microsoft.Extensions.Caching.Distributed;

namespace growth.Backend.Caching;

public class RedisCacheService
{
    private readonly IDistributedCache _distributedCache;
    
    public RedisCacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }
}
