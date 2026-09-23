using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class MovimientoCreateValidator : AbstractValidator<MovimientoCreateDto>
    {
        public MovimientoCreateValidator()
        {
            RuleFor(x => x.Tipo)
                .NotEmpty().WithMessage("El tipo de movimiento es obligatorio.")
                .Must(tipo => tipo == "Ingreso" || tipo == "Egreso")
                .WithMessage("El tipo debe ser 'Ingreso' o 'Egreso'.");

            RuleFor(x => x.ConceptoID)
                .GreaterThan(0).WithMessage("Debe seleccionar un concepto válido.");

            RuleFor(x => x.FormaPago)
                .NotEmpty().WithMessage("La forma de pago es obligatoria.")
                .MaximumLength(30).WithMessage("La forma de pago no puede exceder los 30 caracteres.");

            RuleFor(x => x.Total)
                .GreaterThan(0).WithMessage("El total debe ser mayor a cero.");

            RuleFor(x => x.Observacion)
                .MaximumLength(255).WithMessage("La observación no puede exceder los 255 caracteres.");
        }
    }

    public class MovimientoUpdateValidator : AbstractValidator<MovimientoUpdateDto>
    {
        public MovimientoUpdateValidator()
        {
            RuleFor(x => x.MovimientoID)
                .GreaterThan(0).WithMessage("ID de movimiento no válido.");

            RuleFor(x => x.Tipo)
                .NotEmpty().WithMessage("El tipo de movimiento es obligatorio.")
                .Must(tipo => tipo == "Ingreso" || tipo == "Egreso")
                .WithMessage("El tipo debe ser 'Ingreso' o 'Egreso'.");

            RuleFor(x => x.ConceptoID)
                .GreaterThan(0).WithMessage("Debe seleccionar un concepto válido.");

            RuleFor(x => x.FormaPago)
                .NotEmpty().WithMessage("La forma de pago es obligatoria.")
                .MaximumLength(30).WithMessage("La forma de pago no puede exceder los 30 caracteres.");

            RuleFor(x => x.Total)
                .GreaterThan(0).WithMessage("El total debe ser mayor a cero.");

            RuleFor(x => x.Observacion)
                .MaximumLength(255).WithMessage("La observación no puede exceder los 255 caracteres.");
        }
    }
}
