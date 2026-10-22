using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class RestaurarManualValidator : AbstractValidator<RestaurarManualDto>
    {
        public RestaurarManualValidator()
        {
            RuleFor(x => x.RutaArchivo)
                .NotEmpty().WithMessage("Debe seleccionar un archivo de respaldo válido.")
                .Must(File.Exists).WithMessage("El archivo de respaldo seleccionado no existe en la ruta especificada.");
        }
    }
}
