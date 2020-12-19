Feature: Registro Pais

@mytag
Scenario: Registro de Pais
	Given el nombre del pais es "Honduras"
	And el codigo del pais es "HND"
	And el departamentoId del pais es 1
	When registrando el pais
	Then el registro del pais es "Success"