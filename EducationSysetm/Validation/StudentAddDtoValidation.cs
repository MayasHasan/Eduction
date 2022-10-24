using EducationSysetm.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.Validation
{
    public class StudentAddDtoValidation : AbstractValidator<StudentAddDto>
    {
        public StudentAddDtoValidation()
        {

            RuleFor(s => s.FirstName).NotNull()
                .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
                .MinimumLength(3)
                .MaximumLength(15);

            RuleFor(s => s.LastName).NotNull()
               .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
               .MinimumLength(3)
               .MaximumLength(15);

            RuleFor(s => s.Phone)
               .MinimumLength(3)
               .MaximumLength(15);
        }
    }
}
