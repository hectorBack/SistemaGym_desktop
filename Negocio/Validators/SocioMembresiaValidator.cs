using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class AsignarMembresiaValidator : AbstractValidator<AsignarMembresiaDto>
    {
        public AsignarMembresiaValidator()
        {
            RuleFor(x => x.SocioID)
                .GreaterThan(0).WithMessage("Debe especificar un socio válido.");

            RuleFor(x => x.MembresiaID)
                .GreaterThan(0).WithMessage("Debe seleccionar una membresía válida.");

            RuleFor(x => x.FechaInicio)
                .NotEmpty().WithMessage("La fecha de inicio es obligatoria.");
        }
    }
}
