using Datos.Interfaces;
using Negocio.Exceptions;
using Negocio.Helpers;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class TicketService : ITicketService
    {
        private readonly IConfiguracionService _configuracionService;
        private readonly IVentaService _ventaService;
        private readonly IUnitOfWork _unitOfWork;

        public TicketService(
            IConfiguracionService configuracionService,
            IVentaService ventaService,
            IUnitOfWork unitOfWork)
        {
            _configuracionService = configuracionService;
            _ventaService = ventaService;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ImprimirTicketVentaAsync(int ventaId)
        {
            var config = await _configuracionService.ObtenerConfigTicketAsync();
            if (!config.HabilitarImpresora)
            {
                return false;
            }

            var venta = await _ventaService.ObtenerPorIdAsync(ventaId);
            if (venta == null)
            {
                throw new BusinessException("La venta que intenta imprimir no existe.");
            }

            var gimnasio = await ObtenerGimnasioAsync();

            // El nombre del cajero viene en la venta; si no, se busca por ID.
            string nombreUsuario = venta.UsuarioNombre ?? string.Empty;
            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                var usuario = await _unitOfWork.Usuarios.ObtenerPorIdAsync(venta.UsuarioID);
                nombreUsuario = string.IsNullOrWhiteSpace(usuario?.NombreCompleto) ? "N/A" : usuario!.NombreCompleto;
            }

            // El cliente es el socio de la venta (null si fue una venta casual).
            string? cliente = venta.SocioNombre;
            if (string.IsNullOrWhiteSpace(cliente) && venta.SocioID.HasValue)
            {
                var socio = await _unitOfWork.Socio.ObtenerPorIdAsync(venta.SocioID.Value);
                cliente = socio?.Nombre;
            }

            var ticket = new TicketVenta(
                Folio: $"V-{venta.VentaID:D6}",
                Fecha: venta.FechaVenta,
                Usuario: nombreUsuario,
                Cliente: cliente,
                FormaPago: string.IsNullOrWhiteSpace(venta.FormaPago) ? "Efectivo" : venta.FormaPago,
                Lineas: venta.Detalles
                    .Select(d => new TicketVentaLinea(d.ProductoNombre, d.Cantidad, d.PrecioUnitario, d.Subtotal))
                    .ToList(),
                Total: venta.Total);

            // La impresión bloquea hasta que el spooler recibe el trabajo: se hace fuera del hilo de la pantalla.
            await Task.Run(() => TicketImpresionHelper.ImprimirVenta(config, gimnasio, ticket));

            return true;
        }

        public async Task<bool> ImprimirTicketPagoMembresiaAsync(int pagoId)
        {
            var config = await _configuracionService.ObtenerConfigTicketAsync();
            if (!config.HabilitarImpresora)
            {
                return false;
            }

            var pago = await _unitOfWork.PagoSocioMembresia.ObtenerPorIdAsync(pagoId);
            if (pago == null)
            {
                throw new BusinessException("El pago que intenta imprimir no existe.");
            }

            var socioMembresia = await _unitOfWork.SocioMembresia.ObtenerPorIdAsync(pago.SocioMembresiaID);
            if (socioMembresia == null)
            {
                throw new BusinessException("La membresía del socio de este pago no existe.");
            }

            var socio = await _unitOfWork.Socio.ObtenerPorIdAsync(socioMembresia.SocioID);
            var usuario = pago.UsuarioID.HasValue ? await _unitOfWork.Usuarios.ObtenerPorIdAsync(pago.UsuarioID.Value) : null;

            decimal precio = socioMembresia.Membresia?.Precio ?? 0m;
            decimal totalPagado = await _unitOfWork.PagoSocioMembresia.ObtenerTotalPagadoPorSocioMembresiaIdAsync(pago.SocioMembresiaID);
            decimal saldo = Math.Max(0, precio - totalPagado);

            var comprobante = new PagoCorreo(
                ClaveSocio: socio?.Clave ?? string.Empty,
                NombreSocio: socio?.Nombre ?? "N/A",
                Membresia: socioMembresia.Membresia?.Nombre ?? "Membresía",
                FechaInicio: socioMembresia.FechaInicio,
                FechaVencimiento: socioMembresia.FechaFin,
                Precio: precio,
                TotalPagado: totalPagado,
                EstadoPago: saldo == 0 ? "Pagada" : $"Parcial (saldo {saldo:C2})",
                Monto: pago.Monto,
                FormaPago: pago.FormaPago,
                Folio: pago.Folio,
                Observacion: pago.Observacion,
                Usuario: string.IsNullOrWhiteSpace(usuario?.NombreCompleto) ? "N/A" : usuario!.NombreCompleto,
                Fecha: pago.CreatedAt is DateTime fechaPago ? fechaPago : DateTime.Now);

            var gimnasio = await ObtenerGimnasioAsync();

            await Task.Run(() => TicketImpresionHelper.ImprimirPago(config, gimnasio, comprobante));

            return true;
        }

        // Encabezado del ticket: datos y logo del gimnasio guardados en la configuración.
        private async Task<ComprobanteGimnasio> ObtenerGimnasioAsync()
        {
            var datos = await _configuracionService.ObtenerConfigGimnasioAsync();

            return new ComprobanteGimnasio(
                string.IsNullOrWhiteSpace(datos.Nombre) ? "Gimnasio" : datos.Nombre,
                datos.Domicilio,
                datos.Telefono,
                datos.Rfc,
                datos.Mensaje,
                LogoGimnasioHelper.CargarBytes(datos.Logo));
        }
    }
}
