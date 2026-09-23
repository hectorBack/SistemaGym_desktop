using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class PagoSocioMembresiaCreateValidator : AbstractValidator<PagoSocioMembresiaCreateDto>
    {
        public PagoSocioMembresiaCreateValidator()
        {
            RuleFor(x => x.SocioMembresiaID)
                .GreaterThan(0).WithMessage("Debe especificar una membresía de socio válida.");

            RuleFor(x => x.Monto)
                .GreaterThan(0).WithMessage("El monto del pago debe ser mayor a $0.00.");

            RuleFor(x => x.FormaPago)
                .NotEmpty().WithMessage("La forma de pago es obligatoria.")
                .MaximumLength(30).WithMessage("La forma de pago no puede exceder los 30 caracteres.");

            RuleFor(x => x.Folio)
                .MaximumLength(50).WithMessage("El folio no puede exceder los 50 caracteres.");

            RuleFor(x => x.Observacion)
                .MaximumLength(255).WithMessage("La observación no puede exceder los 255 caracteres.");
        }
    }

    public class PagoSocioMembresiaUpdateValidator : AbstractValidator<PagoSocioMembresiaUpdateDto>
    {
        public PagoSocioMembresiaUpdateValidator()
        {
            RuleFor(x => x.PagoID)
                .GreaterThan(0).WithMessage("ID de pago no válido.");

            RuleFor(x => x.Monto)
                .GreaterThan(0).WithMessage("El monto del pago debe ser mayor a $0.00.");

            RuleFor(x => x.FormaPago)
                .NotEmpty().WithMessage("La forma de pago es obligatoria.")
                .MaximumLength(30).WithMessage("La forma de pago no puede exceder los 30 caracteres.");

            RuleFor(x => x.Folio)
                .MaximumLength(50).WithMessage("El folio no puede exceder los 50 caracteres.");

            RuleFor(x => x.Observacion)
                .MaximumLength(255).WithMessage("La observación no puede exceder los 255 caracteres.");
        }
    }
}
