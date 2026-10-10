using Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Helpers
{
    public static class FormHelper
    {
        /// <summary>
        /// Muestra un cuadro de confirmación (Sí/No).
        /// Con destructiva = true usa un icono de advertencia y deja "No" como botón por defecto,
        /// para que un Enter apresurado no borre nada.
        /// </summary>
        public static bool ConfirmarAccion(string mensaje, string titulo = "Confirmación", bool destructiva = false)
        {
            DialogResult resultado = MessageBox.Show(
                mensaje,
                titulo,
                MessageBoxButtons.YesNo,
                destructiva ? MessageBoxIcon.Warning : MessageBoxIcon.Question,
                destructiva ? MessageBoxDefaultButton.Button2 : MessageBoxDefaultButton.Button1);

            return resultado == DialogResult.Yes;
        }

        public static void MostrarAviso(string mensaje, string titulo = "Aviso")
            => MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void MostrarAdvertencia(string mensaje, string titulo = "Atención")
            => MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static void MostrarError(string mensaje, string titulo = "Error del sistema")
            => MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

        /// <summary>
        /// Ejecuta una operación asíncrona con el manejo de errores estándar de la aplicación:
        ///  - Deshabilita los controles indicados mientras corre (evita dobles clics y operaciones simultáneas).
        ///  - BusinessException: muestra su mensaje como advertencia.
        ///  - Cualquier otro error: mensaje genérico (el detalle técnico solo se ve en compilación Debug).
        /// Devuelve true si la operación terminó sin errores.
        /// </summary>
        public static async Task<bool> EjecutarAsync(
            Func<Task> accion,
            string mensajeError,
            params Control[] controlesADeshabilitar)
        {
            var estadoPrevio = controlesADeshabilitar.Select(c => c.Enabled).ToArray();
            var formulario = controlesADeshabilitar.FirstOrDefault()?.FindForm();

            foreach (var control in controlesADeshabilitar)
                control.Enabled = false;

            if (formulario != null)
                formulario.UseWaitCursor = true;

            try
            {
                await accion();
                return true;
            }
            catch (BusinessException ex)
            {
                MostrarAdvertencia(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex); // TODO: registrar en archivo cuando exista logging en la aplicación

                string detalle = string.Empty;
#if DEBUG
                detalle = $"\n\nDetalle técnico: {ex.Message}"; // solo visible mientras desarrollas
#endif
                MostrarError(mensajeError + detalle);
                return false;
            }
            finally
            {
                // Si el formulario ya se cerró mientras esperaba, no se toca nada.
                if (formulario != null && !formulario.IsDisposed)
                    formulario.UseWaitCursor = false;

                for (int i = 0; i < controlesADeshabilitar.Length; i++)
                {
                    if (!controlesADeshabilitar[i].IsDisposed)
                        controlesADeshabilitar[i].Enabled = estadoPrevio[i];
                }
            }
        }
    }
}
