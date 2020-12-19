using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroPaises.Models;

namespace RegistroPaises.DomainService
{
    public class DepartamentoDomainService
    {
        public string ObtenerDepartamento(int id, Departamento departamento)
        {
            if (departamento == null)
            {
                return "El departamento no existe.";
            }
            return null;
        }
        public string RegistrarDepartamento(Departamento departamento)
        {
            if (departamento.nombre == "")
            {
                return "Se necesita el nombre del Departamento";
            }

            if (departamento.codigoAdministrativo == "")
            {
                return "Se necesita el codigo del Departamento";
            }

            return "Success";
        }
        public string ActualizarDepartamento(int id, Departamento departamento)
        {
            if (departamento.nombre == "")
            {
                return "Se necesita el nombre del Departamento";
            }

            if (departamento.codigoAdministrativo == "")
            {
                return "Se necesita el codigo del Departamento";
            }
            return null;
        }
        public string EliminarDepartamento(int id, Departamento departamento)
        {
            if (departamento == null)
            {
                return "El departamento no existe.";
            }
            return null;
        }
    }
}
