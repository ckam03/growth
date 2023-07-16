using growth.Backend.Features.Entry;
using growth.Backend.Features.Journals;
using Microsoft.EntityFrameworkCore;

namespace growth.Backend.Data;

public class GrowthDbContext : DbContext
{
    public GrowthDbContext(DbContextOptions<GrowthDbContext> options) : base(options)
    {
    }

    public DbSet<JournalEntry> JournalEntries => Set<JournalEntry>();
    public DbSet<Journal> Journals => Set<Journal>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Journal>()
            .HasData(
                new Journal
                {
                    Id = Guid.NewGuid(),
                    Name = "Test",
                },
                new Journal
                {
                    Id = Guid.NewGuid(),
                    Name = "Test2",
                }
            );
    }
}
