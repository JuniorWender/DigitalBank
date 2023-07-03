using DigitalBank.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace DigitalBank.Tests
{
    public class ContaBancariaTests
    {
        [Theory(DisplayName = "Válida intervalo com sucesso para número de conta")]
        [InlineData()]
        public void NumeroDaConta_ValidRange_ShouldPassValidation()
        {
            // Arrange
            var conta_MenorQueTresDigitos = new ContaBancaria { NumeroDaConta = 1234 };

            //Assert.Equal();
        }

        //[Fact]
        //public void NumeroDaConta_InvalidRange_ShouldFailValidation()
        //{
        //    // Arrange
        //    var conta = new ContaBancaria { NumeroDaConta = 12 };

        //    // Act
        //    var validationResult = ValidateModel(conta);

        //    // Assert
        //    var validationErrors = GetValidationErrors(validationResult);
        //    Assert.Contains("The field NumeroDaConta must be between 3 and 8.", validationErrors);
        //}

        //[Fact]
        //public void Saldo_ValidRange_ShouldPassValidation()
        //{
        //    // Arrange
        //    var conta = new ContaBancaria { Saldo = 100 };

        //    // Act
        //    var validationResult = ValidateModel(conta);

        //    // Assert
        //    Assert.Empty(validationResult);
        //}

        //[Fact]
        //public void Saldo_InvalidRange_ShouldFailValidation()
        //{
        //    // Arrange
        //    var conta = new ContaBancaria { Saldo = -50 };

        //    // Act
        //    var validationResult = ValidateModel(conta);

        //    // Assert
        //    var validationErrors = GetValidationErrors(validationResult);
        //    Assert.Contains("The field Saldo must be between 0 and 1.79769313486232E+308.", validationErrors);
        //}

        //private static List<string> GetValidationErrors(List<ValidationResult> validationResults)
        //{
        //    var errors = new List<string>();
        //    foreach (var validationResult in validationResults)
        //    {
        //        foreach (var memberName in validationResult.MemberNames)
        //        {
        //            errors.Add($"{memberName}: {validationResult.ErrorMessage}");
        //        }
        //    }
        //    return errors;
        //}

        //private static List<ValidationResult> ValidateModel(object model)
        //{
        //    var validationResults = new List<ValidationResult>();
        //    var context = new ValidationContext(model, serviceProvider: null, items: null);
        //    Validator.TryValidateObject(model, context, validationResults, validateAllProperties: true);
        //    return validationResults;
        //}
    }
}
