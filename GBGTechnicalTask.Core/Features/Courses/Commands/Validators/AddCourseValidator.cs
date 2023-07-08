using FluentValidation;
using GBGTechnicalTask.Core.Features.Courses.Commands.Models;
using GBGTechnicalTask.Service.IServices;
using GBGTechnicalTask.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBGTechnicalTask.Core.Features.Courses.Commands.Validators
{
    public class AddCourseValidator:AbstractValidator<AddCourseCommand>
    {
        private readonly ICourseService _courseService;
        public AddCourseValidator(ICourseService courseService)
        {
           _courseService = courseService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        public void ApplyValidationRules()
        {
            RuleFor(crs => crs.CourseName)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull().WithMessage("{PropertyName} is Required")
                .MaximumLength(50).WithMessage("{PropertyName} Max Length is 50 characters")
                .MinimumLength(4).WithMessage("{PropertyName} Min Length is 4 characters");
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(crs => crs.CourseName)
                .MustAsync(async (CourseName, CancellationToken) => !await _courseService.IsCourseNameExist(CourseName))
                .WithMessage("{PropertyName} already exists");

        }
    }
}
