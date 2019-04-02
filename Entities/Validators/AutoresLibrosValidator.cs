using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Validators
{
    public class AutoresLibrosValidator : AbstractValidator<AutoresLibros>
    {
        public AutoresLibrosValidator()
        {
            RuleSet("addAutoresLibros", () =>
            {
                RuleFor(a => a.IdAutor).NotEmpty().NotNull();
                RuleFor(a => a.IdLibro).NotEmpty().NotNull();
            });
        }
    }
}
