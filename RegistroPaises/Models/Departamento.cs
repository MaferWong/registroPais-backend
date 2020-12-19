using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPaises.Models
{
    public class Departamento
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string codigoAdministrativo { get; set; }
        public List<Pais> Paises { get; set; }
    }
}
