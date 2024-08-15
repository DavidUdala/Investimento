using Investimento.API.Interfaces;
using Investimento.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;

namespace Investimento.API.Tests.Controllers.CdbController
{
    [TestClass]
    public class SimulacaoResgateAplicacaoTest
    {
        private Mock<ICdbService> _mockCdbService;
        private API.Controllers.CdbController _controller;

        public void Setup()
        {
            _mockCdbService = new Mock<ICdbService>();
            _controller = new API.Controllers.CdbController(_mockCdbService.Object);
        }

        [TestMethod]
        public void QuandoSucessoRetonaHttpStatusSuccess()
        {
            //Arrange
            Setup();
            var investimentoRequest = new InvestimentoRequest
            {
                PrazoEmMeses = 10,
                ValorMonetario = 1
            };
            var resultadoEsperado = HttpStatusCode.OK;

            //Act
            var resultado = _controller.SimulacaoResgateAplicacao(investimentoRequest);

            //Assert

            Assert.AreEqual(resultadoEsperado, resultado);
        }
        [TestMethod]
        public void QuandoRequestInvalidoRetonaHttpStatusBadRequest()
        {
            Setup();
            //Arrange
            var investimentoRequest = new InvestimentoRequest
            {
                PrazoEmMeses = -10,
                ValorMonetario = -1
            };
            var resultadoEsperado = HttpStatusCode.BadRequest;

            //Act
            var resultado = _controller.SimulacaoResgateAplicacao(investimentoRequest);
            //Assert

            Assert.AreEqual(resultadoEsperado, resultado);
        }
    }
}
