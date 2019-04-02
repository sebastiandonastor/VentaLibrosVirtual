using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Validators
{
    public class ComprasLibrosValidator : AbstractValidator<ComprasLibros>
    {
        public ComprasLibrosValidator()
        {
            RuleSet("addComprasLibros", () => { 
                RuleFor(c => c.IdCompra).NotNull().NotEmpty();
                RuleFor(c => c.Cantidad).NotNull().NotEmpty();
                RuleFor(c => c.IdLibro).NotNull().NotEmpty();
                }); 
        }
    }
}
