using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Forms
{
    public class BotonTema : Button
    {
        private static readonly Font FuenteBoton = new("Segoe UI Semibold", 9F, FontStyle.Bold);

        private EstiloBoton _estilo = EstiloBoton.Secundario;

        public BotonTema()
        {
            FlatStyle = FlatStyle.Flat;
            Cursor = Cursors.Hand;
            Font = FuenteBoton;
            Size = new Size(110, 38);
            UseVisualStyleBackColor = false;
            AplicarEstilo();
        }

        [Category("Appearance")]
        [DefaultValue(EstiloBoton.Secundario)]
        [Description("Estilo visual del botón según la paleta de la aplicación.")]
        public EstiloBoton Estilo
        {
            get => _estilo;
            set
            {
                if (_estilo == value) return;
                _estilo = value;
                AplicarEstilo();
            }
        }

        private void AplicarEstilo()
        {
            var (fondo, texto, borde, hover, presionado) = _estilo switch
            {
                EstiloBoton.Primario => (Tema.Primario, Color.White, Tema.Primario, Tema.PrimarioHover, Tema.PrimarioPresionado),
                EstiloBoton.Advertencia => (Tema.Fondo, Tema.Advertencia, Tema.Advertencia, Tema.AdvertenciaFondo, Tema.AdvertenciaFondo),
                EstiloBoton.Peligro => (Tema.Fondo, Tema.Peligro, Tema.Peligro, Tema.PeligroFondo, Tema.PeligroFondo),
                EstiloBoton.Exito => (Tema.Fondo, Tema.Exito, Tema.Exito, Tema.ExitoFondo, Tema.ExitoFondo),
                _ => (Tema.Fondo, Tema.Texto, Tema.Primario, Tema.AzulHover, Tema.AzulPresionado)
            };

            BackColor = fondo;
            ForeColor = texto;
            FlatAppearance.BorderSize = 1;
            FlatAppearance.BorderColor = borde;
            FlatAppearance.MouseOverBackColor = hover;
            FlatAppearance.MouseDownBackColor = presionado;
        }
    }
}
