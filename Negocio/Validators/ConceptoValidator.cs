using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class ConceptoCreateValidator : AbstractValidator<ConceptoCreateDto>
    {
        public ConceptoCreateValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del concepto es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.Tipo)
                .NotEmpty().WithMessage("El tipo de concepto es obligatorio.")
                .MaximumLength(50).WithMessage("El tipo no puede exceder los 50 caracteres.");

            RuleFor(x => x.Observacion)
                .MaximumLength(255).WithMessage("La observación no puede exceder los 255 caracteres.");
        }
    }

    public class ConceptoUpdateValidator : AbstractValidator<ConceptoUpdateDto>
    {
        public ConceptoUpdateValidator()
        {
            RuleFor(x => x.ConceptoID)
                .GreaterThan(0).WithMessage("ID de concepto no válido.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del concepto es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.Tipo)
                .NotEmpty().WithMessage("El tipo de concepto es obligatorio.")
                .MaximumLength(50).WithMessage("El tipo no puede exceder los 50 caracteres.");

            RuleFor(x => x.Observacion)
                .MaximumLength(255).WithMessage("La observación no puede exceder los 255 caracteres.");
        }
    }
}
