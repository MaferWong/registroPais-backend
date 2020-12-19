using TechTalk.SpecFlow;
using FluentAssertions;
using RegistroPaises.DomainService;
using RegistroPaises.Models;

namespace SpecFlowProject.Steps
{
    [Binding]
    public sealed class RegistroDepartamentoStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Departamento _departamento = new Departamento();
        private readonly DepartamentoDomainService _departamentoDomainService = new DepartamentoDomainService();
        private string _result;
        public RegistroDepartamentoStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"el nombre del departamento es ""(.*)""")]
        public void GivenElNombreDelDepartamentoEs(string nombre)
        {
            _departamento.nombre = nombre;
        }

        [Given(@"el codigo del departamento es ""(.*)""")]
        public void GivenElCodigoDelDepartamentoEs(string codigo)
        {
            _departamento.codigoAdministrativo = codigo;
        }

        [When(@"registrando el departamento")]
        public void WhenRegistrandoElDepartamento()
        {
            _result = _departamentoDomainService.RegistrarDepartamento(_departamento);
        }

        [Then(@"el registro del departamento es ""(.*)""")]
        public void ThenElRegistroDelDepartamentoEs(string result)
        {
            _result.Should().Be(result);
        }
    }
}
