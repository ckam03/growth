namespace growth.Backend;

public record CreateJournalRequest(string Name, string Entry, Guid JournalId);
