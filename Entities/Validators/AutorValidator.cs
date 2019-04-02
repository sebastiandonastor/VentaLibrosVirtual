using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Validators
{
   public class AutorValidator : AbstractValidator<Autor>
    {
        public AutorValidator()
        {
            RuleSet("addAutor", () => { 
                RuleFor(a => a.Seudonimo).NotEmpty().NotNull();
                });
        }
    }
}
