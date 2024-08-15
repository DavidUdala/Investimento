using Investimento.API.Interfaces;
using Investimento.API.Models;
using System.Threading.Tasks;
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
        public async Task<IHttpActionResult> SimulacaoResgateAplicacao(InvestimentoRequest requestCalculoCdb)
        {
            if (!requestCalculoCdb.Validar())
                return BadRequest("Informe um valor monetário e um mes que seja valido.");

            var result = await _cdbService.CalcularAsync(requestCalculoCdb);

            return Ok(result);
        }
    }
}