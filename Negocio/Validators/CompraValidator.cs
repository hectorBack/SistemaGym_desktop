using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class CompraCreateValidator : AbstractValidator<CompraCreateDto>
    {
        public CompraCreateValidator()
        {
            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("El código o folio de la compra es obligatorio.")
                .MaximumLength(50).WithMessage("El código no puede exceder los 50 caracteres.");

            RuleFor(x => x.UsuarioID)
                .GreaterThan(0).WithMessage("El usuario que realiza la compra debe ser válido.");

            RuleFor(x => x.FormaPago)
                .NotEmpty().WithMessage("La forma de pago es obligatoria.")
                .MaximumLength(30).WithMessage("La forma de pago no puede exceder los 30 caracteres.");

            RuleFor(x => x.Observacion)
                .MaximumLength(255).WithMessage("La observación no puede exceder los 255 caracteres.");

            RuleFor(x => x.Detalles)
                .NotEmpty().WithMessage("La compra debe contener al menos un producto.")
                .Must(d => d != null && d.Count > 0).WithMessage("Debe agregar al menos un ítem a la lista de compras.");

            // Valida cada elemento individual dentro de la lista de detalles
            RuleForEach(x => x.Detalles).SetValidator(new DetalleCompraCreateValidator());
        }
    }

    // Validador para cada ítem del detalle de la Compra
    public class DetalleCompraCreateValidator : AbstractValidator<DetalleCompraCreateDto>
    {
        public DetalleCompraCreateValidator()
        {
            RuleFor(x => x.ProductoID)
                .GreaterThan(0).WithMessage("Debe seleccionar un producto válido.");

            RuleFor(x => x.Cantidad)
                .GreaterThan(0).WithMessage("La cantidad a comprar debe ser mayor a 0.");

            RuleFor(x => x.CostoUnitario)
                .GreaterThanOrEqualTo(0).WithMessage("El costo unitario del producto no puede ser negativo.");
        }
    }

    // Validador para la actualización / cancelación de una Compra
    public class CompraUpdateValidator : AbstractValidator<CompraUpdateDto>
    {
        public CompraUpdateValidator()
        {
            RuleFor(x => x.CompraID)
                .GreaterThan(0).WithMessage("ID de compra no válido.");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("El estado de la compra es obligatorio.")
                .MaximumLength(20).WithMessage("El estado no puede exceder los 20 caracteres.");

            RuleFor(x => x.Observacion)
                .MaximumLength(255).WithMessage("La observación no puede exceder los 255 caracteres.");
        }
    }
}
