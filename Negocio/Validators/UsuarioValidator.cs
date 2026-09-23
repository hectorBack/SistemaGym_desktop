using FluentValidation;
using Negocio.DTOs;
using Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class UsuarioCreateValidator : AbstractValidator<UsuarioCreateDto>
    {
        public UsuarioCreateValidator()
        {
            RuleFor(x => x.NombreCompleto)
                .NotEmpty().WithMessage("El nombre completo es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre completo no puede exceder los 100 caracteres.");

            RuleFor(x => x.NombreUsuario)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre de usuario no puede exceder los 50 caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria.")
                .MinimumLength(4).WithMessage("La contraseña debe tener al menos 4 caracteres.")
                .MaximumLength(255).WithMessage("La contraseña no puede exceder los 255 caracteres.");

            RuleFor(x => x.RolID)
                .GreaterThan(0).WithMessage("Debe seleccionar un rol válido.");
        }
    }

    public class UsuarioUpdateValidator : AbstractValidator<UsuarioUpdateDto>
    {
        public UsuarioUpdateValidator()
        {
            RuleFor(x => x.UsuarioID)
                .GreaterThan(0).WithMessage("ID de usuario no válido.");

            RuleFor(x => x.NombreCompleto)
                .NotEmpty().WithMessage("El nombre completo es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre completo no puede exceder los 100 caracteres.");

            RuleFor(x => x.NombreUsuario)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre de usuario no puede exceder los 50 caracteres.");

            // Al actualizar, la contraseña solo se valida si se proporciona una nueva
            When(x => !string.IsNullOrEmpty(x.Password), () =>
            {
                RuleFor(x => x.Password)
                    .MinimumLength(4).WithMessage("La contraseña debe tener al menos 4 caracteres.")
                    .MaximumLength(255).WithMessage("La contraseña no puede exceder los 255 caracteres.");
            });

            RuleFor(x => x.RolID)
                .GreaterThan(0).WithMessage("Debe seleccionar un rol válido.");
        }
    }
}
