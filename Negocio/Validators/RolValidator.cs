using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class RolCreateValidator : AbstractValidator<RolCreateDto>
    {
        public RolCreateValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del rol es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(255).WithMessage("La descripción no puede exceder los 255 caracteres.");

            RuleFor(x => x.ModulosPermitidos)
                .NotNull().WithMessage("La lista de módulos permitidos no puede ser nula.");
        }
    }

    public class RolUpdateValidator : AbstractValidator<RolUpdateDto>
    {
        public RolUpdateValidator()
        {
            RuleFor(x => x.RolID)
                .GreaterThan(0).WithMessage("ID de rol no válido.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del rol es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(255).WithMessage("La descripción no puede exceder los 255 caracteres.");

            RuleFor(x => x.ModulosPermitidos)
                .NotNull().WithMessage("La lista de módulos permitidos no puede ser nula.");
        }
    }
}
