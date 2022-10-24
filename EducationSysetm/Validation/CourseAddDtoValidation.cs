using Core.Entity;
using EducationSysetm.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.Validation
{
    public class CourseAddDtoValidation: AbstractValidator<CourseAddDto>
    {
        public CourseAddDtoValidation()
        {
            RuleFor(c => c.Title).NotNull()
                .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
                .MinimumLength(3)
                .MaximumLength(15);

            RuleFor(c => c.FullPrice).NotNull().NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(c => c.Level).NotNull().NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(c => c.StartDate).NotNull().NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
           
              





        }

    }
}
