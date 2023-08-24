namespace growth.Backend.Features.Motivation;

public class DailyQuote
{
    public Guid Id { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Quote { get; set; } = string.Empty;
}
