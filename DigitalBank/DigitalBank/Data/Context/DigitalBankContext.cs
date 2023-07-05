using DigitalBank.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DigitalBank.Data.Context
{
    public class DigitalBankContext : DbContext
    {
        public DigitalBankContext(DbContextOptions<DigitalBankContext> opt) : base(opt) { }

        public DbSet<ContaBancaria> ContasBancarias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContaBancaria>().ToTable("Contas");
            modelBuilder.Entity<ContaBancaria>().HasKey(k => k.Id);
            modelBuilder.Entity<ContaBancaria>().Property(n => n.Nome).IsRequired();
            modelBuilder.Entity<ContaBancaria>().Property(c => c.NumeroDaConta).IsRequired().HasMaxLength(8); // Definido o tamanho máximo do número da conta bancaria para 8 digitos
            modelBuilder.Entity<ContaBancaria>().Property(c => c.Saldo).IsRequired().HasColumnType("decimal(18,2)").HasDefaultValue(0); // Definido o Valor inicial do item "saldo" para 0

            // Configuração para garantir que o número da conta seja único
            modelBuilder.Entity<ContaBancaria>().HasIndex(c => c.NumeroDaConta).IsUnique();

            base.OnModelCreating(modelBuilder);
        }

    }

}
