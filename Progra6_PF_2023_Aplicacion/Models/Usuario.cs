using System;
using System.Collections.Generic;

namespace Progra6_PF_2023_Aplicacion.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Apartados = new HashSet<Apartado>();
        }

        public int UsuarioId { get; set; }
        public string Email { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string BackupEmail { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public bool? Avtivo { get; set; }
        public string? Addres { get; set; }
        public int UsuarioRolId { get; set; }
        public bool IsBlocked { get; set; }

        public virtual UsuarioRol UsuarioRol { get; set; } = null!;
        public virtual ICollection<Apartado> Apartados { get; set; }
    }
}
