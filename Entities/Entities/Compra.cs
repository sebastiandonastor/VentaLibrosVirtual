using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Compra
    {
        public int Id { get; set; }
        public string IdUsuario { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool Estado { get; set; }
        public Decimal MontoPagado { get; set; }
        public List<ComprasLibros> ComprasLibros { get; set; }
        public ApplicationUser Usuario { get; set; }



    }
}
