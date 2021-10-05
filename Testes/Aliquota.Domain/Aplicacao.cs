using System;

namespace Aliquota.Domain
{
    public class Aplicacao
    {
        public const int UM_ANO = 365;
        public const decimal TAXA_MAXIMA = 0.225m;
        public const decimal TAXA_MEDIA = 0.185M;
        public const decimal TAXA_MINIMA = 0.15M;
        
        public decimal Id { get; set; }
        public decimal ValorInicial { get; private set; }
        public string Cliente { get; private set; }
        public DateTime DataDaAplicacao { get; private set; }
        public decimal ValorRetido { get; private set; }

        public Aplicacao(decimal valorInicial, string cliente, DateTime dataDaAplicacao)
        {
            if (valorInicial <= 0)
                throw new Exception("Valor Inicial não pode ser menor que zero");

            ValorInicial = valorInicial;
            Cliente = cliente;
            DataDaAplicacao = dataDaAplicacao;
        }

        public Aplicacao Resgatar(DateTime dataDoResgate)
        {
            if (dataDoResgate < DataDaAplicacao)
                throw new Exception("Data do resgate não pode ser menor que data da aplicação");

            ValorRetido = ObterValorRetido();

            return this;
        }

        private decimal ObterValorRetido()
        {
            var diasDeAplicacao = (DateTime.Now - DataDaAplicacao).Days;

            if (diasDeAplicacao < UM_ANO)
                return (1 - TAXA_MAXIMA) * ValorInicial;

            if (diasDeAplicacao >= UM_ANO && diasDeAplicacao <= 2 * UM_ANO)
                return (1 - TAXA_MEDIA) * ValorInicial;

            return (1 - TAXA_MINIMA) * ValorInicial;
        }
    }
}