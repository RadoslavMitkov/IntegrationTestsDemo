using IntegrationTestsDemo.Api.Models;
using System.Net.Http.Json;

namespace IntegrationTestsDemo.Api.IntegrationTests;

[Collection("Shared test collection")]
public class TestController1 : IAsyncLifetime
{
    private readonly HttpClient _httpClient;
    private readonly Func<Task> _resetDatabase;

    public TestController1(IntTestsWebApplicationFactory applicationFactory)
    {
        _httpClient = applicationFactory.HttpClient;
        _resetDatabase = applicationFactory.ResetDatabaseAsync;
    }

    [Fact]
    public async Task TestExample()
    {
        var preResult = await _httpClient.GetFromJsonAsync<Customer[]>(new Uri(@"http://localhost:5233/api/customers"));

        await _httpClient.PostAsJsonAsync(new Uri(@"http://localhost:5233/api/customers"), new Customer { FirstName = "Pesho", LastName = "Geshov" });

        var postResult = await _httpClient.GetFromJsonAsync<Customer[]>(new Uri(@"http://localhost:5233/api/customers"));
    }

    public Task InitializeAsync() => Task.CompletedTask;

    public Task DisposeAsync() => _resetDatabase();
}