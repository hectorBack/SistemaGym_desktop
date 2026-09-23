using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class VisitaCreateValidator : AbstractValidator<VisitaCreateDto>
    {
        public VisitaCreateValidator()
        {
            RuleFor(x => x.Clave)
                .NotEmpty().WithMessage("La clave de acceso es obligatoria.")
                .MaximumLength(50).WithMessage("La clave no puede exceder los 50 caracteres.");

            // Si la clave es "100" (Visita Casual), el Nombre es obligatorio
            When(x => x.Clave != null && x.Clave.Trim() == "100", () =>
            {
                RuleFor(x => x.Nombre)
                    .NotEmpty().WithMessage("El nombre del visitante es obligatorio para visitas casuales.")
                    .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

                RuleFor(x => x.MembresiaID)
                    .NotNull().WithMessage("Debe seleccionar el tipo de membresía/pase de visita.")
                    .GreaterThan(0).WithMessage("Debe seleccionar una membresía válida.");
            });

            RuleFor(x => x.Apellido)
                .MaximumLength(100).WithMessage("El apellido no puede exceder los 100 caracteres.");

            RuleFor(x => x.Telefono)
                .MaximumLength(20).WithMessage("El teléfono no puede exceder los 20 caracteres.");

            RuleFor(x => x.Observaciones)
                .MaximumLength(255).WithMessage("Las observaciones no pueden exceder los 255 caracteres.");
        }
    }

    public class VisitaUpdateValidator : AbstractValidator<VisitaUpdateDto>
    {
        public VisitaUpdateValidator()
        {
            RuleFor(x => x.VisitaID)
                .GreaterThan(0).WithMessage("ID de visita no válido.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.Apellido)
                .MaximumLength(100).WithMessage("El apellido no puede exceder los 100 caracteres.");

            RuleFor(x => x.Telefono)
                .MaximumLength(20).WithMessage("El teléfono no puede exceder los 20 caracteres.");

            RuleFor(x => x.Observaciones)
                .MaximumLength(255).WithMessage("Las observaciones no pueden exceder los 255 caracteres.");
        }
    }
}
