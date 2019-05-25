using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public List<GenerosLibros> GenerosLibros { get; set; }

    }
}
