using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Helpers
{
    public static class FormHelper
    {
        /// <summary>
        /// Muestra un cuadro de diálogo de confirmación (Sí/No).
        /// </summary>
        public static bool ConfirmarAccion(string mensaje, string titulo = "Confirmación")
        {
            DialogResult result = MessageBox.Show(
                mensaje,
                titulo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            return result == DialogResult.Yes;
        }
    }
}
