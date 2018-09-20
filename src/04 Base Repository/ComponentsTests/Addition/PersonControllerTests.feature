Feature: PersonControllerTests
	In order to learn Math
	As a regular human
	I want to add two numbers using Calculator

@addition
Scenario: Adicionar um novo Participante
	Given Que eu possua um participante com os seguintes dados:
		| Name			|	Cpf			| BirthDate		|
		| Lucas Higor	|	42568042850	| 23/02/1993	|
	When Eu envio uma requisicao post para a PersonControler
	Then O participante deve possuir um Id

@addition
Scenario: Atualizar um Participante
	Given Que eu possua um participante com os seguintes dados:
		| Name			|	Cpf			| BirthDate		|
		| Lucas Higor	|	42568042850	| 23/02/1993	|
	And Eu envio uma requisicao post para a PersonControler
	And O participante deve possuir um Id
	And Eu altero Cpf do Participante para: teste
	When Eu Envio uma requisicao Put para a PersonControler
