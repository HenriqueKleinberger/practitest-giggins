using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GigginsPractitestApi.Models;

namespace GigginsPractitestApiTests;

internal class GigginsPractitestApiApplication : WebApplicationFactory<Program>
{
    private readonly string _dbName = Guid.NewGuid().ToString();

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddScoped(sp =>
            {
                // Replace SQLite with in-memory database for tests
                return new DbContextOptionsBuilder<GigginsPractitestApiContext>()
                .UseInMemoryDatabase(_dbName)
                .UseApplicationServiceProvider(sp)
                .Options;
            });
        });

        return base.CreateHost(builder);
    }
}