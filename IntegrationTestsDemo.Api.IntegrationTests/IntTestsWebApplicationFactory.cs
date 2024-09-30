using IntegrationTestsDemo.Api.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace IntegrationTestsDemo.Api.IntegrationTests;

public class IntTestsWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private ITestDatabase _database = null!;

    public HttpClient HttpClient { get; private set; } = default!;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(servicesConfiguration =>
        {
            servicesConfiguration
            .RemoveAll<DbContextOptions<SqlDbContext>>()
            .AddDbContext<SqlDbContext>(options => options.UseSqlServer(_database.GetConnection()));
        });
    }

    public async Task ResetDatabaseAsync()
    {
        await _database.ResetAsync();
    }

    public async Task InitializeAsync()
    {
        _database = await TestDatabaseFactory.CreateAsync();
        HttpClient = CreateClient();
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await _database.DisposeAsync();
    }
}
