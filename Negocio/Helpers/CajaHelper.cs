using Datos.Entities;
using Datos.Interfaces;
using System.Globalization;

namespace Presentacion.Helpers
{
    public static class CajaConstantes
    {
        // IDs de la tabla Concepto. Si en tu base de datos son otros, se cambian SOLO aquí.
        public const int ConceptoVenta = 1;                    // Ingreso
        public const int ConceptoCompra = 2;                   // Egreso
        public const int ConceptoPagoMembresia = 3;            // Ingreso
        public const int ConceptoCancelacionPagoMembresia = 4; // Egreso
        public const int ConceptoCancelacionVenta = 5;         // Egreso
        public const int ConceptoCancelacionCompra = 6;        // Ingreso
        public const int ConceptoVisita = 7;                   // Ingreso
        public const int ConceptoCancelacionVisita = 8;        // Egreso

        public const string TipoIngreso = "Ingreso";
        public const string TipoEgreso = "Egreso";
        public const string FormaPagoEfectivo = "Efectivo";

        public const string EstadoAbierto = "Abierto";
        public const string EstadoCerrado = "Cerrado";

        // Clave de la tabla Configuracion con el fondo de caja (la misma que guarda ConfiguracionService).
        public const string ClaveEfectivoInicial = "Corte_EfectivoInicial";

        public static bool EsEfectivo(string? formaPago) =>
            string.Equals(formaPago?.Trim(), FormaPagoEfectivo, StringComparison.OrdinalIgnoreCase);

        public static bool EsIngreso(Movimiento m) =>
            string.Equals(m.Tipo?.Trim(), TipoIngreso, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Operaciones de caja compartidas por Ventas, Compras, Pagos de membresía, Visitas y Movimientos.
    /// Los cobros y pagos NUNCA abren un corte: usan el corte abierto del usuario si existe y, si no, el movimiento
    /// queda sin corte y se enlaza al cerrar el siguiente corte (CorteService.CerrarCorteAsync).
    /// NO guarda cambios: quien la usa llama a SaveChangesAsync UNA sola vez al final, para que el
    /// documento (venta, compra, pago...), su movimiento de caja y el corte recién abierto se confirmen juntos.
    /// </summary>
    public class CajaHelper
    {
        private readonly IUnitOfWork _unitOfWork;

        public CajaHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>Fondo de caja configurado (lo que se deja en caja después de cada corte).</summary>
        public async Task<decimal> ObtenerFondoConfiguradoAsync()
        {
            var config = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CajaConstantes.ClaveEfectivoInicial);

            // El monto se guarda siempre con punto decimal, sin depender de la región del equipo.
            return config != null &&
                   decimal.TryParse(config.Valor, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal fondo)
                ? fondo
                : 0m;
        }

        /// <summary>
        /// Registra el movimiento financiero de una operación (sin guardar). Si el usuario tiene un corte abierto
        /// lo usa; si no, el movimiento queda sin corte (CorteID vacío). NUNCA abre un corte.
        /// </summary>
        public async Task<Movimiento> RegistrarMovimientoAsync(
            int usuarioId, int conceptoId, string tipo, decimal total, string? observacion, string? formaPago = null)
        {
            var corteAbierto = await _unitOfWork.Corte.ObtenerCorteAbiertoPorUsuarioAsync(usuarioId);
            return await AgregarMovimientoAsync(corteAbierto, usuarioId, conceptoId, tipo, total, observacion, formaPago);
        }

        /// <summary>
        /// Devuelve el corte abierto del usuario o PREPARA uno nuevo con el fondo configurado (sin guardarlo todavía).
        /// Ya no lo usan los cobros: se conserva solo por compatibilidad.
        /// </summary>
        /// <param name="motivo">Texto para la observación, por ejemplo "venta de productos".</param>
        [Obsolete("Los cobros ya no abren cortes: use RegistrarMovimientoAsync.")]
        public async Task<Corte> ObtenerOAbrirCorteAsync(int usuarioId, string motivo)
        {
            var corteAbierto = await _unitOfWork.Corte.ObtenerCorteAbiertoPorUsuarioAsync(usuarioId);
            if (corteAbierto != null)
                return corteAbierto;

            decimal fondo = await ObtenerFondoConfiguradoAsync();

            var nuevo = new Corte
            {
                UsuarioID = usuarioId,
                FechaApertura = DateTime.Now,
                MontoInicial = fondo,
                TotalIngresos = 0m,
                TotalEgresos = 0m,
                MontoFinal = fondo,
                Observaciones = $"Apertura automática iniciada por {motivo}",
                Estado = CajaConstantes.EstadoAbierto,
                Activo = true
            };

            await _unitOfWork.Corte.AgregarAsync(nuevo);
            return nuevo;
        }

        /// <summary>Agrega un movimiento de caja al corte indicado, o sin corte si es null (sin guardar).</summary>
        public async Task<Movimiento> AgregarMovimientoAsync(
            Corte? corte, int usuarioId, int conceptoId, string tipo, decimal total, string? observacion, string? formaPago = null)
        {
            var movimiento = new Movimiento
            {
                UsuarioID = usuarioId,
                ConceptoID = conceptoId,
                Tipo = tipo,
                FormaPago = string.IsNullOrWhiteSpace(formaPago) ? CajaConstantes.FormaPagoEfectivo : formaPago.Trim(),
                Total = total,
                Observacion = observacion?.Trim(),
                Activo = true
            };

            // Corte existente: se usa su ID. Corte recién creado (aún sin ID): se enlaza por navegación
            // y EF asigna el ID al guardar.
            if (corte != null)
            {
                if (corte.CorteID != 0) movimiento.CorteID = corte.CorteID;
                else movimiento.Corte = corte;
            }

            await _unitOfWork.Movimiento.AgregarAsync(movimiento);
            return movimiento;
        }
    }
}
