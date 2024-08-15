using Investimento.API.Controllers;
using Investimento.API.Interfaces;
using Investimento.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace Investimento.API.Tests.Controllers
{
    [TestClass]
    public class CdbController_SimulacaoResgateAplicacaoTest
    {
        private Mock<ICdbService> _mockCdbService;
        private CdbController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockCdbService = new Mock<ICdbService>();
            _controller = new CdbController(_mockCdbService.Object);
        }

        [TestMethod]
        public void QuandoSucessoRetonaHttpStatusSuccess()
        {
            //Arrange
            Setup();
            var investimentoRequest = new InvestimentoRequest(100, 7);
            var resultadoEsperado = new InvestimentoResponse(100,100);
            _mockCdbService.Setup(service => service.Calcular(investimentoRequest)).Returns(resultadoEsperado);

            //Act
            var resultado = _controller.SimulacaoResgateAplicacao(investimentoRequest) as OkNegotiatedContentResult<InvestimentoResponse>;

            //Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(resultadoEsperado, resultado.Content);
        }
        [TestMethod]
        public void QuandoRequestInvalidoRetonaHttpStatusBadRequest()
        {
            Setup();
            //Arrange
            var investimentoRequest = new InvestimentoRequest(-10, -1);
            string resultadoEsperado = "Informe um valor monetário e um mês que seja válido.";

            //Act
            var resultado = _controller.SimulacaoResgateAplicacao(investimentoRequest) as BadRequestErrorMessageResult;

            //Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(resultadoEsperado, resultado.Message);
        }
    }
}
