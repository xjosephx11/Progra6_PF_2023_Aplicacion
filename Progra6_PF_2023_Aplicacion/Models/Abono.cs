using System;
using System.Collections.Generic;

namespace Progra6_PF_2023_Aplicacion.Models
{
    public partial class Abono
    {
        public int AbonoId { get; set; }
        public DateTime FechaAbono { get; set; }
        public int ApartadosId { get; set; }
        public decimal MontoAbono { get; set; }

        public virtual Apartado Apartados { get; set; } = null!;
    }
}
