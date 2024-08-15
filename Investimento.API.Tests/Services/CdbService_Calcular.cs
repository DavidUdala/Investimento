using Investimento.API.Services;
using Investimento.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Investimento.API.Interfaces;

namespace Investimento.API.Tests.Services
{
    [TestClass]
    public class CdbService_Calcular
    {
        private readonly ICdbService _cdbService = new CdbService();

        [TestMethod]
        [DataRow(100.00, 6, 105.98, 104.63)]
        [DataRow(100.00, 7, 107.01, 105.6)]
        [DataRow(100.00, 13, 113.4, 111.05)]
        [DataRow(100.00, 25, 127.36, 123.25)]
        public void RetornaValorLiquidoEValorBrutoComtemplandoTaxasDeImposto(double valorMonetario, int prazoEmMeses, double valorTotalBrutoEsperado, double ValorTotalLiquidoEsperado)
        {
            //Arrange
            InvestimentoRequest investimentoRequest = new InvestimentoRequest(valorMonetario, prazoEmMeses);
            InvestimentoResponse resultadoEsperado = new InvestimentoResponse(valorTotalBrutoEsperado, ValorTotalLiquidoEsperado);

            //Act
            var resultado = _cdbService.Calcular(investimentoRequest);

            //Assert
            Assert.IsNotNull(investimentoRequest);
            Assert.AreEqual(resultado.ValorTotalLiquido, resultadoEsperado.ValorTotalLiquido);
            Assert.AreEqual(resultado.ValorTotalBruto, resultadoEsperado.ValorTotalBruto);
        }
    }
}
