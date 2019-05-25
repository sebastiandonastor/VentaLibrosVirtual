using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class DetalleUsuario
    {
        public string Id { get; set; }
        public bool Premium { get; set; }

        public ApplicationUser Usuario { get; set; }

        public bool Estado { get; set; }

    }
}
