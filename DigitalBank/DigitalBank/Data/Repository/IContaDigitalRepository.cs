using DigitalBank.Models;

namespace DigitalBank.Data.Repository
{
    public interface IContaDigitalRepository
    {
        ContaBancaria ObterContaPorNumero(int numeroDaConta);

        void AtualizarConta(ContaBancaria conta);
    }
}
