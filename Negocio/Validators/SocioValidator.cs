using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class SocioCreateValidator : AbstractValidator<SocioCreateDto>
    {
        public SocioCreateValidator()
        {
            RuleFor(x => x.Clave)
                .NotEmpty().WithMessage("La clave del socio es obligatoria.")
                .MaximumLength(20).WithMessage("La clave no puede exceder los 20 caracteres.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede exceder los 50 caracteres.");

            RuleFor(x => x.Telefono)
                .MaximumLength(20).WithMessage("El teléfono no puede exceder los 20 caracteres.");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("El formato del correo electrónico no es válido.")
                .MaximumLength(100).WithMessage("El correo electrónico no puede exceder los 100 caracteres.");
        }
    }

    public class SocioUpdateValidator : AbstractValidator<SocioUpdateDto>
    {
        public SocioUpdateValidator()
        {
            RuleFor(x => x.SocioID)
                .GreaterThan(0).WithMessage("ID de socio no válido.");

            RuleFor(x => x.Clave)
                .NotEmpty().WithMessage("La clave del socio es obligatoria.")
                .MaximumLength(20).WithMessage("La clave no puede exceder los 20 caracteres.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede exceder los 50 caracteres.");

            RuleFor(x => x.Telefono)
                .MaximumLength(20).WithMessage("El teléfono no puede exceder los 20 caracteres.");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("El formato del correo electrónico no es válido.")
                .MaximumLength(100).WithMessage("El correo electrónico no puede exceder los 100 caracteres.");
        }
    }
}
