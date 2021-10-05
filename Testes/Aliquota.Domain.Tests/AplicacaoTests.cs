using System;
using Xunit;

namespace Aliquota.Domain.Tests
{
    public class AplicacaoTests
    {
        [Fact]
        public void Aplicacao_Nao_Deve_Ser_Menor_Que__Zero()
        {
            var nomeCliente = "Joao";
            var dataDeposito = DateTime.Now;
            var valorInicial = -1;

            var exception = Assert.Throws<Exception>(() => new Aplicacao(valorInicial, nomeCliente, dataDeposito));

            Assert.Equal("Valor Inicial não pode ser menor que zero", exception.Message);
        }

        [Fact]
        public void Aplicacao_Nao_Deve_Ser_Igual_A_Zero()
        {
            var nomeCliente = "Joao";
            var dataDeposito = DateTime.Now;
            var valorInicial = 0;

            var exception = Assert.Throws<Exception>(() => new Aplicacao(valorInicial, nomeCliente, dataDeposito));

            Assert.Equal("Valor Inicial não pode ser menor que zero", exception.Message);
        }


        [Fact]
        public void Data_Resgate_Nao_Pode_Ser_Menor_Que_Data_Aplicacao()
        {
            var hoje = DateTime.Today;
            var aplicacao = new Aplicacao(10, "Joao", hoje);

            var exception = Assert.Throws<Exception>(() => aplicacao.Resgatar(hoje.AddDays(-1)));
            Assert.Equal("Data do resgate não pode ser menor que data da aplicação", exception.Message);
        }
    }
}
