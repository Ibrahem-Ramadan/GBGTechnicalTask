using FluentValidation;
using GBGTechnicalTask.Core.Features.Students.Commands.Models;
using GBGTechnicalTask.Infrastructure.IRepositories;
using GBGTechnicalTask.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBGTechnicalTask.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator:AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        public AddStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(stud=>stud.StudentName)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull().WithMessage("{PropertyName} is Required")
                .MaximumLength(50).WithMessage("{PropertyName} Max Length is 50 characters")
                .MinimumLength(4).WithMessage("{PropertyName} Min Length is 4 characters");
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(stud => stud.StudentName)
                .MustAsync(async (StudentName, CancellationToken) => !await _studentService.IsStudentNameExist(StudentName))
                .WithMessage("{PropertyName} already exists");

        }
    }
}
