namespace growth.Backend.Features.Journals;

public record CreateJournalRequest(string Name);

public record UpdateJournalRequest(Guid Id, string Name);
