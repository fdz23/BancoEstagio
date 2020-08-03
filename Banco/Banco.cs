using Banco.Vetor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Banco.Banco
{
    class Banco
    {
        private ListaGenerica<ContaAbstract> _contas = new ListaGenerica<ContaAbstract>(); //Generics
        private ContaAbstract _contaAtual = null;
        public string NomeBanco { get; } = "Banco Paçoca";
        public Banco()
        {
            var contaNormal = new ContaNormal("ContaNormal", 123456, 1234); //Upcast

            contaNormal.Deposita(500);
            _contas.Adicione(contaNormal);

            var contaVip = new ContaVip("ContaVip", 654321, 4321); //Upcast

            contaVip.Deposita(500);
            _contas.Adicione(contaVip);
        }

        public void InserirCartao(int numCartao)
        {
            _contaAtual = _contas
                .Where(x => x.NumeroDeCartaoExiste(numCartao))
                .SingleOrDefault();  //LINQ

            if (_contaAtual == null)
            {
                throw new Exception("Número do cartão incorreto!");
            }
        }

        public void InserirSenha(int senha)
        {
            if (!_contaAtual.SenhaExiste(senha))
            {
                throw new Exception("Senha incorreta!");
            }
        }

        public double Sacar(double valor)
        {
            return _contaAtual.Saca(valor);
        }

        public void Depositar(double valor)
        {
            _contaAtual.Deposita(valor);
        }

        public double RetirarExtrato()
        {
            return _contaAtual.GetSaldo();
        }

        public void ImprimeExtrato()
        {
            string saldoEmReais = DoubleEmReais(_contaAtual.GetSaldo());

            Console.WriteLine($"A seguir as informações do(a) senhor(a) {_contaAtual.GetNome()} em sua conta do {NomeBanco} :\n");
            Console.WriteLine($"Atual saldo: {saldoEmReais}.");
            
            if (_contaAtual is ContaVip)
            {
                ContaVip contaVip = _contaAtual as ContaVip; //Downcast
                string limiteEmReais = DoubleEmReais(contaVip.GetLimite());

                Console.WriteLine($"Atual limite: {limiteEmReais}.");
            }
        }

        private string DoubleEmReais(double numero)
        {
            return numero.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR")); //Type conversion
        }
    }
}
