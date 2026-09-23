using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class CategoriaCreateValidator : AbstractValidator<CategoriaCreateDto>
    {
        public CategoriaCreateValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre de la categoría es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");
        }
    }

    public class CategoriaUpdateValidator : AbstractValidator<CategoriaUpdateDto>
    {
        public CategoriaUpdateValidator()
        {
            RuleFor(x => x.CategoriaID)
                .GreaterThan(0).WithMessage("ID de categoría no válido.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre de la categoría es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");
        }
    }
}
