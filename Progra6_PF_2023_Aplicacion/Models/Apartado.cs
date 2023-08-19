using System;
using System.Collections.Generic;

namespace Progra6_PF_2023_Aplicacion.Models
{
    public partial class Apartado
    {
        public Apartado()
        {
            Abonos = new HashSet<Abono>();
            ApartadosProductos = new HashSet<ApartadosProducto>();
        }

        public string NombreCliente { get; set; } = null!;
        public int ApartadosId { get; set; }
        public string TelefonoUsuario { get; set; } = null!;
        public int CedulaCliente { get; set; }
        public string? EmailCliente { get; set; }
        public DateTime FechaApartado { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario? Usuario { get; set; } = null!;
        public virtual ICollection<Abono>? Abonos { get; set; }
        public virtual ICollection<ApartadosProducto>? ApartadosProductos { get; set; }
    }
}
