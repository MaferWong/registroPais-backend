Feature: RegistroDepartamento

@mytag
Scenario: Registro de Departamento
	Given el nombre del departamento es "Departamento de Cortes"
	And el codigo del departamento es "05"
	When registrando el departamento
	Then el registro del departamento es "Success"