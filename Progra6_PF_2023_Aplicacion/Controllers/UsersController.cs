using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Progra6_PF_2023_Aplicacion.Attributes;
using Progra6_PF_2023_Aplicacion.Models;
using Progra6_PF_2023_Aplicacion.ModelsDTOs;

namespace Progra6_PF_2023_Aplicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Apikey]
    public class UsersController : ControllerBase
    {
        private readonly Progra6_PF_2023Context _context;

        public UsersController(Progra6_PF_2023Context context)
        {
            _context = context;
        }

        [HttpGet("ValidateLogin")]
        public async Task<ActionResult<Usuario>> ValidateLogin(string username, string password)
        {
            var user = await _context.Usuarios.SingleOrDefaultAsync
                (e => e.Email.Equals(username) && e.Contrasenia == password);
            if (user == null)
            {
                return NotFound();
            }
            else 
            {
                return Ok(user);
            }
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        //{
        //    if (id != usuario.UsuarioId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(usuario).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UsuarioExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        [HttpGet("GetUserInfoByEmail")]
        public ActionResult<IEnumerable<UserDTO>> GetUserInfoByEmail(string Pemail)
        {
            var query = (from u in _context.Usuarios
                         join ur in _context.UsuarioRols on
                         u.UsuarioRolId equals ur.UsuarioRolId
                         where u.Email == Pemail && u.Avtivo == true &&
                         u.IsBlocked == false
                         select new
                         {
                             idusuario = u.UsuarioId,
                             correo = u.Email,
                             contrasennia = u.Contrasenia,
                             nombre = u.Nombre,
                             recuperarEmail = u.BackupEmail,
                             telefono = u.Numero,
                             activo = u.Avtivo,
                             direccion = u.Addres,
                             establoqueado = u.IsBlocked,
                             idrol = ur.UsuarioRolId,
                             descripcion = ur.Descripcion
                         }).ToList();
            List<UserDTO> list = new List<UserDTO> ();
            foreach (var item in query) 
            {
                UserDTO NewItem = new UserDTO()
                {
                    IDUsuariodto = item.idusuario,
                    Correodto = item.correo,
                    Contraseniadto = item.contrasennia,
                    Nombredto = item.nombre,
                    correoRespaldodto = item.recuperarEmail,
                    Telefonodto = item.telefono,
                    Avtivodto = item.activo,
                    direcciondto = item.direccion,
                    estaBloqueadodto = item.establoqueado,
                    idroldto = item.idrol,
                    descripcionRoldto = item.descripcion
                };
                list.Add(NewItem);
            }
            if (list == null)
            {
                return NotFound();
            }
            return list;
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO user)
        {
            if (id != user.IDUsuariodto)
            {
                return BadRequest();
            }


            //tenemos que hacer la convercion entre el dto que llega en formato
            //json  en el header y el objeto que entity framework entiende que es
            //de tipo user

            Usuario? NewEFUser = GetUSerByID(id);
            if (NewEFUser != null)
            {
                NewEFUser.Email = user.Correodto;
                NewEFUser.Nombre = user.Nombredto;
                NewEFUser.BackupEmail = user.correoRespaldodto;
                NewEFUser.Numero = user.Telefonodto;
                NewEFUser.Addres = user.direcciondto;
                _context.Entry(NewEFUser).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }


        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
          if (_context.Usuarios == null)
          {
              return Problem("Entity set 'Progra6_PF_2023Context.Usuarios'  is null.");
          }
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.UsuarioId }, usuario);
        }

        

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.UsuarioId == id)).GetValueOrDefault();
        }

        private Usuario? GetUSerByID(int id)
        {
            var user = _context.Usuarios.Find(id);
            return user;
        }
    }
}
