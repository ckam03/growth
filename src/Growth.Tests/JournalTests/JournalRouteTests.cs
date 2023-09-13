using System.Net.Http.Json;
using growth.Backend.Features.Journals;

namespace Growth.Tests.JournalTests;

public class JournalRouteTests : IAsyncLifetime
{
    private readonly HttpClient _httpClient;
    private readonly Func<Task> _resetDatabase;

    public JournalRouteTests(GrowthApiFactory growthApiFactory)
    {
        _httpClient = growthApiFactory.HttpClient;
        _resetDatabase = growthApiFactory.ResetDatabaseAsync;
    }

    [Fact]
    public async Task GetJournalsAsync_Returns200()
    {
        //Arrange

        //Act
        var response = await _httpClient.GetAsync("/journal");

        //Assert
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task CreateJournal_Returns200()
    {
        //Arrange
        const string journalName = "JournalTest";

        //Act
        var response = await _httpClient.PostAsJsonAsync("/journal", journalName);
        var created = await response.Content.ReadFromJsonAsync<Journal>();

        //Assert
        Assert.True(created != null);
        Assert.True(created.Name.Equals("JournalTest"));
    }

    [Fact]
    public async Task DeleteJournalAsync_Returns200()
    {
        //Arrange
        //Act

        //Assert
    }

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => _resetDatabase();
}