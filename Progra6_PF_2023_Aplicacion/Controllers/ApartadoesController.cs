using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Progra6_PF_2023_Aplicacion.Attributes;
using Progra6_PF_2023_Aplicacion.Models;

namespace Progra6_PF_2023_Aplicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Apikey]
    public class ApartadoesController : ControllerBase
    {
        private readonly Progra6_PF_2023Context _context;

        public ApartadoesController(Progra6_PF_2023Context context)
        {
            _context = context;
        }

        // GET: api/Apartadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apartado>>> GetApartados()
        {
          if (_context.Apartados == null)
          {
              return NotFound();
          }
            return await _context.Apartados.ToListAsync();
        }

        // GET: api/Apartadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Apartado>> GetApartado(int id)
        {
          if (_context.Apartados == null)
          {
              return NotFound();
          }
            var apartado = await _context.Apartados.FindAsync(id);

            if (apartado == null)
            {
                return NotFound();
            }

            return apartado;
        }

        // PUT: api/Apartadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApartado(int id, Apartado apartado)
        {
            if (id != apartado.ApartadosId)
            {
                return BadRequest();
            }

            _context.Entry(apartado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Apartadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Apartado>> PostApartado(Apartado apartado)
        {
          if (_context.Apartados == null)
          {
              return Problem("Entity set 'Progra6_PF_2023Context.Apartados'  is null.");
          }
            _context.Apartados.Add(apartado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApartado", new { id = apartado.ApartadosId }, apartado);
        }

        // DELETE: api/Apartadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartado(int id)
        {
            if (_context.Apartados == null)
            {
                return NotFound();
            }
            var apartado = await _context.Apartados.FindAsync(id);
            if (apartado == null)
            {
                return NotFound();
            }

            _context.Apartados.Remove(apartado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApartadoExists(int id)
        {
            return (_context.Apartados?.Any(e => e.ApartadosId == id)).GetValueOrDefault();
        }
    }
}
