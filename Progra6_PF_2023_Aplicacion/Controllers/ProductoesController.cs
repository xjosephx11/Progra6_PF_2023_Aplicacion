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
    //[Apikey]
    public class ProductoesController : ControllerBase
    {
        private readonly Progra6_PF_2023Context _context;

        public ProductoesController(Progra6_PF_2023Context context)
        {
            _context = context;
        }

        // GET: api/Productoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
          if (_context.Productos == null)
          {
              return NotFound();
          }
            return await _context.Productos.ToListAsync();
        }

        // GET: api/Productoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
          if (_context.Productos == null)
          {
              return NotFound();
          }
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // GET: api/Productoes/GetProductoListByUser?id=2'
        //
        [HttpGet("GetProductoListByUser")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductoListByUser(int id)
        {
            if (_context.Productos == null)
            {
                return NotFound();
            }
            var productoList = await _context.Productos.Where(p => p.UsuarioId.Equals(id)).ToListAsync();

            if (productoList == null)
            {
                return NotFound();
            }

            return productoList;
        }

        // PUT: api/Productoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.ProductoId)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
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

        // POST: api/Productoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
          if (_context.Productos == null)
          {
              return Problem("Entity set 'Progra6_PF_2023Context.Productos'  is null.");
          }
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducto", new { id = producto.ProductoId }, producto);
        }

       

        private bool ProductoExists(int id)
        {
            return (_context.Productos?.Any(e => e.ProductoId == id)).GetValueOrDefault();
        }
    }
}
