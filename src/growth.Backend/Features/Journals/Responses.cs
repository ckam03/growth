namespace growth.Backend.Features.Journals;

public record JournalResponse(Guid Id, string Name, List<JournalEntryResponse> JournalEntries);
public record JournalEntryResponse(Guid Id, string Name, string Entry, DateOnly Date);
