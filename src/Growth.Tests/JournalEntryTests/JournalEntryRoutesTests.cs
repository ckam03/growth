using Microsoft.AspNetCore.Mvc.Testing;

namespace Growth.Tests.JournalEntryTests;

public class JournalEntryRoutesTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _webApplicationFactory;

    public JournalEntryRoutesTests(WebApplicationFactory<Program> webApplicationFactory)
    {
        _webApplicationFactory = webApplicationFactory;
    }

    [Fact]
    public async Task GetJournalEntriesAsync_Returns200()
    {
        //Arrange
        var client = _webApplicationFactory.CreateClient();
        
        //Act
        
    }
}