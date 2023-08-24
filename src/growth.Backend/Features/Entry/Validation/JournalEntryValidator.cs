using FluentValidation;

namespace growth.Backend.Features.Entry;

public class JournalEntryValidator : AbstractValidator<JournalEntry>
{
    public JournalEntryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Entry must have a title");
    }
}
