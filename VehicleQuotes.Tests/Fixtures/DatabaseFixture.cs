using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VehicleQuotes.Api.Data;

namespace VehicleQuotes.Tests.Fixtures;

public class DatabaseFixture: IDisposable
{
    public VehicleQuotesContext Dbcontext { get; private set; }

    public DatabaseFixture()
    {
        Dbcontext = CreateDbContext();
    }

    public void Dispose()
    {
        Dbcontext.Dispose();
    }

    public VehicleQuotesContext CreateDbContext()
    {
        var host = Host.CreateDefaultBuilder().Build();
        var config = host.Services.GetRequiredService<IConfiguration>();

        var options = new DbContextOptionsBuilder<VehicleQuotesContext>()
            .UseNpgsql(config.GetConnectionString("VehicleQuotesContext"))
            .UseSnakeCaseNamingConvention()
            .Options;

        var context = new VehicleQuotesContext(options);
        
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        return context;

    }
}