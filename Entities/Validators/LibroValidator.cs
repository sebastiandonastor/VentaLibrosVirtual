using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Validators
{
    public class LibroValidator : AbstractValidator<Libro>
    {
        public LibroValidator()
        {
            RuleSet("addLibro",  () => { 
                RuleFor(l => l.Stock).NotEmpty().NotNull();
                RuleFor(l => l.FechaPublicacion).NotEmpty().NotNull();
                RuleFor(l => l.Titulo).NotEmpty().NotNull();
                RuleFor(l => l.Precio).NotEmpty().NotNull();

                });
        }
    }
}
