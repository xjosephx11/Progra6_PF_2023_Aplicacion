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
    public class CategoriaProductoesController : ControllerBase
    {
        private readonly Progra6_PF_2023Context _context;

        public CategoriaProductoesController(Progra6_PF_2023Context context)
        {
            _context = context;
        }

        // GET: api/CategoriaProductoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaProducto>>> GetCategoriaProductos()
        {
          if (_context.CategoriaProductos == null)
          {
              return NotFound();
          }
            return await _context.CategoriaProductos.ToListAsync();
        }

        // GET: api/CategoriaProductoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaProducto>> GetCategoriaProducto(int id)
        {
          if (_context.CategoriaProductos == null)
          {
              return NotFound();
          }
            var categoriaProducto = await _context.CategoriaProductos.FindAsync(id);

            if (categoriaProducto == null)
            {
                return NotFound();
            }

            return categoriaProducto;
        }

        // PUT: api/CategoriaProductoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaProducto(int id, CategoriaProducto categoriaProducto)
        {
            if (id != categoriaProducto.CategoriaProductoId)
            {
                return BadRequest();
            }

            _context.Entry(categoriaProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaProductoExists(id))
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

        // POST: api/CategoriaProductoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriaProducto>> PostCategoriaProducto(CategoriaProducto categoriaProducto)
        {
          if (_context.CategoriaProductos == null)
          {
              return Problem("Entity set 'Progra6_PF_2023Context.CategoriaProductos'  is null.");
          }
            _context.CategoriaProductos.Add(categoriaProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoriaProducto", new { id = categoriaProducto.CategoriaProductoId }, categoriaProducto);
        }

        // DELETE: api/CategoriaProductoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaProducto(int id)
        {
            if (_context.CategoriaProductos == null)
            {
                return NotFound();
            }
            var categoriaProducto = await _context.CategoriaProductos.FindAsync(id);
            if (categoriaProducto == null)
            {
                return NotFound();
            }

            _context.CategoriaProductos.Remove(categoriaProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaProductoExists(int id)
        {
            return (_context.CategoriaProductos?.Any(e => e.CategoriaProductoId == id)).GetValueOrDefault();
        }
    }
}
