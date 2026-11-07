using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class TicketConfiguracionValidator : AbstractValidator<TicketConfiguracionDto>
    {
        public TicketConfiguracionValidator()
        {
            RuleFor(x => x.TextoInferior)
                .MaximumLength(300).WithMessage("El texto inferior no puede exceder 300 caracteres.");

            RuleFor(x => x.AnchoTicket)
                .InclusiveBetween(40, 120).WithMessage("El ancho del ticket debe estar entre 40 y 120 mm.");

            RuleFor(x => x.AnchoImagenPorcentaje)
                .InclusiveBetween(10, 100).WithMessage("El ancho de la imagen debe estar entre 10% y 100%.");

            RuleFor(x => x.NombreFuente)
                .NotEmpty().WithMessage("El nombre de la fuente es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre de la fuente no puede exceder 50 caracteres.");

            RuleFor(x => x.TamanoTexto)
                .InclusiveBetween(6, 20).WithMessage("El tamaño del texto debe estar entre 6 y 20.");

            RuleFor(x => x.TamanoRenglon)
                .InclusiveBetween(6, 40).WithMessage("El tamaño del renglón debe estar entre 6 y 40.")
                .GreaterThanOrEqualTo(x => x.TamanoTexto)
                .WithMessage("El tamaño del renglón no puede ser menor que el tamaño del texto.");

            RuleFor(x => x.TamanoTextoEncabezado)
                .InclusiveBetween(6, 30).WithMessage("El tamaño del texto del encabezado debe estar entre 6 y 30.");

            RuleFor(x => x.TamanoRenglonEncabezado)
                .InclusiveBetween(6, 50).WithMessage("El tamaño del renglón del encabezado debe estar entre 6 y 50.")
                .GreaterThanOrEqualTo(x => x.TamanoTextoEncabezado)
                .WithMessage("El tamaño del renglón del encabezado no puede ser menor que el tamaño del texto del encabezado.");

            RuleFor(x => x.TamanoEntreSecciones)
                .InclusiveBetween(0, 40).WithMessage("El espacio entre secciones debe estar entre 0 y 40.");
        }
    }
}
