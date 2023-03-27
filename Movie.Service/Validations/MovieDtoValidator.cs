using FluentValidation;
using Movie.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Service.Validations
{
    public class MovieDtoValidator:AbstractValidator<MovieDto>
    {
        public MovieDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.");

        }
    }
}
