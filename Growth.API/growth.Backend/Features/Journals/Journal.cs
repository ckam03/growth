using growth.Backend.Features.Entry;

namespace growth.Backend.Features.Journals;

public class Journal
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<JournalEntry> JournalEntries { get; set; } = null!;
}
