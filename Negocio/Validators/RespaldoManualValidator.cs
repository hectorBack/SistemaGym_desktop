using FluentValidation;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validators
{
    public class RespaldoManualValidator : AbstractValidator<RespaldoManualDto>
    {
        public RespaldoManualValidator()
        {
            RuleFor(x => x.RutaDestino)
                .NotEmpty().WithMessage("Debe seleccionar una carpeta de destino para el respaldo.")
                .Must(ruta => Directory.Exists(ruta))
                .WithMessage("La carpeta de destino seleccionada no existe o no es válida.");
        }
    }
}
