using EducationSysetm.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.Validation
{
    public class TeacherAddDtoValidation : AbstractValidator<TeacherAddDto>
    {
        public TeacherAddDtoValidation()
        {
            RuleFor(t => t.FirstName).NotNull()
              .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
              .MinimumLength(3)
              .MaximumLength(15);

            RuleFor(t => t.LastName).NotNull()
               .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
               .MinimumLength(3)
               .MaximumLength(15);

            RuleFor(c => c.Salary).NotNull().NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");

        }
    }
}
