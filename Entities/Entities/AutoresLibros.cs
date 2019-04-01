using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class AutoresLibros
    {
        public int IdAutor { get; set; }
        public int IdLibro { get; set; }


        public Autor Autor { get; set; }
        public Libro Libro { get; set; }

    }
}
