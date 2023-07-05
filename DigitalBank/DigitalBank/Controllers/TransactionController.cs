using DigitalBank.Data.Dtos;
using DigitalBank.Data.Repository;
using DigitalBank.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalBank.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly IContaDigitalRepository _contaDigitalRepository;

        public TransactionController(IContaDigitalRepository contaDigitalRepository)
        {
            _contaDigitalRepository = contaDigitalRepository;
        }

        // POST: api/sacar
        [HttpPost]
        [Route("sacar")]
        public IActionResult Sacar([FromBody] transacaoDto saqueRequisicao)
        {
            ContaBancaria conta = _contaDigitalRepository.ObterContaPorNumero(saqueRequisicao.NumeroDaConta); // Verifica no banco de dados se a conta existe e qual é

            if (conta != null)
            {
                if (conta.Saldo >= saqueRequisicao.Valor)
                {
                    conta.Saldo = conta.Saldo - saqueRequisicao.Valor; // Faz a subtração do saldo na conta

                    _contaDigitalRepository.AtualizarConta(conta); // Persiste a alteração no banco

                    return Ok($"Transação bem sucedida, o seu saldo atual é R${conta.Saldo}");
                }
                return BadRequest("O Valor Que Deseja Sacar É Maior Que O Saldo Em Conta.");
            }
            return BadRequest("Entre Com Um Número de Conta Válido!");
        }

        //POST api/depositar
        [HttpPost]
        [Route("depositar")]
        public IActionResult Depositar([FromBody] transacaoDto depositoRequisicao)
        {
            ContaBancaria conta = _contaDigitalRepository.ObterContaPorNumero(depositoRequisicao.NumeroDaConta); // Verifica no banco de dados se a conta existe e qual é

            if (conta != null)
            {
                if (depositoRequisicao.Valor > 0)
                {
                    conta.Saldo += depositoRequisicao.Valor; // Faz adição do valor depositado na conta 

                    _contaDigitalRepository.AtualizarConta(conta); // Persiste a alteração no banco

                    return Ok($"Deposito bem sucedida, o seu saldo atual é R${conta.Saldo}");
                }
                return BadRequest("Deposite Um Valor Válido!");
            }
            return BadRequest("Entre Com Um Número de Conta Válido!");
        }

        // GET api/saldo
        [HttpGet]
        [Route("saldo")]
        public IActionResult Saldo([FromHeader] int numeroDaConta)
        {
            ContaBancaria conta = _contaDigitalRepository.ObterContaPorNumero(numeroDaConta); // Verifica no banco de dados se a conta existe e qual é

            if (conta != null)
            {
                return Ok($"Esta Conta Está Em Nome De {conta.Nome} e o seu saldo atual é: R${conta.Saldo}");
            }
            return BadRequest("Entre Com Um Número de Conta Válido!");
        }

        //POST api/transferencia
        [HttpPost]
        [Route("transferir")]
        public IActionResult Transferencia([FromBody] transferenciaDto transferenciaRequisicao)
        {
            ContaBancaria contaOrigem = _contaDigitalRepository.ObterContaPorNumero(transferenciaRequisicao.NumeroDaContaOrigem); // Verifica no banco de dados se a conta de origem existe e qual é
            ContaBancaria contaDestino = _contaDigitalRepository.ObterContaPorNumero(transferenciaRequisicao.NumeroDaContaDestino); // Verifica no banco de dados se a conta de destino existe e qual é

            if (contaOrigem != null && contaDestino != null)
            {
                if (contaOrigem.Saldo >= transferenciaRequisicao.Valor)
                {
                    contaOrigem.Saldo = contaOrigem.Saldo - transferenciaRequisicao.Valor; // Faz a subtração do saldo na conta de origem pelo valor transferido
                    contaDestino.Saldo += transferenciaRequisicao.Valor; // Faz a Adição do saldo na conta de Destino pelo valor transferido

                    _contaDigitalRepository.AtualizarConta(contaOrigem); // Atualiza no banco o saldo da conta de origem
                    _contaDigitalRepository.AtualizarConta(contaDestino); // Atualiza no banco o saldo da conta da conta Destino

                    return Ok($"Transação bem sucedida, o seu saldo atual é R${contaOrigem.Saldo}");
                }
                return BadRequest("O Valor Que Deseja Transferir É Maior Que O Saldo Em Conta.");
            }
            return BadRequest("Entre Com Um Número de Conta Válido!");
        }

    }
}
