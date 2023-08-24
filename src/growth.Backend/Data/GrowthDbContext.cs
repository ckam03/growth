using growth.Backend.Features.Entry;
using growth.Backend.Features.Journals;
using growth.Backend.Features.Motivation;
using growth.Backend.Features.Motivation.Mantras;
using Microsoft.EntityFrameworkCore;

namespace growth.Backend.Data;

public class GrowthDbContext : DbContext
{
    public GrowthDbContext(DbContextOptions<GrowthDbContext> options) : base(options)
    {
    }

    public DbSet<JournalEntry> JournalEntries => Set<JournalEntry>();
    public DbSet<Journal> Journals => Set<Journal>();
    public DbSet<DailyQuote> Quotes => Set<DailyQuote>();
    public DbSet<DailyMantra> Mantras => Set<DailyMantra>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DailyQuote>()
            .HasData(
                new DailyQuote
                {
                    Id = Guid.NewGuid(),
                    Author = "Winston Churchill",
                    Quote = "Success is not final, failure is not fatal: it is the courage to continue that counts.",
                },
                new DailyQuote
                {
                    Id = Guid.NewGuid(),
                    Author = "Nicole Kidman",
                    Quote = "Life has got all those twists and turns. You've got to hold on tight and off you go.",
                }
            );
    }
}
