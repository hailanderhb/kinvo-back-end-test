using System;
using Aliquota.Domain;
using Aliquota.Repository;

namespace Aliquota.Front
{
    class Program
    {
        private static AliquotaRepository Repository { get; set; }
        static void Main(string[] args)
        {
            Repository = new AliquotaRepository();
            Menu1();
        }

        static void Menu1()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Inserir novo cliente");
            Console.WriteLine("2 - Resgatar aplicação");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());
            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: MenuCliente(); break;
                case 2: MenuResgate(); break;
                default: MenuErro(); break;
            }
        }

        static void MenuCliente()
        {
            Console.Clear();
            Console.WriteLine("Qual o nome do cliente? ");
            var nome = Console.ReadLine();
            Console.WriteLine("Qual o valor da aplicação? ");
            var valor = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Qual a data de Aplicação (dd/mm/yyyy) ? ");
            var dataNaoFormatada = DateTime.Parse(Console.ReadLine());

            var dataFormatada = String.Format("{0:dd/mm/yyyy}", DateTime.Now);

            try
            {
                var aplicacao = new Aplicacao(valor, nome, dataNaoFormatada);
                Repository.Criar(aplicacao);

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            Console.WriteLine("Exibir valor salvo");

            var aplicacaoObtida = Repository.ObterPeloNome(nome);

            Console.WriteLine("Nome: " + aplicacaoObtida.Cliente);
            Console.WriteLine("ValorInicial: " + aplicacaoObtida.ValorInicial);
            Console.WriteLine("ValorRetido: " + aplicacaoObtida.ValorRetido);
            Console.WriteLine("DataDaAplicacao: " + aplicacaoObtida.DataDaAplicacao);

            Console.WriteLine("");
            Console.WriteLine("Deseja adicionar mais clientes ?");
            Console.WriteLine("1 - Inserir novo cliente");
            Console.WriteLine("2 - Menu Inicial");
            Console.WriteLine("0 - Sair");

            short option = short.Parse(Console.ReadLine());
            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: MenuCliente(); break;
                default: Menu1(); break;
            }


        }

        static void MenuResgate()
        {
            Console.Clear();
            Console.WriteLine("Qual o nome do cliente? ");
            var nome = Console.ReadLine(); //************************************

        }

        static void MenuErro()
        {
            Console.Clear();
            Console.WriteLine("Por favor digite a opção correta");
            Menu1();
        }
    }
}

