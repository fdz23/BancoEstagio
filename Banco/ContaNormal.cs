using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Banco
{
    class ContaNormal : ContaAbstract
    {
        public ContaNormal(string nome, int numeroDoCartao, int senha) : base(nome, numeroDoCartao, senha)
        {

        }
        public override double Saca(double valor)
        {
            if (valor > GetSaldo())
            {
                throw new Exception("Valor deve ser menor que saldo!");
            }

            return base.Saca(valor);
        }
    }
}
