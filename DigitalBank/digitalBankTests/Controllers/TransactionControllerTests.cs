using DigitalBank.Controllers;
using DigitalBank.Data.Context;
using DigitalBank.Data.Dtos;
using DigitalBank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DigitalBank.Tests
{
    public class TransactionControllerTests
    {
        private readonly Mock<DigitalBankContext> _mockContext;
        private readonly TransactionController _controller;

        public TransactionControllerTests()
        {
            _mockContext = new Mock<DigitalBankContext>(new DbContextOptions<DigitalBankContext>());
           // _controller = new TransactionController(_mockContext.Object);
        }

        [Fact(DisplayName ="Válida Saque Com Sucesso")]
        public void Sacar_ValidTransaction_ShouldUpdateAccountBalanceAndReturnOk()
        {
            // Arrange
            var conta = new ContaBancaria { NumeroDaConta = 1234, Saldo = 100 };
            var saqueRequisicao = new transacaoDto { NumeroDaConta = 1234, Valor = 50 };
            _mockContext.Setup(c => c.ContasBancarias.FirstOrDefault(It.IsAny<System.Linq.Expressions.Expression<System.Func<ContaBancaria, bool>>>()))
                        .Returns(conta);

            // Act
            var result = _controller.Sacar(saqueRequisicao) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal($"Transação bem sucedida, o seu saldo atual é R${conta.Saldo - saqueRequisicao.Valor}", result.Value);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        //[Fact]
        //public void Sacar_InvalidTransaction_ShouldReturnBadRequest()
        //{
        //    // Arrange
        //    var conta = new ContaBancaria { NumeroDaConta = 1234, Saldo = 100 };
        //    var saqueRequisicao = new transacaoDto { NumeroDaConta = 1234, Valor = 150 };
        //    _mockContext.Setup(c => c.ContasBancarias.FirstOrDefault(It.IsAny<System.Linq.Expressions.Expression<System.Func<ContaBancaria, bool>>>()))
        //                .Returns(conta);

        //    // Act
        //    var result = _controller.Sacar(saqueRequisicao) as BadRequestObjectResult;

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal("O Valor Que Deseja Sacar É Maior Que O Saldo Em Conta.", result.Value);
        //    _mockContext.Verify(c => c.SaveChanges(), Times.Never);
        //}

    }
}
