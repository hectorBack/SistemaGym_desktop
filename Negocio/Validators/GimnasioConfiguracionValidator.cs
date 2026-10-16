using FluentValidation;
using Negocio.DTOs;

namespace Negocio.Validators
{
    public class GimnasioConfiguracionValidator : AbstractValidator<GimnasioConfiguracionDto>
    {
        public GimnasioConfiguracionValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .WithMessage("El nombre del gimnasio es obligatorio.")
                .MaximumLength(100)
                .WithMessage("El nombre del gimnasio no puede exceder los 100 caracteres.");

            RuleFor(x => x.Domicilio)
                .MaximumLength(255)
                .WithMessage("El domicilio no puede exceder los 255 caracteres.");

            RuleFor(x => x.Telefono)
                .MaximumLength(50)
                .WithMessage("El teléfono no puede exceder los 50 caracteres.");

            RuleFor(x => x.Rfc)
                .MaximumLength(50)
                .WithMessage("El RFC no puede exceder los 50 caracteres.");

            RuleFor(x => x.Mensaje)
                .MaximumLength(255)
                .WithMessage("El mensaje de bienvenida no puede exceder los 255 caracteres.");
        }
    }
}
