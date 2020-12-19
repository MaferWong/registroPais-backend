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
    public class DepartamentoApplicationService
    {
        private readonly RegistroPaisesDataContext _baseDatos;
        private readonly DepartamentoDomainService _departamentoDomainService;
        public DepartamentoApplicationService(RegistroPaisesDataContext _context, DepartamentoDomainService departamentoDomainService)
        {
            _baseDatos = _context;
            _departamentoDomainService = departamentoDomainService;
        }
        public async Task<string> GetDepartamentoApplicationService(int id)
        {
            var departamento = await _baseDatos.Departamentos.FirstOrDefaultAsync(q => q.id == id);

            var respuestaDomainService = _departamentoDomainService.ObtenerDepartamento(id, departamento);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            return null;
        }
        public async Task<string> PostDepartamentoApplicationService(Departamento departamento)
        {
            var respuestaDomainService = _departamentoDomainService.RegistrarDepartamento(departamento);

            bool hayErrorDomainService = respuestaDomainService != "Success";

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Departamentos.Add(departamento);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> PutDepartamentoApplicationService(int id, Departamento departamento)
        {
            var respuestaDomainService = _departamentoDomainService.ActualizarDepartamento(id, departamento);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Entry(departamento).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> DeleteDepartamentoApplicationService(int id)
        {
            var departamento = await _baseDatos.Departamentos.FindAsync(id);

            var respuestaDomainService = _departamentoDomainService.EliminarDepartamento(id, departamento);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Departamentos.Remove(departamento);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
    }
}
