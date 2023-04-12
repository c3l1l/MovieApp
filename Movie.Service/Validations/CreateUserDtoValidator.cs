using FluentValidation;
using MovieApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Validations
{
    public class CreateUserDtoValidator:AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is wrong");
            RuleFor(u => u.Password).NotEmpty().NotEmpty().WithMessage("Password is required");
            RuleFor(u => u.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }
}
