using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class ProductoCreateValidator : AbstractValidator<ProductoCreateDto>
    {
        public ProductoCreateValidator()
        {
            RuleFor(x => x.CategoriaID)
                .GreaterThan(0).WithMessage("Debe seleccionar una categoría válida.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.Precio)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a cero.");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");

            RuleFor(x => x.CodigoBarras)
                .MaximumLength(50).WithMessage("El código de barras no puede exceder los 50 caracteres.");
        }
    }

    public class ProductoUpdateValidator : AbstractValidator<ProductoUpdateDto>
    {
        public ProductoUpdateValidator()
        {
            RuleFor(x => x.ProductoID)
                .GreaterThan(0).WithMessage("ID de producto no válido.");

            RuleFor(x => x.CategoriaID)
                .GreaterThan(0).WithMessage("Debe seleccionar una categoría válida.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.Precio)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a cero.");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");

            RuleFor(x => x.CodigoBarras)
                .MaximumLength(50).WithMessage("El código de barras no puede exceder los 50 caracteres.");
        }
    }
}
