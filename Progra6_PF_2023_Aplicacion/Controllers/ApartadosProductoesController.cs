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
    public class ApartadosProductoesController : ControllerBase
    {
        private readonly Progra6_PF_2023Context _context;

        public ApartadosProductoesController(Progra6_PF_2023Context context)
        {
            _context = context;
        }

        // GET: api/ApartadosProductoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApartadosProducto>>> GetApartadosProductos()
        {
          if (_context.ApartadosProductos == null)
          {
              return NotFound();
          }
            return await _context.ApartadosProductos.ToListAsync();
        }

        // GET: api/ApartadosProductoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApartadosProducto>> GetApartadosProducto(int id)
        {
          if (_context.ApartadosProductos == null)
          {
              return NotFound();
          }
            var apartadosProducto = await _context.ApartadosProductos.FindAsync(id);

            if (apartadosProducto == null)
            {
                return NotFound();
            }

            return apartadosProducto;
        }

        // PUT: api/ApartadosProductoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApartadosProducto(int id, ApartadosProducto apartadosProducto)
        {
            if (id != apartadosProducto.ApartadosApartadosId)
            {
                return BadRequest();
            }

            _context.Entry(apartadosProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartadosProductoExists(id))
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

        // POST: api/ApartadosProductoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApartadosProducto>> PostApartadosProducto(ApartadosProducto apartadosProducto)
        {
          if (_context.ApartadosProductos == null)
          {
              return Problem("Entity set 'Progra6_PF_2023Context.ApartadosProductos'  is null.");
          }
            _context.ApartadosProductos.Add(apartadosProducto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApartadosProductoExists(apartadosProducto.ApartadosApartadosId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetApartadosProducto", new { id = apartadosProducto.ApartadosApartadosId }, apartadosProducto);
        }

        // DELETE: api/ApartadosProductoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartadosProducto(int id)
        {
            if (_context.ApartadosProductos == null)
            {
                return NotFound();
            }
            var apartadosProducto = await _context.ApartadosProductos.FindAsync(id);
            if (apartadosProducto == null)
            {
                return NotFound();
            }

            _context.ApartadosProductos.Remove(apartadosProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApartadosProductoExists(int id)
        {
            return (_context.ApartadosProductos?.Any(e => e.ApartadosApartadosId == id)).GetValueOrDefault();
        }
    }
}
