using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class CorreosConfiguracionValidator : AbstractValidator<CorreosConfiguracionDto>
    {
        public CorreosConfiguracionValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido.")
                .MaximumLength(150).WithMessage("El correo electrónico no puede exceder los 150 caracteres.");

            RuleFor(x => x.Password)
                .MaximumLength(100).WithMessage("La contraseña no puede exceder los 100 caracteres.");
        }
    }
}
