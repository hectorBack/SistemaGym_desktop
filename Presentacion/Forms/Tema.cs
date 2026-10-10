using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Forms
{
    public static class Tema
    {
        // Fondos
        public static readonly Color Fondo = ColorTranslator.FromHtml("#0b0f1a");
        public static readonly Color AzulBase = ColorTranslator.FromHtml("#0f2a4f");
        public static readonly Color AzulHover = ColorTranslator.FromHtml("#173a69");
        public static readonly Color AzulPresionado = ColorTranslator.FromHtml("#123058");
        public static readonly Color FilaAlterna = ColorTranslator.FromHtml("#0e1424");

        // Texto
        public static readonly Color Texto = ColorTranslator.FromHtml("#e6eefc");
        public static readonly Color TextoAtenuado = ColorTranslator.FromHtml("#7c8aa5");
        public static readonly Color Acento = ColorTranslator.FromHtml("#2dd4ff");

        // Acciones
        public static readonly Color Primario = ColorTranslator.FromHtml("#1f6feb");
        public static readonly Color PrimarioHover = ColorTranslator.FromHtml("#388bfd");
        public static readonly Color PrimarioPresionado = ColorTranslator.FromHtml("#1a5fcf");

        public static readonly Color Exito = ColorTranslator.FromHtml("#34d399");
        public static readonly Color ExitoFondo = ColorTranslator.FromHtml("#0f2e24");

        public static readonly Color Advertencia = ColorTranslator.FromHtml("#f5b53d");
        public static readonly Color AdvertenciaFondo = ColorTranslator.FromHtml("#3a2c0c");

        public static readonly Color Peligro = ColorTranslator.FromHtml("#f87171");
        public static readonly Color PeligroFondo = ColorTranslator.FromHtml("#3b1219");
    }
}
