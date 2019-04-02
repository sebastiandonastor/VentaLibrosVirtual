using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class ComprasLibros
    {
        public int IdCompra { get; set; }
        public int IdLibro { get; set; }


        public Compra Compra { get; set; }
        public Libro Libro { get; set; }

        public int Cantidad { get; set; }
        public Decimal PrecioTotal { get { return Libro.Precio * Cantidad ;}  }
    }
}
