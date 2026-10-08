using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class CorteConfiguracionValidator : AbstractValidator<CorteConfiguracionDto>
    {
        public CorteConfiguracionValidator()
        {
            RuleFor(x => x.EfectivoInicial)
                .GreaterThanOrEqualTo(0)
                .WithMessage("El efectivo inicial no puede ser un valor negativo.");

            RuleFor(x => x.EmailNotificacion)
                .NotEmpty()
                .WithMessage("El correo electrónico para notificaciones es obligatorio.")
                .EmailAddress()
                .WithMessage("El formato del correo electrónico de notificación no es válido.")
                .MaximumLength(150)
                .WithMessage("El correo electrónico no puede exceder los 150 caracteres.");
        }
    }
}
