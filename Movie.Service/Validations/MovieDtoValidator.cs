using FluentValidation;
using MovieApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Validations
{
    public class MovieDtoValidator:AbstractValidator<MovieDto>
    {
        public MovieDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x=>x.DirectorId).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.");

        }
    }
}
