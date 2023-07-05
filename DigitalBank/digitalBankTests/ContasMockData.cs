using DigitalBank.Data.Context;
using DigitalBank.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalBankTests
{
    public class ContasMockData
    {
        public static async Task CreateContas(ContaDigitalApiApplication application, bool criar)
        {
            using (var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var mockDbContext = provider.GetRequiredService<DigitalBankContext>())
                {
                    await mockDbContext.Database.EnsureCreatedAsync();

                    if (criar)
                    {
                        await mockDbContext.ContasBancarias.AddAsync(new ContaBancaria
                        { Nome = "Joaozinho", NumeroDaConta = 1234 , Saldo= 100 });

                        await mockDbContext.ContasBancarias.AddAsync(new ContaBancaria
                        { Nome = "Matheus", NumeroDaConta = 12345678, Saldo = 300 });

                        await mockDbContext.ContasBancarias.AddAsync(new ContaBancaria
                        { Nome = "Stefani", NumeroDaConta = 4567, Saldo = 500 });

                        await mockDbContext.ContasBancarias.AddAsync(new ContaBancaria
                        { Nome = "Maria", NumeroDaConta = 7891, Saldo = 1 });

                        await mockDbContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
