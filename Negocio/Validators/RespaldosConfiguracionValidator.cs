using FluentValidation;
using Negocio.DTOs;

namespace Negocio.Validators
{
    public class RespaldosConfiguracionValidator : AbstractValidator<RespaldosConfiguracionDto>
    {
        public RespaldosConfiguracionValidator()
        {
            RuleFor(x => x.RutaRespaldo)
                .NotEmpty().WithMessage("La ruta de respaldo es obligatoria.")
                .Must(ruta => Directory.Exists(ruta) || Path.IsPathRooted(ruta))
                .WithMessage("Debe proporcionar una ruta de directorio válida para los respaldos.");
        }
    }
}
