using growth.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace growth.Backend.Extensions;

public static class ServiceExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope();
        
        using var context = serviceScope.ServiceProvider.GetService<GrowthDbContext>();
        context?.Database.Migrate();
    }
}