using Investimento.API.Interfaces;
using Investimento.API.Models;
using Investimento.API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
namespace Investimento.API.Tests.Services
{
    [TestClass]
    public class CdbService_CalcularImposto
    {
        private readonly ICdbService _cdbService = new CdbService();

        [TestMethod]
        public void RetornaValorImpostoQuandoCalculoRealiado()
        {
            //Arrange
            var methodInfo = typeof(CdbService).GetMethod("CalcularImposto", BindingFlags.NonPublic | BindingFlags.Instance);

            if (methodInfo == null)
                Assert.Fail("Método privado não encontrado.");
            //Act
            var result = (double)methodInfo.Invoke(_cdbService, new object[] {new InvestimentoRequest(100,6), 100 }); 

            //Assert
            Assert.IsNotNull(result);
        }

    }
}
