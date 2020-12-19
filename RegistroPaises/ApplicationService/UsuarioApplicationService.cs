using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroPaises.DataContext;
using RegistroPaises.DomainService;
using RegistroPaises.Models;
using Microsoft.EntityFrameworkCore;

namespace RegistroPaises.ApplicationService
{
    public class UsuarioApplicationService
    {
        private readonly RegistroPaisesDataContext _baseDatos;
        private readonly UsuarioDomainService _usuarioDomainServices;
        public UsuarioApplicationService(RegistroPaisesDataContext baseDatos, UsuarioDomainService usuarioDomainServiceaseDatos)
        {
            _baseDatos = baseDatos;
            _usuarioDomainServices = usuarioDomainServiceaseDatos;
        }

        public async Task<string> TieneAccesoUsuario(string usuarioId, string contrasenia)
        {
            var usuario = await _baseDatos.Usuarios.FirstOrDefaultAsync(q => q.UsuarioId == usuarioId
            && q.Contrasena == contrasenia);


            var respuestaDomain = _usuarioDomainServices.TieneAcceso(usuario);
            bool vieneConErrorEnElDomain = respuestaDomain != null;
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }

            return "success";
        }
    }
}
