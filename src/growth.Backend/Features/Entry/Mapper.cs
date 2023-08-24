using System.Linq.Expressions;

namespace growth.Backend.Features.Entry;

public static class Mapper
{
    public static Expression<Func<UpdateJournalEntryRequest, JournalEntry>> ToModel = journalEntry => new JournalEntry
    {
        Name = journalEntry.Name,
        Entry = journalEntry.Entry,
        JournalDate = journalEntry.Date
    };
}
