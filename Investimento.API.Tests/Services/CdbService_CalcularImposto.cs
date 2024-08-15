using Investimento.API.Interfaces;
using Investimento.API.Models;
using Investimento.API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
namespace Investimento.API.Tests.Services
{
    [TestClass]
    public class CdbService_CalcularImposto
    {
        private readonly ICdbService _cdbService = new CdbService();

        [TestMethod]
        [DataRow(100.00, 6, 105.98, 1.2)]
        [DataRow(100.00, 7, 107.01, 1.4)]
        [DataRow(100.00, 13, 113.4, 2.35)]
        [DataRow(100.00, 25, 127.36, 4.10)]
        public void RetornaValorImpostoQuandoImpostoCalculadoRealizado(double valorMonetario, int prazoEmMeses, double valorBrutoTotal, double impostoEsperado)
        {
            //Arrange
            var methodInfo = typeof(CdbService).GetMethod("CalcularImposto", BindingFlags.NonPublic | BindingFlags.Instance);

            if (methodInfo == null)
                Assert.Fail("Método privado não encontrado.");

            var investimentoRequest = new InvestimentoRequest(valorMonetario, prazoEmMeses);
            //Act
            double result = (double)methodInfo.Invoke(_cdbService, new object[] { investimentoRequest, valorBrutoTotal });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(impostoEsperado, Math.Round(result, 2));
        }

    }
}
