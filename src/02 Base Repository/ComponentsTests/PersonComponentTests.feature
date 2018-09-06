#language: pt-BR

Funcionalidade: PersonComponentTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Cenario: Inclusão de um participante
	Dado Eu tenha inserido um participante com mais de 50 anos:
			| Name  | BirthDay   | Cpf         |
			| Teste | 23/02/1993 | 42568042850 |
	Quando Eu envio ocorre um erro
	Entao eh isso ai