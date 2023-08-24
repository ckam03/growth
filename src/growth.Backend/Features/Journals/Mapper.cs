using System.Linq.Expressions;

namespace growth.Backend.Features.Journals;

public static class Mapper
{
    public static Expression<Func<Journal, JournalResponse>> ToResponse = (journal) => new JournalResponse(
            journal.Id,
            journal.Name,
            journal.JournalEntries.Select(x => new JournalEntryResponse(
            x.Id, 
            x.Name, 
            x.Entry,
            x.JournalDate
            )).ToList()
        );
}
