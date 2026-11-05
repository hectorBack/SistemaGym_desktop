using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class MasConfiguracionesValidator : AbstractValidator<MasConfiguracionesDto>
    {
        public MasConfiguracionesValidator()
        {
            RuleFor(x => x.Moneda)
                .NotEmpty().WithMessage("El símbolo de moneda es obligatorio.")
                .MaximumLength(5).WithMessage("El símbolo de moneda no puede exceder 5 caracteres.")
                .Matches(@"^[\p{Sc}A-Za-z]{1,5}$")
                .WithMessage("Ingrese un símbolo de moneda válido, por ejemplo $, US$ o €.");
        }
    }
}
