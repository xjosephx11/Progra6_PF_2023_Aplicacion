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
    public class AbonoesController : ControllerBase
    {
        private readonly Progra6_PF_2023Context _context;

        public AbonoesController(Progra6_PF_2023Context context)
        {
            _context = context;
        }

        // GET: api/Abonoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Abono>>> GetAbonos()
        {
          if (_context.Abonos == null)
          {
              return NotFound();
          }
            return await _context.Abonos.ToListAsync();
        }

        // GET: api/Abonoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Abono>> GetAbono(int id)
        {
          if (_context.Abonos == null)
          {
              return NotFound();
          }
            var abono = await _context.Abonos.FindAsync(id);

            if (abono == null)
            {
                return NotFound();
            }

            return abono;
        }

        // PUT: api/Abonoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbono(int id, Abono abono)
        {
            if (id != abono.AbonoId)
            {
                return BadRequest();
            }

            _context.Entry(abono).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbonoExists(id))
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

        // POST: api/Abonoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Abono>> PostAbono(Abono abono)
        {
          if (_context.Abonos == null)
          {
              return Problem("Entity set 'Progra6_PF_2023Context.Abonos'  is null.");
          }
            _context.Abonos.Add(abono);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbono", new { id = abono.AbonoId }, abono);
        }

        // DELETE: api/Abonoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbono(int id)
        {
            if (_context.Abonos == null)
            {
                return NotFound();
            }
            var abono = await _context.Abonos.FindAsync(id);
            if (abono == null)
            {
                return NotFound();
            }

            _context.Abonos.Remove(abono);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AbonoExists(int id)
        {
            return (_context.Abonos?.Any(e => e.AbonoId == id)).GetValueOrDefault();
        }
    }
}
