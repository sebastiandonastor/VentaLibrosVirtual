using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public List<Compra> Compras { get; set; }
        public DetalleUsuario DetalleUsuario { get; set; }

        public String Nombres { get; set; }
        public String Apellidos { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }

        public bool Estado { get; set; }
    }
}
