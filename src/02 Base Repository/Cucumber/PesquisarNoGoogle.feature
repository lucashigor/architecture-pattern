#language: pt-BR

Funcionalidade: PesquisarNoGoogle
	Fazer uma pesquisa no google

@mytag
Cenario: Pesquisa no google
	Dado que eu abri o google
	E digitei "calcanhar de aquiles"
	Quando eu precionar pesquisar
	Entao o sistema apresenta a pesquisa
