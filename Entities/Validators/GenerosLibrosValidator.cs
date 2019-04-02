using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Validators
{
    public class GenerosLibrosValidator : AbstractValidator<GenerosLibros>
    {
        public GenerosLibrosValidator()
        {
            RuleSet("addGenerosLibros", () =>
            {
                RuleFor(g => g.IdGenero).NotEmpty().NotNull();
                RuleFor(g => g.IdLibro).NotEmpty().NotNull();
            });
        }
    }
}
