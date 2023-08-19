using System;
using System.Collections.Generic;

namespace Progra6_PF_2023_Aplicacion.Models
{
    public partial class ApartadosProducto
    {
        public int ApartadosApartadosId { get; set; }
        public int ProductoProductoId { get; set; }
        public decimal PrecioOriginal { get; set; }
        public decimal AbonoAgregado { get; set; }

        public virtual Apartado? ApartadosApartados { get; set; } = null!;
        public virtual Producto? ProductoProducto { get; set; } = null!;
    }
}
