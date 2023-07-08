using FluentValidation;
using GBGTechnicalTask.Core.Features.Enrollments.Commands.Models;
using GBGTechnicalTask.Data.Entities;
using GBGTechnicalTask.Service.IServices;
using Microsoft.AspNetCore.Connections.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBGTechnicalTask.Core.Features.Enrollments.Commands.Validators
{
    public class AddEnrollmentValidator:AbstractValidator<AddEnrollmentCommand>
    {
        private readonly IEnrollmentService _enrollmentService;

        public AddEnrollmentValidator(IEnrollmentService enrollmentService)
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            _enrollmentService = enrollmentService;
        }

        public void ApplyValidationsRules()
        {
            RuleFor(e => e.CourseId)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull().WithMessage("{PropertyName} is Required");

            RuleFor(e => e.StudentId)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull().WithMessage("{PropertyName} is Required");
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(e =>
                new Enrollment
                {
                    CourseId = e.CourseId,
                    StudentId = e.StudentId
                }).MustAsync(async (Enrollment, CancellationToken) => !await _enrollmentService.IsStudentAlreadyRegisteredToTheCourse(Enrollment))
                .WithMessage("Student Already Registered to this Course");
        }
    }
}
