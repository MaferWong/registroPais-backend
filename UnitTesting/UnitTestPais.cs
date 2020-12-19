using RegistroPaises.DomainService;
using RegistroPaises.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    public class UnitTestPais
    {
        [TestMethod]
        public void ValidarNombrePaisAlRegistrar()
        {
            PaisDomainService paisDomainService = new PaisDomainService();
            Pais pais = new Pais();
            pais.nombre = "";

            var respuesta = paisDomainService.RegistrarPais(pais);

            Assert.AreEqual("Se necesita el nombre de pais", respuesta);
        }

        [TestMethod]
        public void ValidarCodigoPaisAlRegistrar()
        {
            PaisDomainService paisDomainService = new PaisDomainService();
            Pais pais = new Pais();
            pais.codigo = "";

            var respuesta = paisDomainService.RegistrarPais(pais);

            Assert.AreEqual("Se necesita el codigo del pais", respuesta);
        }

        [TestMethod]
        public void ValidarNombrePaisAlActualizar()
        {
            PaisDomainService paisDomainService = new PaisDomainService();
            Pais pais = new Pais();
            Departamento departamento = new Departamento();
            pais.nombre = "";
            int id = 1;

            var respuesta = paisDomainService.ActualizarPais(id, pais, departamento);

            Assert.AreEqual("Se necesita el nombre de pais", respuesta);
        }

        [TestMethod]
        public void ValidarCodigoPaisAlActualizar()
        {
            PaisDomainService paisDomainService = new PaisDomainService();
            Pais pais = new Pais();
            Departamento departamento = new Departamento();
            pais.codigo = "";
            int id = 1;

            var respuesta = paisDomainService.ActualizarPais(id, pais, departamento);

            Assert.AreEqual("Se necesita el codigo del pais", respuesta);
        }
    }
}
