using System;

namespace Banco.Banco
{
    class Program
    {
        private static Banco banco = new Banco();
        static void Main(string[] args)
        {
            try
            {
                TestarConta(123456, 1234);

                TestarConta(654321, 4321);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO!!!");
                Console.WriteLine(ex.Message + "\n\n" + ex.StackTrace); ;
            }

        }

        private static void TestarConta(int numeroCartao, int senha)
        {
            Console.WriteLine("\nEntrando no banco com o número de cartão :");
            Console.WriteLine(numeroCartao);

            banco.InserirCartao(numeroCartao);

            Console.WriteLine("\nE com a senha :");
            Console.WriteLine(senha);

            banco.InserirSenha(senha);

            Console.WriteLine("\nPedindo extrato...");

            banco.ImprimeExtrato();

            Console.WriteLine("\nDepositando R$ 500,00...");

            banco.Depositar(500);

            Console.WriteLine("\nPedindo novamente o extrato...");

            banco.ImprimeExtrato();

            Console.WriteLine("\nSacando R$ 300,00...");

            double valor = 300.0;
            banco.Sacar(valor);

            Console.WriteLine("\nPedindo novamente o extrato...");

            banco.ImprimeExtrato();
        }
    }
}
