using Investimento.API.Interfaces;
using Investimento.API.Models;
using Investimento.API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Investimento.API.Tests.Services
{
    [TestClass]
    public class CdbService_RetornaTaxaImposto
    {
        private readonly ICdbService _cdbService = new CdbService();

        [TestMethod]
        [DataRow(6, 0.225)]
        [DataRow(7, 0.20)]
        [DataRow(13, 0.175)]
        [DataRow(25, 0.15)]
        public void RetornaTaxaImpostoQuandoPrazoMesesInformado(int prazoEmMeses, double taxaImpostoEsperada)
        {
            //Arrange
            var MetodoCalcularImposto = typeof(CdbService).GetMethod("RetornaTaxaImposto", BindingFlags.NonPublic | BindingFlags.Instance);

            //Act
            double result = (double)MetodoCalcularImposto.Invoke(_cdbService, new object[] { prazoEmMeses });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(taxaImpostoEsperada, result);
        }
    }
}
