using System;

namespace Investimento.API.Models
{
    public class InvestimentoRequest
    {

        public InvestimentoRequest(double valorMonetario, int prazoEmMeses)
        {
            ValorMonetario = valorMonetario;
            PrazoEmMeses = prazoEmMeses;
        }

        public double ValorMonetario { get; private set; }
        public int PrazoEmMeses { get; private set; }

        private bool ValidaValorMonetario ()
        {
            if (this.ValorMonetario < 0)
                return false;
            return true;
        }

        private bool ValidaPrazoEmMeses()
        {
            if(this.PrazoEmMeses < 1)
                return false ;
            return true;
        }

        public bool Validar()
        {
            return ValidaPrazoEmMeses() && ValidaValorMonetario();
        }
    }
}