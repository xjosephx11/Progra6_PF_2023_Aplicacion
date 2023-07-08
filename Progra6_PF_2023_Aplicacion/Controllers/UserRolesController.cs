using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Progra6_PF_2023_Aplicacion.Models;
using Progra6_PF_2023_Aplicacion.Attributes;

namespace Progra6_PF_2023_Aplicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Apikey]
    public class UserRolesController : ControllerBase
    {
        private readonly Progra6_PF_2023Context _context;

        public UserRolesController(Progra6_PF_2023Context context)
        {
            _context = context;
        }

        // GET: api/UserRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioRol>>> GetUsuarioRols()
        {
          if (_context.UsuarioRols == null)
          {
              return NotFound();
          }
            return await _context.UsuarioRols.ToListAsync();
        }

        // GET: api/UserRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioRol>> GetUsuarioRol(int id)
        {
          if (_context.UsuarioRols == null)
          {
              return NotFound();
          }
            var usuarioRol = await _context.UsuarioRols.FindAsync(id);

            if (usuarioRol == null)
            {
                return NotFound();
            }

            return usuarioRol;
        }

        // PUT: api/UserRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioRol(int id, UsuarioRol usuarioRol)
        {
            if (id != usuarioRol.UsuarioRolId)
            {
                return BadRequest();
            }

            _context.Entry(usuarioRol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioRolExists(id))
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

        // POST: api/UserRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioRol>> PostUsuarioRol(UsuarioRol usuarioRol)
        {
          if (_context.UsuarioRols == null)
          {
              return Problem("Entity set 'Progra6_PF_2023Context.UsuarioRols'  is null.");
          }
            _context.UsuarioRols.Add(usuarioRol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioRol", new { id = usuarioRol.UsuarioRolId }, usuarioRol);
        }

        

        private bool UsuarioRolExists(int id)
        {
            return (_context.UsuarioRols?.Any(e => e.UsuarioRolId == id)).GetValueOrDefault();
        }
    }
}
