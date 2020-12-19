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
    public class PaisController : ControllerBase
    {
        private readonly RegistroPaisesDataContext _baseDatos;
        private readonly PaisApplicationService _paisApplicationService;
        public PaisController(RegistroPaisesDataContext _context, PaisApplicationService paisApplicationService)
        {
            _baseDatos = _context;
            _paisApplicationService = paisApplicationService;

            if (_baseDatos.Paises.Count() == 0)
            {
                _baseDatos.Paises.Add(new Pais { nombre = "Honduras", codigo = "HND", departamentoId = 1 });
                _baseDatos.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPaises()
        {
            return await _baseDatos.Paises.Include(q => q.Departamento).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetPais(int id)
        {
            var respuestaPaisApplicationService = await _paisApplicationService.GetPaisApplicationService(id);
            bool noHayErroresEnValidaciones = respuestaPaisApplicationService == null;

            if (noHayErroresEnValidaciones)
            {
                return await _baseDatos.Paises.Include(q => q.Departamento).FirstOrDefaultAsync(q => q.id == id); ;
            }
            return BadRequest(respuestaPaisApplicationService);
        }

        [HttpPost]
        public async Task<ActionResult<Pais>> PostPais(Pais pais)
        {
            var respuestaPaisApplicationService = await _paisApplicationService.PostPaisApplicationService(pais);

            bool noHayErroresEnValidaciones = respuestaPaisApplicationService == null;

            if (noHayErroresEnValidaciones)
            {
                return CreatedAtAction(nameof(GetPais), new { id = pais.id }, pais);
            }
            return BadRequest(respuestaPaisApplicationService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPais(int id, Pais pais)
        {
            var respuestaPaisApplicationService = await _paisApplicationService.PutPaisApplicationService(id, pais);

            bool noHayErroresEnValidaciones = respuestaPaisApplicationService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaPaisApplicationService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePais(int id)
        {
            var respuestaPaisApplicationService = await _paisApplicationService.DeletePaisApplicationService(id);

            bool noHayErroresEnValidaciones = respuestaPaisApplicationService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaPaisApplicationService);
        }
    }
}
