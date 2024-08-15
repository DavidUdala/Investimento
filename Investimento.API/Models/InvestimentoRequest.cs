using System;

namespace Investimento.API.Models
{
    public class InvestimentoRequest
    {
        public double ValorMonetario { get; set; }
        public int PrazoEmMeses { get; set; }

        private bool ValidaValorMonetario ()
        {
            if (this.ValorMonetario < 0)
                return false;
            return true;
        }

        private bool ValidaPrazoEmMeses()
        {
            if(this.PrazoEmMeses < 1 || this.PrazoEmMeses > 12)
                return false ;
            return true;
        }

        public bool Validar()
        {
            return ValidaPrazoEmMeses() && ValidaValorMonetario();
        }
    }
}