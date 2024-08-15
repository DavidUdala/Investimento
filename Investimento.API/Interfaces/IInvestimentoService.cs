using Investimento.API.Models;

namespace Investimento.API.Interfaces
{
    public interface IInvestimentoService
    {
        InvestimentoResponse Calcular(InvestimentoRequest investimentoRequest);
    }
}
