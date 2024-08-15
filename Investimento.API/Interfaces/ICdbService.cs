using Investimento.API.Models;

namespace Investimento.API.Interfaces
{
    public interface ICdbService : IInvestimentoService
    {
        double CalcularValorTotalBruto(InvestimentoRequest investimentoRequest);
        double CalcularValorTotalLiquido(InvestimentoRequest investimentoRequest, double valorBruto);
        double RetornaTaxaImposto(int prazoEmMeses);
        double CalcularImposto(InvestimentoRequest investimentoRequest, double valorBruto);
    }
}
