using RegistroPaises.DomainService;
using RegistroPaises.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    class UnitTestDepartamento
    {
        [TestMethod]
        public void ValidarNombreDepartamentoAlRegistrar()
        {
            DepartamentoDomainService departamentoDomainService = new DepartamentoDomainService();
            Departamento departamento = new Departamento();
            departamento.nombre = "";

            var respuesta = departamentoDomainService.RegistrarDepartamento(departamento);

            Assert.AreEqual("Se necesita el nombre de Departamento", respuesta);
        }

        [TestMethod]
        public void ValidarCodigoDepartamentoAlRegistrar()
        {
            DepartamentoDomainService departamentoDomainService = new DepartamentoDomainService();
            Departamento departamento = new Departamento();
            departamento.codigoAdministrativo = "";

            var respuesta = departamentoDomainService.RegistrarDepartamento(departamento);

            Assert.AreEqual("Se necesita el codigo del Departamento", respuesta);
        }

        [TestMethod]
        public void ValidarNombreDepartamentoAlActualizar()
        {
            DepartamentoDomainService departamentoDomainService = new DepartamentoDomainService();
            Departamento departamento = new Departamento();
            departamento.nombre = "";
            int id = 1;

            var respuesta = departamentoDomainService.ActualizarDepartamento(id, departamento);

            Assert.AreEqual("Se necesita el nombre de Departamento", respuesta);
        }

        [TestMethod]
        public void ValidarCodigoDepartamentoAlActualizar()
        {
            DepartamentoDomainService departamentoDomainService = new DepartamentoDomainService();
            Departamento departamento = new Departamento();
            departamento.codigoAdministrativo = "";
            int id = 1;

            var respuesta = departamentoDomainService.ActualizarDepartamento(id, departamento);

            Assert.AreEqual("Se necesita el codigo del Departamento", respuesta);
        }
    }
}
