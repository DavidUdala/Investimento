using Investimento.API.Interfaces;
using Investimento.API.Models;
using System.Web.Http;

namespace Investimento.API.Controllers
{
    public class CdbController : ApiController
    {
        private readonly ICdbService _cdbService;

        public CdbController(ICdbService cdbService)
        {
            _cdbService = cdbService;
        }

        [HttpPost]
        public IHttpActionResult SimulacaoResgateAplicacao(InvestimentoRequest requestCalculoCdb)
        {
            if (!requestCalculoCdb.Validar())
                return BadRequest("Informe um valor monetário e um mês que seja válido.");

            var result = _cdbService.Calcular(requestCalculoCdb);

            return Ok(result);
        }
    }
}