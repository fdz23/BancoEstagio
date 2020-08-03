# language: pt-BR

Funcionalidade: Sacar dinheiro

Como cliente normal
sou capaz de sacar dinheiro
enquanto porto cartão e senha
e se não tiver dinheiro suficiente
não devo receber nada

mas como cliente vip
sou capaz de sacar dinheiro
mesmo que nao tenha dinheiro suficiente
mas não devo receber nada se for superior ao limite

Contexto: 
	Dado que tenho o cartão e a senha em mãos
	E estou no banco

Cenário: Saque com sucesso
	E entro em minha conta normal
	E tiver na conta pelo menos 500
	Quando eu tentar sacar 500
	Então eu devo receber o dinheiro 500

Cenário: Conta sem dinheiro
	E entro em minha conta normal
	E tiver menos de 1200 na conta
	Quando sacar 1200 devo receber um erro sobre o saque normal inválido

Cenário: Cartão incorreto
	E introduzo o cartão incorretamente
	Então devo receber um erro sobre o cartao estar errado

Cenário: Senha incorreta
	E introduzo o cartão corretamente
	E introduzo a senha incorretamente
	Então devo receber um erro sobre a senha estar errada
	
Cenário: Saque deixando o saldo negativo
	E entro em minha conta vip
	E tiver 500 na conta
	Quando eu sacar 1200
	Então eu devo receber 1200
	E ficar com saldo de -700

Cenário: Saque passando do saldo e do limite
	E entro em minha conta vip
	E tiver 500 na conta
	Quando eu fizer um saque de 1600 devo receber um erro sobre o saque vip inválido