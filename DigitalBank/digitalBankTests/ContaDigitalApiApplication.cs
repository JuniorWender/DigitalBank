using DigitalBank.Data.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace DigitalBankTests
{
    public class ContaDigitalApiApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<DigitalBankContext>));

                services.AddDbContext<DigitalBankContext>(options =>
                    options.UseInMemoryDatabase("DigitalBank", root));
            });
            return base.CreateHost(builder);
        }
    }
}
