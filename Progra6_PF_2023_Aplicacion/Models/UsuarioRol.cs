using System;
using System.Collections.Generic;

namespace Progra6_PF_2023_Aplicacion.Models
{
    public partial class UsuarioRol
    {
        public UsuarioRol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int UsuarioRolId { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
