using System;
using System.Collections.Generic;

namespace Progra6_PF_2023_Aplicacion.Models
{
    public partial class Producto
    {
        public Producto()
        {
            ApartadosProductos = new HashSet<ApartadosProducto>();
        }

        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Stock { get; set; } = null!;
        public string Talla { get; set; } = null!;
        public string Precio { get; set; } = null!;
        public bool? Activo { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaProductoId { get; set; }

        public virtual CategoriaProducto CategoriaProducto { get; set; } = null!;
        public virtual ICollection<ApartadosProducto> ApartadosProductos { get; set; }
    }
}
