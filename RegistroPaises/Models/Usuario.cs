using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPaises.Models
{
    public class Usuario
    {
        public string UsuarioId { get; set; }
        public string Contrasena { get; set; }
        public bool EstaActivo { get; set; }
    }
}
