using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistroPaises.DataContext;
using RegistroPaises.DomainService;
using RegistroPaises.Models;

namespace RegistroPaises.ApplicationService
{
    public class PaisApplicationService
    {
        private readonly RegistroPaisesDataContext _baseDatos;
        private readonly PaisDomainService _paisDomainService;
        public PaisApplicationService(RegistroPaisesDataContext _context, PaisDomainService paisDomainService)
        {
            _baseDatos = _context;
            _paisDomainService = paisDomainService;
        }
        public async Task<string> GetPaisApplicationService(int id)
        {
            var pais = await _baseDatos.Paises.Include(q => q.Departamento).FirstOrDefaultAsync(q => q.id == id);

            var respuestaDomainService = _paisDomainService.ObtenerPais(id, pais);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            return null;
        }
        public async Task<string> PostPaisApplicationService(Pais pais)
        {
            var respuestaDomainService = _paisDomainService.RegistrarPais(pais);

            bool hayErrorDomainService = respuestaDomainService != "Success";

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Paises.Add(pais);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> PutPaisApplicationService(int id, Pais pais)
        {
            Departamento departamento = await _baseDatos.Departamentos.FirstOrDefaultAsync(q => q.id == pais.departamentoId);

            var respuestaDomainService = _paisDomainService.ActualizarPais(id, pais, departamento);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Entry(pais).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> DeletePaisApplicationService(int id)
        {
            var pais = await _baseDatos.Paises.FindAsync(id);

            var respuestaDomainService = _paisDomainService.EliminarPais(id, pais);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Paises.Remove(pais);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
    }
}
