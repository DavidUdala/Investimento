using Investimento.API.Models;
using System.Threading.Tasks;

namespace Investimento.API.Interfaces
{
    public interface IInvestimentoService
    {
        Task<double> CalcularAsync(InvestimentoRequest investimentoRequest);
    }
}
