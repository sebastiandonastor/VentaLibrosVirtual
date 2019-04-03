using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Validators
{
    public class RoleValidator : AbstractValidator<ApplicationRole>
    {
        public RoleValidator()
        {
            RuleSet("addRole", () =>
            {
                RuleFor(r => r.Name).NotEmpty().NotNull();
            });
        }
    }
}
