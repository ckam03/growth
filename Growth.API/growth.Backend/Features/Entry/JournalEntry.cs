namespace growth.Backend.Features.Entry;

public class JournalEntry
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Entry { get; set; } = string.Empty;
    public DateOnly JournalDate { get; set; }
    public Guid JournalId { get; set; }
}
