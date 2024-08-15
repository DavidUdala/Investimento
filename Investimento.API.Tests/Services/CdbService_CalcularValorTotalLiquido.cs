using Investimento.API.Interfaces;
using Investimento.API.Models;
using Investimento.API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Investimento.API.Tests.Services
{
    [TestClass]
    public class CdbService_CalcularValorTotalLiquido
    {
        private readonly ICdbService _cdbService = new CdbService();

        [TestMethod]
        [DataRow(100.00, 6, 105.98, 104.63)]
        [DataRow(100.00, 7, 107.01, 105.61)]
        [DataRow(100.00, 13, 113.4, 111.06)]
        [DataRow(100.00, 25, 127.36, 123.26)]
        public void RetornaValorTotalLiquidoQuandoCalculoRealizado(double valorMonetario, int prazoEmMeses, double valorBrutoTotal, double valorLiquidoEsperado)
        {
            //Arrange
            var MetodoCalcularImposto = typeof(CdbService).GetMethod("CalcularValorTotalLiquido", BindingFlags.NonPublic | BindingFlags.Instance);

            var investimentoRequest = new InvestimentoRequest(valorMonetario, prazoEmMeses);
            //Act
            double result = (double)MetodoCalcularImposto.Invoke(_cdbService, new object[] { investimentoRequest, valorBrutoTotal });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(valorLiquidoEsperado, Math.Round(result, 2));
        }
    }
}
