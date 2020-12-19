using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroPaises.Models;

namespace RegistroPaises.DomainService
{
    public class PaisDomainService
    {
        public string ObtenerPais(int id, Pais pais)
        {
            if (pais == null)
            {
                return "El pais no existe.";
            }
            return null;
        }
        public string RegistrarPais(Pais pais)
        {
            if (pais.nombre == "")
            {
                return "Se necesita el nombre de pais";
            }

            if (pais.codigo == "")
            {
                return "Se necesita el codigo del pais";
            }

            return "Success";
        }
        public string ActualizarPais(int id, Pais pais, Departamento departamento)
        {
            if (departamento == null)
            {
                return "El departamento no existe.";
            }

            if (pais.nombre == "")
            {
                return "Se necesita el nombre de pais";
            }

            if (pais.codigo == "")
            {
                return "Se necesita el codigo del pais";
            }
            
            return null;
        }
        public string EliminarPais(int id, Pais pais)
        {
            if (pais == null)
            {
                return "El pais no existe.";
            }
            return null;
        }
    }
}
