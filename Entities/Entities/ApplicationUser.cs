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
    }
}
