using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class CorteCreateValidator : AbstractValidator<CorteCreateDto>
    {
        public CorteCreateValidator()
        {
            RuleFor(x => x.UsuarioID)
                .GreaterThan(0).WithMessage("El usuario es obligatorio.");

            RuleFor(x => x.MontoInicial)
                .GreaterThanOrEqualTo(0m).WithMessage("El monto inicial de caja no puede ser negativo.");

            RuleFor(x => x.Observaciones)
                .MaximumLength(500).WithMessage("Las observaciones no pueden exceder los 500 caracteres.");
        }
    }

    public class CorteUpdateValidator : AbstractValidator<CorteUpdateDto>
    {
        public CorteUpdateValidator()
        {
            RuleFor(x => x.CorteID)
                .GreaterThan(0).WithMessage("ID de corte no válido.");

            RuleFor(x => x.TotalIngresos)
                .GreaterThanOrEqualTo(0m).WithMessage("El total de ingresos no puede ser negativo.");

            RuleFor(x => x.TotalEgresos)
                .GreaterThanOrEqualTo(0m).WithMessage("El total de egresos no puede ser negativo.");

            RuleFor(x => x.MontoFinal)
                .GreaterThanOrEqualTo(0m).WithMessage("El monto final no puede ser negativo.");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("El estado del corte es obligatorio.")
                .Must(e => e == "Abierto" || e == "Cerrado")
                .WithMessage("El estado debe ser 'Abierto' o 'Cerrado'.");

            RuleFor(x => x.Observaciones)
                .MaximumLength(500).WithMessage("Las observaciones no pueden exceder los 500 caracteres.");
        }
    }
}
