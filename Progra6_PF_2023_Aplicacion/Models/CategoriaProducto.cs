using System;
using System.Collections.Generic;

namespace Progra6_PF_2023_Aplicacion.Models
{
    public partial class CategoriaProducto
    {
        public CategoriaProducto()
        {
            Productos = new HashSet<Producto>();
        }

        public int CategoriaProductoId { get; set; }
        public string Descripcion { get; set; } = null!;
        public int UsuarioId { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
