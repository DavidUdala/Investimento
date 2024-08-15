using Investimento.API.Interfaces;
using Investimento.API.Models;
using Investimento.API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Investimento.API.Tests.Services
{
    [TestClass]
    public class CdbService_CalcularValorTotalBruto
    {
        private readonly ICdbService _cdbService = new CdbService();

        [TestMethod]
        [DataRow(100.00, 6, 105.98)]
        [DataRow(100.00, 7, 107.01)]
        [DataRow(100.00, 13, 113.4)]
        [DataRow(100.00, 25, 127.36)]
        public void RetornaValorTotalBrutoQuandoCalculoRealizado(double valorMonetario, int prazoEmMeses,  double valorTotalBrutoEsperado)
        {
            //Arrange
            var investimentoRequest = new InvestimentoRequest(valorMonetario, prazoEmMeses);

            //Act
            var result = _cdbService.CalcularValorTotalBruto(investimentoRequest);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(valorTotalBrutoEsperado, Math.Round(result, 2));
        }
    }
}
