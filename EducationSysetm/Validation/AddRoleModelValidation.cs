using Core.ModelForAuth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.Validation
{
    public class AddRoleModelValidation : AbstractValidator<AddRoleModel>
    {
        public AddRoleModelValidation()
        {
            RuleFor(r => r.UserId).NotNull()
               .NotEmpty();

            RuleFor(r => r.Role).NotNull()
               .NotEmpty();
        }
    }
}
