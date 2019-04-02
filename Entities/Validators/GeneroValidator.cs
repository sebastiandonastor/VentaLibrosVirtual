using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Validators
{
    public class GeneroValidator : AbstractValidator<Genero>
    {
        public GeneroValidator()
        {
            RuleSet("addGenero", () =>
            {
                RuleFor(g => g.Nombre).NotEmpty().NotNull();
            });
        }
    }
}
