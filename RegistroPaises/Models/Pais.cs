using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPaises.Models
{
    public class Pais
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public int departamentoId { get; set; }
        public Departamento Departamento { get; set; }
    }
}
