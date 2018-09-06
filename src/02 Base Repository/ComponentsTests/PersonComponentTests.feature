#language: pt-BR

Funcionalidade: PersonComponentTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Participante
Cenário: Inclusão de um participante
	Dado Eu tenha inserido um participante com mais idade não permitida:
			| Name  | BirthDay   | Cpf         |
			| Teste | 23/02/1993 | 42568042850 |
	Quando Eu envio Post
	Entao Um erro deve ocorrer

@Participante
Cenário: Deleção de um Participante
	Dado Que tenha um participante na base com idade valida:
			| Name  | BirthDay   | Cpf         |
			| Teste | 23/02/1993 | 42568042850 |
	Quando Eu envio o Delete
	Então A base deve ficar vazia