namespace growth.Backend.Features.Entry;

public record CreateJournalEntryRequest(string Name, string Entry, Guid JournalId);
public record UpdateJournalEntryRequest(Guid Id, string Name, string Entry, DateOnly Date);