using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Validators
{
   public class DetalleUsuarioValidator : AbstractValidator<DetalleUsuario>
    {
        public DetalleUsuarioValidator()
        {
            RuleSet("addDetalleUsuario", () =>
            {
                RuleFor(c => c.Premium).NotNull();
            });
        }
    }
}
