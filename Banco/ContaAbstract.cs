using System;

namespace Banco.Banco
{
    abstract class ContaAbstract
    {
        private string _nome;
        private int _numeroDoCartao;
        private int _senha;
        private double _saldo = 0.0;

        public ContaAbstract(string nome, int numeroDoCartao, object senha) //boxing
        {
            _nome = nome;
            _numeroDoCartao = numeroDoCartao;

            if (senha is int)
            {
                _senha = (int)senha; //unboxing
            }
            else
            {
                throw new Exception("É necessário o parâmetro senha ter tipo inteiro.");
            }
        }

        public void Deposita(double valor)
        {
            _saldo += valor;
        }

        public virtual double Saca(double valor)
        {
            _saldo -= valor;

            return valor;
        }

        public double GetSaldo() => _saldo;

        public string GetNome() => _nome;
        public bool SenhaExiste(int senha)
        {
            if (senha != _senha)
            {
                return false;
            }
                
            return true;
        }

        public void TrocaSenha(int senha)
        {
            if (SenhaExiste(senha))
            {
                _senha = senha;
            }
            else
            {
                throw new Exception("Erro ao trocar senha, senha incorreta!");
            }
        }

        public bool NumeroDeCartaoExiste(int numCartao)
        {
            if (numCartao != _numeroDoCartao)
            {
                return false;
            }

            return true;
        }


    }
}
