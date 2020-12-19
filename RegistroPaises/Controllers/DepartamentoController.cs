using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroPaises.ApplicationService;
using RegistroPaises.DataContext;
using RegistroPaises.Models;

namespace RegistroPaises.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : Controller
    {
        private readonly RegistroPaisesDataContext _baseDatos;
        private readonly DepartamentoApplicationService _departamentoApplicationService;
        public DepartamentoController(RegistroPaisesDataContext _context, DepartamentoApplicationService departamentoApplicationService)
        {
            _baseDatos = _context;
            _departamentoApplicationService = departamentoApplicationService;

            if (_baseDatos.Departamentos.Count() == 0)
            {
                _baseDatos.Departamentos.Add(new Departamento { nombre = "Departamento de Cortes.", codigoAdministrativo = "05" });
                _baseDatos.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
        {
            return await _baseDatos.Departamentos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            var respuestaDepartamentoApplicationService = await _departamentoApplicationService.GetDepartamentoApplicationService(id);
            bool noHayErroresEnValidaciones = respuestaDepartamentoApplicationService == null;

            if (noHayErroresEnValidaciones)
            {
                return await _baseDatos.Departamentos.FirstOrDefaultAsync(q => q.id == id); ;
            }
            return BadRequest(respuestaDepartamentoApplicationService);
        }

        [HttpPost]
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento departamento)
        {
            var respuestaDepartamentoApplicationService = await _departamentoApplicationService.PostDepartamentoApplicationService(departamento);

            bool noHayErroresEnValidaciones = respuestaDepartamentoApplicationService == null;

            if (noHayErroresEnValidaciones)
            {
                return CreatedAtAction(nameof(GetDepartamento), new { id = departamento.id }, departamento);
            }
            return BadRequest(respuestaDepartamentoApplicationService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamento(int id, Departamento departamento)
        {
            var respuestaDepartamentoApplicationService = await _departamentoApplicationService.PutDepartamentoApplicationService(id, departamento);

            bool noHayErroresEnValidaciones = respuestaDepartamentoApplicationService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaDepartamentoApplicationService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            var respuestaDepartamentoApplicationService = await _departamentoApplicationService.DeleteDepartamentoApplicationService(id);

            bool noHayErroresEnValidaciones = respuestaDepartamentoApplicationService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaDepartamentoApplicationService);
        }
    }
}
