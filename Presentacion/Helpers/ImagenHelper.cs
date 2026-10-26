using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Helpers
{
    public static class ImagenHelper
    {
        /// <summary>
        /// Carga la foto de un socio. Acepta una ruta de archivo o una imagen en Base64.
        /// Devuelve null si no hay foto, el archivo ya no existe o la imagen está dañada.
        /// El llamador es responsable de liberar el Bitmap (MostrarEn lo hace por ti).
        /// </summary>
        public static Bitmap? CargarFoto(string? rutaOBase64)
        {
            if (string.IsNullOrWhiteSpace(rutaOBase64))
                return null;

            try
            {
                // Image.FromFile deja el archivo bloqueado mientras la imagen exista;
                // leyendo desde un stream se suelta el archivo de inmediato.
                if (File.Exists(rutaOBase64))
                {
                    using var archivo = new FileStream(rutaOBase64, FileMode.Open, FileAccess.Read, FileShare.Read);
                    using var original = Image.FromStream(archivo);
                    return new Bitmap(original);
                }

                byte[] bytes = Convert.FromBase64String(rutaOBase64);
                using var memoria = new MemoryStream(bytes);
                using var imagen = Image.FromStream(memoria);
                return new Bitmap(imagen);
            }
            catch (Exception ex) when (ex is FormatException or ArgumentException or IOException
                                          or UnauthorizedAccessException or OutOfMemoryException)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return null;
            }
        }

        /// <summary>
        /// Pone la imagen en el PictureBox y libera la anterior.
        /// Con <paramref name="recortarCuadrada"/> la foto se recorta al centro en forma cuadrada para llenar
        /// un PictureBox cuadrado sin franjas a los lados. En ese caso la imagen original se libera aquí:
        /// el llamador no debe seguir usándola después de llamar a este método.
        /// </summary>
        public static void MostrarEn(PictureBox caja, Bitmap? nueva, bool recortarCuadrada = false)
        {
            if (recortarCuadrada && nueva != null)
            {
                var recortada = RecortarCuadrada(nueva);
                if (!ReferenceEquals(recortada, nueva))
                    nueva.Dispose();
                nueva = recortada;
            }

            var anterior = caja.Image;
            caja.Image = nueva;
            anterior?.Dispose();
        }

        /// <summary>
        /// Recorta la imagen al centro para dejarla cuadrada (lado = el menor de ancho y alto).
        /// Si ya es cuadrada devuelve la misma instancia; si no, una copia nueva que el llamador debe liberar.
        /// </summary>
        public static Bitmap RecortarCuadrada(Bitmap origen)
        {
            int lado = Math.Min(origen.Width, origen.Height);
            if (origen.Width == origen.Height)
                return origen;

            var region = new Rectangle((origen.Width - lado) / 2, (origen.Height - lado) / 2, lado, lado);

            var resultado = new Bitmap(lado, lado);
            using var g = Graphics.FromImage(resultado);
            g.DrawImage(origen, new Rectangle(0, 0, lado, lado), region, GraphicsUnit.Pixel);
            return resultado;
        }
    }
}
