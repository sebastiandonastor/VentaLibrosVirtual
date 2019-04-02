using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Validators
{
    public class UserInfoValidator : AbstractValidator<UserInfo>
    {
        public UserInfoValidator()
        {
            RuleSet("Logear", () => {
                RuleFor(u => u.Username).NotEmpty().NotNull();
                RuleFor(u => u.Password).NotEmpty().NotNull().Length(6,15);
                });

        }
    }
}
