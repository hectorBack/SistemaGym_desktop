using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class VentaCreateValidator : AbstractValidator<VentaCreateDto>
    {
        public VentaCreateValidator()
        {
            RuleFor(x => x.UsuarioID)
                .GreaterThan(0).WithMessage("Debe especificar un usuario válido para registrar la venta.");

            RuleFor(x => x.SocioID)
                .GreaterThan(0).When(x => x.SocioID.HasValue)
                .WithMessage("El ID del socio no es válido.");

            RuleFor(x => x.Total)
                .GreaterThan(0).WithMessage("El total de la venta debe ser mayor a cero.");

            RuleFor(x => x.Detalles)
                .NotNull().WithMessage("La venta debe contener una lista de productos.")
                .Must(d => d != null && d.Count > 0).WithMessage("Debe incluir al menos un producto en la venta.");

            // Aplica el validador secundario a cada elemento de la lista de detalles
            RuleForEach(x => x.Detalles).SetValidator(new DetalleVentaCreateValidator());
        }
    }

    public class DetalleVentaCreateValidator : AbstractValidator<DetalleVentaCreateDto>
    {
        public DetalleVentaCreateValidator()
        {
            RuleFor(x => x.ProductoID)
                .GreaterThan(0).WithMessage("Debe seleccionar un producto válido.");

            RuleFor(x => x.Cantidad)
                .GreaterThan(0).WithMessage("La cantidad vendida debe ser mayor a cero.");

            RuleFor(x => x.PrecioUnitario)
                .GreaterThan(0).WithMessage("El precio unitario del producto debe ser mayor a cero.");
        }
    }
}
