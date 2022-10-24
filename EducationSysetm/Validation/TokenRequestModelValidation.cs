using Core.ModelForAuth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.Validation
{
    public class TokenRequestModelValidation: AbstractValidator<TokenRequestModel>
    {
        public TokenRequestModelValidation()
        {
            RuleFor(r => r.Email).NotNull()
               .NotEmpty();

            RuleFor(r => r.Password).NotNull()
               .NotEmpty();


        }
    }
}
