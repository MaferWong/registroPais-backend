using TechTalk.SpecFlow;
using FluentAssertions;
using RegistroPaises.DomainService;
using RegistroPaises.Models;

namespace SpecFlowProject.Steps
{
    [Binding]
    public sealed class RegistroPaisStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Pais _pais = new Pais();
        private readonly PaisDomainService _paisDomainService = new PaisDomainService();
        private string _result;
        public RegistroPaisStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"el nombre del pais es ""(.*)""")]
        public void GivenElNombreDelPaisEs(string nombre)
        {
            _pais.nombre = nombre;
        }

        [Given(@"el codigo del pais es ""(.*)""")]
        public void GivenElCodigoDelPaisEs(string codigo)
        {
            _pais.codigo = codigo;
        }

        [Given(@"el departamentoId del pais es (.*)")]
        public void GivenElDepartamentoIdDelPaisEs(int departamentoId)
        {
            _pais.departamentoId = departamentoId;
        }

        [When(@"registrando el pais")]
        public void WhenRegistrandoElPais()
        {
            _result = _paisDomainService.RegistrarPais(_pais);
        }

        [Then(@"el registro del pais es ""(.*)""")]
        public void ThenElRegistroDelPaisEs(string result)
        {
            _result.Should().Be(result);
        }
    }
}
