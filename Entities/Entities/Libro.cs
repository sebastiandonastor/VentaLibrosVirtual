using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
   public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int Stock { get; set; }
        public Decimal Precio { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public List<AutoresLibros> AutoresLibros { get; set; }
        public List<GenerosLibros> GenerosLibros { get; set; }
        public List<ComprasLibros> ComprasLibros { get; set; }


    }
}
