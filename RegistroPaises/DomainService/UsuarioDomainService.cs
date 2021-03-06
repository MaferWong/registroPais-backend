﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroPaises.Models;

namespace RegistroPaises.DomainService
{
    public class UsuarioDomainService
    {
        public string TieneAcceso(Usuario usuario)
        {
            var usuarioExiste = usuario == null;
            if (usuarioExiste)
            {
                return "El usuario o la contraseña no son válidos";
            }

            if (usuario.EstaActivo == false)
            {
                return "El usuario no está activo";
            }

            return "success";
        }
    }
}
