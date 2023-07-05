using DigitalBank.Data.Context;
using DigitalBank.Models;

namespace DigitalBank.Data.Repository
{
    public class ContaDigitalRepository : IContaDigitalRepository
    {
        private readonly DigitalBankContext _context;

        public ContaDigitalRepository(DigitalBankContext context)
        {
            _context = context;
        }

        public ContaBancaria ObterContaPorNumero(int numeroDaConta)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return _context.ContasBancarias.FirstOrDefault(x => x.NumeroDaConta == numeroDaConta);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        public void AtualizarConta(ContaBancaria conta)
        {
            _context.ContasBancarias.Update(conta);
            _context.SaveChanges();
        }

    }
}
