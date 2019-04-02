using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Validators
{
    public class CompraValidator : AbstractValidator<Compra>
    {
        public CompraValidator()
        {
            RuleSet("addCompra", () => { 
                RuleFor(C => C.MontoPagado).NotNull().NotEmpty();
                });
        }
    }
}
