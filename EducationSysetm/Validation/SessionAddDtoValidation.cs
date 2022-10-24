using EducationSysetm.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.Validation
{
    public class SessionAddDtoValidation : AbstractValidator<SessionAddDto>
    {
        public SessionAddDtoValidation()
        {
            RuleFor(s => s.SessionNumber).NotNull()
               .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
               .MinimumLength(0)
               .MaximumLength(10);
            RuleFor(s => s.Date).NotNull().NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");

        }
    }
}
