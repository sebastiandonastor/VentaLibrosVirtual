using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class GenerosLibros 
    {
        public int IdGenero { get; set; }
        public int IdLibro { get; set; }

        public Genero Genero { get; set; }
        public Libro Libro { get; set; }

    }
}
