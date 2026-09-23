using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class MembresiaCreateValidator : AbstractValidator<MembresiaCreateDto>
    {
        public MembresiaCreateValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre de la membresía es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.Precio)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0.");

            RuleFor(x => x.DuracionDias)
                .GreaterThan(0).WithMessage("La duración debe ser de al menos 1 día.");
        }
    }

    public class MembresiaUpdateValidator : AbstractValidator<MembresiaUpdateDto>
    {
        public MembresiaUpdateValidator()
        {
            RuleFor(x => x.MembresiaID)
                .GreaterThan(0).WithMessage("ID de membresía no válido.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre de la membresía es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.Precio)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0.");

            RuleFor(x => x.DuracionDias)
                .GreaterThan(0).WithMessage("La duración debe ser de al menos 1 día.");

            RuleFor(x => x.Activo)
            .NotNull().WithMessage("El estado activo/inactivo es obligatorio.");
        }
    }
}
