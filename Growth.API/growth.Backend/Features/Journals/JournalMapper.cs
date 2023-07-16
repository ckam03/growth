using System.Linq.Expressions;

namespace growth.Backend.Features.Journals;

public static class JournalMapper
{
    public static Expression<Func<Journal, JournalResponse>> MapToResponse = (journal) => new JournalResponse(
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
