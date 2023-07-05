using DigitalBank.Data.Dtos;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework.Interfaces;
using System.Net;
using System.Net.Http.Json;

namespace DigitalBankTests
{
    public class ApiDigitalBankIntegrationTest
    {

        //---------------------------------------------------------------------------------------- Testes Método Sacar (TransactionController) --------------------------------------------------------------------------------------------

        [Test]
        [TestCase(1234, 99)]
        public async Task POST_Sacar_Retorna_Novo_Saldo(int numeroDaConta, float valor)
        {
            await using var application = new ContaDigitalApiApplication();

            await ContasMockData.CreateContas(application, true);

            var url = "api/sacar";

            var client = application.CreateClient();

            var saqueRequisicao = new transacaoDto { NumeroDaConta = numeroDaConta, Valor = valor };

            var result = await client.PostAsJsonAsync(url, saqueRequisicao);

            var content = await result.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(content.Contains("Transação bem sucedida, o seu saldo atual é R$"));
        }

        [Test]
        [TestCase(1234, 101)]
        public async Task POST_Sacar_Retorna_Saldo_Insuficiente(int numeroDaConta, float valor)
        {
            await using var application = new ContaDigitalApiApplication();

            await ContasMockData.CreateContas(application, true);

            var url = "api/sacar";

            var client = application.CreateClient();

            var saqueRequisicao = new transacaoDto { NumeroDaConta = numeroDaConta, Valor = valor };

            var result = await client.PostAsJsonAsync(url, saqueRequisicao);

            var content = await result.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.AreEqual(content, "O Valor Que Deseja Sacar É Maior Que O Saldo Em Conta.");
        }

        [Test]
        [TestCase(0000, 101)]
        public async Task POST_Sacar_Retorna_Conta_Invalida(int numeroDaConta, float valor)
        {
            await using var application = new ContaDigitalApiApplication();

            await ContasMockData.CreateContas(application, true);

            var url = "api/sacar";

            var client = application.CreateClient();

            var saqueRequisicao = new transacaoDto { NumeroDaConta = numeroDaConta, Valor = valor };

            var result = await client.PostAsJsonAsync(url, saqueRequisicao);

            var content = await result.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.AreEqual(content, "Entre Com Um Número de Conta Válido!");
        }


        //---------------------------------------------------------------------------------------- Testes Método Depositar (TransactionController) --------------------------------------------------------------------------------------------

        [Test]
        [TestCase(1234, 99)]
        public async Task POST_Depositar_Retorna_Novo_Saldo(int numeroDaConta, float valor)
        {
            await using var application = new ContaDigitalApiApplication();

            await ContasMockData.CreateContas(application, true);

            var url = "api/depositar";

            var client = application.CreateClient();

            var depositoRequisicao = new transacaoDto { NumeroDaConta = numeroDaConta, Valor = valor };

            var result = await client.PostAsJsonAsync(url, depositoRequisicao);

            var content = await result.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(content.Contains("Deposito bem sucedida, o seu saldo atual é R$"));
        }

        [Test]
        [TestCase(1234, -101)]
        public async Task POST_Depositar_Retorna_Saldo_Insuficiente(int numeroDaConta, float valor)
        {
            await using var application = new ContaDigitalApiApplication();

            await ContasMockData.CreateContas(application, true);

            var url = "api/depositar";

            var client = application.CreateClient();

            var depositoRequisicao = new transacaoDto { NumeroDaConta = numeroDaConta, Valor = valor };

            var result = await client.PostAsJsonAsync(url, depositoRequisicao);

            var content = await result.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.AreEqual(content, "Deposite Um Valor Válido!");
        }

        [Test]
        [TestCase(0000, 101)]
        public async Task POST_Depositar_Retorna_Conta_Invalida(int numeroDaConta, float valor)
        {
            await using var application = new ContaDigitalApiApplication();

            await ContasMockData.CreateContas(application, true);

            var url = "api/depositar";

            var client = application.CreateClient();

            var depositoRequisicao = new transacaoDto { NumeroDaConta = numeroDaConta, Valor = valor };

            var result = await client.PostAsJsonAsync(url, depositoRequisicao);

            var content = await result.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.AreEqual(content, "Entre Com Um Número de Conta Válido!");
        }

        //---------------------------------------------------------------------------------------- Testes Método Saldo (TransactionController) --------------------------------------------------------------------------------------------

        [Test]
        [TestCase(1234)]
        public async Task GET_Saldo_Retorna_Saldo(int numeroDaConta)
        {
            await using var application = new ContaDigitalApiApplication();

            await ContasMockData.CreateContas(application, true);

            var url = "api/saldo";

            var client = application.CreateClient();

            client.DefaultRequestHeaders.Add("NumeroDaConta", numeroDaConta.ToString());

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(content.Contains("Esta Conta Está Em Nome De"));
        }

        [Test]
        [TestCase(0000)]
        public async Task GET_Saldo_Retorna_Conta_Invalida(int numeroDaConta)
        {
            await using var application = new ContaDigitalApiApplication();

            await ContasMockData.CreateContas(application, true);

            var url = "api/saldo";

            var client = application.CreateClient();

            client.DefaultRequestHeaders.Add("NumeroDaConta", numeroDaConta.ToString());

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.AreEqual(content, "Entre Com Um Número de Conta Válido!");
        }

        //---------------------------------------------------------------------------------------- Testes Método Transferencia (TransactionController) --------------------------------------------------------------------------------------------

        [Test]
        [TestCase(1234, 12345678, 50)]
        public async Task POST_Transferencia_Retorna_Novo_Saldo(int numeroDaContaOrigem,int numeroDaContaDestino, float valor)
        {
            await using var application = new ContaDigitalApiApplication();

            await ContasMockData.CreateContas(application, true);

            var url = "api/transferir";

            var client = application.CreateClient();

            var transferenciaRequisicao = new transferenciaDto { NumeroDaContaOrigem = numeroDaContaOrigem , NumeroDaContaDestino = numeroDaContaDestino, Valor = valor };

            var result = await client.PostAsJsonAsync(url, transferenciaRequisicao);

            var content = await result.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(content.Contains("Transação bem sucedida, o seu saldo atual é R$"));
        }

        [Test]
        [TestCase(1234, 12345678, 200)]
        public async Task POST_Transferencia_Retorna_Saldo_Insuficiente(int numeroDaContaOrigem, int numeroDaContaDestino, float valor)
        {
            await using var application = new ContaDigitalApiApplication();

            await ContasMockData.CreateContas(application, true);

            var url = "api/transferir";

            var client = application.CreateClient();

            var transferenciaRequisicao = new transferenciaDto { NumeroDaContaOrigem = numeroDaContaOrigem, NumeroDaContaDestino = numeroDaContaDestino, Valor = valor };

            var result = await client.PostAsJsonAsync(url, transferenciaRequisicao);

            var content = await result.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.AreEqual(content, "O Valor Que Deseja Transferir É Maior Que O Saldo Em Conta.");
        }

        [Test]
        [TestCase(0000, 7891, 101)]
        public async Task POST_Transferencia_Retorna_Conta_Invalida(int numeroDaContaOrigem, int numeroDaContaDestino, float valor)
        {
            await using var application = new ContaDigitalApiApplication();

            await ContasMockData.CreateContas(application, true);

            var url = "api/transferir";

            var client = application.CreateClient();

            var transferenciaRequisicao = new transferenciaDto { NumeroDaContaOrigem = numeroDaContaOrigem, NumeroDaContaDestino = numeroDaContaDestino, Valor = valor };

            var result = await client.PostAsJsonAsync(url, transferenciaRequisicao);

            var content = await result.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.AreEqual(content, "Entre Com Um Número de Conta Válido!");
        }
    }
}