using System.Net.Http.Json;
using growth.Backend.Features.Journals;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace Growth.Tests.JournalTests;

public class JournalRouteTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _webApplicationFactory;

    public JournalRouteTests(WebApplicationFactory<Program> webApplicationFactory)
    {
        _webApplicationFactory = webApplicationFactory;
    }

    [Fact]
    public async Task GetJournalsAsync_Returns200()
    {
        //Arrange
        var client = _webApplicationFactory.CreateClient();

        //Act
        var response = await client.GetAsync("/journal");

        //Assert
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task CreateJournal_Returns200()
    {
        //Arrange
        var client = _webApplicationFactory.CreateClient();
        const string journalName = "JournalTest";

        //Act
        var response = await client.PostAsJsonAsync("/journal", journalName);
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
}