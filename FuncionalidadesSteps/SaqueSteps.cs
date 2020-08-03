using Banco.Banco;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Banco.FuncionalidadesSteps
{
    [Binding]
    class SaqueSteps
    {
        private Banco.Banco _banco;
        private int _numeroCartaoNormal;
        private int _senhaNormal;
        private int _numeroCartaoVip;
        private int _senhaVip;
        private double saque;

        [Given(@"que tenho o cartão e a senha em mãos")]
        public void DadoQueTenhoOCartaoEASenhaEmMaos()
        {
            _numeroCartaoNormal = 123456;
            _senhaNormal = 1234;
            _numeroCartaoVip = 654321;
            _senhaVip = 4321;
        }

        [Given(@"estou no banco")]
        public void DadoEstouNoBanco()
        {
            _banco = new Banco.Banco();
        }

        [Given(@"entro em minha conta normal")]
        public void DadoIntroduzoOCartaoESenhaCorretamente()
        {
            _banco.InserirCartao(_numeroCartaoNormal);
            _banco.InserirSenha(_senhaNormal); //Se algum dos passos falhar, será jogada uma Exception
        }

        [Given(@"tiver na conta pelo menos (.*)")]
        public void DadoTiverNaContaPeloMenos(double p0)
        {
            Assert.AreEqual(p0, _banco.RetirarExtrato());
        }

        [When(@"eu tentar sacar (.*)")]
        public void TentarSacar(double p0)
        {
            saque = _banco.Sacar(p0);
        }

        [Then(@"eu devo receber o dinheiro (.*)")]
        public void EntaoEuDevoReceberODinheiro(double p0)
        {
            Assert.AreEqual(p0, saque);
        }

        [Given(@"tiver menos de (.*) na conta")]
        public void TiverMenosDe_NaConta(double p0)
        {
            Assert.IsTrue(p0 > _banco.RetirarExtrato());
        }

        [When(@"sacar (.*) devo receber um erro sobre o saque normal inválido")]
        public void QuandoSacar_(double p0)
        {
            var ex = Assert.Throws<Exception>(() => _banco.Sacar(p0));
            Assert.That(ex.Message, Is.EqualTo("Valor deve ser menor que saldo!"));
        }

        [Given(@"introduzo o cartão incorretamente")]
        public void DadoIntroduzoOCartaoIncorretamente()
        {
            _numeroCartaoNormal = 0;
        }

        [Then(@"devo receber um erro sobre o cartao estar errado")]
        public void EntaoDevoReceberUmErroSobreOCartaoEstarErrado()
        {
            var ex = Assert.Throws<Exception>(() => _banco.InserirCartao(_numeroCartaoNormal));
            Assert.That(ex.Message, Is.EqualTo("Número do cartão incorreto!"));
        }

        [Given(@"introduzo o cartão corretamente")]
        public void DadoIntroduzoOCartaoCorretamente()
        {
            _banco.InserirCartao(_numeroCartaoNormal);
        }

        [Given(@"introduzo a senha incorretamente")]
        public void DadoIntroduzoASenhaIncorretamente()
        {
            _senhaNormal = 0; //senha errada
        }

        [Then(@"devo receber um erro sobre a senha estar errada")]
        public void EntaoDevoReceberUmErroSobreASenhaEstarErrada()
        {
            var ex = Assert.Throws<Exception>(() => _banco.InserirSenha(_senhaNormal));
            Assert.That(ex.Message, Is.EqualTo("Senha incorreta!"));
        }

        [Given(@"entro em minha conta vip")]
        public void DadoEntroEmMinhaContaVip()
        {
            _banco.InserirCartao(_numeroCartaoVip);
            _banco.InserirSenha(_senhaVip);
        }

        [Given(@"tiver (.*) na conta")]
        public void DadoTiverNaConta(double p0)
        {

            Assert.AreEqual(p0, _banco.RetirarExtrato());
        }

        [When(@"eu sacar (.*)")]
        public void QuandoEuSacar(double p0)
        {
            saque = _banco.Sacar(p0);

        }

        [Then(@"eu devo receber (.*)")]
        public void EntaoEuDevoReceber(double p0)
        {
            Assert.AreEqual(p0, saque);
        }

        [Then(@"ficar com saldo de (.*)")]
        public void EntaoFicarComSaldoDe(double p0)
        {
            Assert.AreEqual(p0, _banco.RetirarExtrato());
        }

        [When(@"eu fizer um saque de (.*) devo receber um erro sobre o saque vip inválido")]
        public void QuandoEuFizerUmSaqueDe(double p0)
        {
            var ex = Assert.Throws<Exception>(() => _banco.Sacar(p0));
            Assert.That(ex.Message, Is.EqualTo("Valor deve ser menor ou igual ao limite + saldo!"));
        }

    }
}
