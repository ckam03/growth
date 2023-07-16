using Microsoft.AspNetCore.Mvc.Testing;

namespace Growth.Tests;

public class JournalEntryRouteTests
{
    [Fact]
    public async Task GetJournalsAsync_Returns200()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var response = await client.GetAsync("/journalEntry");
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task CreateJournal_Returns200()
    {
        
    }
}