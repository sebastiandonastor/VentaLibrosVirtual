using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
   public class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Seudonimo { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public List<AutoresLibros> AutoresLibros { get; set; }
    }
}
