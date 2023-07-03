using DigitalBank.Data.Context;
using DigitalBank.Data.Dtos;
using DigitalBank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalBank.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly DigitalBankContext _context;

        public TransactionController(DigitalBankContext context)
        {
            _context = context;
        }

        // POST: api/sacar
        [HttpPost]
        [Route("sacar")]
        public IActionResult Sacar([FromBody] transacaoDto saqueRequisicao)
        {
            ContaBancaria conta = _context.ContasBancarias.FirstOrDefault(x => x.NumeroDaConta == saqueRequisicao.NumeroDaConta);
            if (conta != null)
            {
                if (conta.Saldo >= saqueRequisicao.Valor)
                {
                    conta.Saldo = conta.Saldo - saqueRequisicao.Valor;
                    _context.ContasBancarias.Update(conta);
                    _context.SaveChanges();
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
            ContaBancaria conta = _context.ContasBancarias.FirstOrDefault(x => x.NumeroDaConta == depositoRequisicao.NumeroDaConta);

            if (conta != null)
            {
                if (depositoRequisicao.Valor > 0) 
                {
                    conta.Saldo += depositoRequisicao.Valor;
                    _context.ContasBancarias.Update(conta);
                    _context.SaveChanges();
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
            ContaBancaria conta = _context.ContasBancarias.FirstOrDefault(x => x.NumeroDaConta == numeroDaConta);
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
            ContaBancaria contaOrigem = _context.ContasBancarias.FirstOrDefault(x => x.NumeroDaConta == transferenciaRequisicao.NumeroDaContaOrigem);
            ContaBancaria contaDestino = _context.ContasBancarias.FirstOrDefault(x => x.NumeroDaConta == transferenciaRequisicao.NumeroDaContaDestino);

            if (contaOrigem != null && contaDestino != null)
            {
                if (contaOrigem.Saldo >= transferenciaRequisicao.Valor)
                {
                    contaOrigem.Saldo -= transferenciaRequisicao.Valor;
                    _context.ContasBancarias.Update(contaOrigem);

                    contaDestino.Saldo += transferenciaRequisicao.Valor;
                    _context.ContasBancarias.Update(contaDestino);

                    _context.SaveChanges();
                    return Ok($"Transação bem sucedida, o seu saldo atual é R${contaOrigem.Saldo}");
                }
                return BadRequest("O Valor Que Deseja Transferir É Maior Que O Saldo Em Conta.");
            }
            return BadRequest("Entre Com Um Número de Conta Válido!");
        }

    }
}
