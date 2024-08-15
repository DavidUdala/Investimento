using Investimento.API.Interfaces;
using Investimento.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Investimento.API.Services
{
    public class CdbService : ICdbService
    {

        private readonly double tb = 1.08; //Quanto o banco paga sobre o CDI
        private readonly double cdi = 0.009; //Valor dessa taxa no último mês

        readonly Dictionary<int, double> taxasImposto = new Dictionary<int, double>()
        {
            {6, 22.5 },
            {12, 20 },
            {24, 17.5 },
            {int.MaxValue, 15 }
        };

        public InvestimentoResponse Calcular(InvestimentoRequest investimentoRequest)
        {
            double valorBruto = CalcularValorTotalBruto(investimentoRequest);
            double valorLiquido = CalcularValorTotalLiquido(investimentoRequest, valorBruto);

            InvestimentoResponse resultado = new InvestimentoResponse(Math.Round(valorBruto,2), Math.Round(valorLiquido,2));

            return resultado;
        }

        private double CalcularValorTotalBruto(InvestimentoRequest investimentoRequest)
        {
            double valor = investimentoRequest.ValorMonetario;

            for (int i = 0; i < investimentoRequest.PrazoEmMeses; i++)
            {
                valor *= (1 + (cdi * tb));
            }

            return valor;
        }

        private double CalcularValorTotalLiquido(InvestimentoRequest investimentoRequest, double valorBruto)
        {
            double imposto = CalcularImposto(investimentoRequest, valorBruto);

            return valorBruto - imposto;
        }

        private double RetornaTaxaImposto(int prazoEmMeses)
        {
            foreach (var taxa in taxasImposto)
            {
                if (prazoEmMeses <= taxa.Key)
                {
                    return taxa.Value / 100;
                }
            }

            return taxasImposto.LastOrDefault().Value;
        }

        private double CalcularImposto(InvestimentoRequest investimentoRequest, double valorBruto)
        {
            double taxa = RetornaTaxaImposto(investimentoRequest.PrazoEmMeses);

            return taxa * (valorBruto - investimentoRequest.ValorMonetario); 
        }
    }
}