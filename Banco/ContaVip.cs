using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Banco
{
    class ContaVip : ContaAbstract
    {
        private readonly double _limite = 1000.0;

        public ContaVip(string nome, int numeroDoCartao, int senha) : base(nome, numeroDoCartao, senha)
        {

        }
        public override double Saca(double valor)
        {
            if (valor > _limite + GetSaldo())
            {
                throw new Exception("Valor deve ser menor ou igual ao limite + saldo!");
            }

            return base.Saca(valor);
        }

        public double GetLimite()
        {
            return _limite;
        }
    }
}
