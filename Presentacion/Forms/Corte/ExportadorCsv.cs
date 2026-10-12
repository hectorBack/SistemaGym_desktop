using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Forms.Corte
{
    public static class ExportadorCsv
    {
        /// <summary>Devuelve la ruta guardada, o null si el usuario canceló.</summary>
        public static string? Exportar(DataGridView grid, string nombreSugerido)
        {
            using var dialogo = new SaveFileDialog
            {
                Title = "Exportar a Excel (CSV)",
                Filter = "CSV para Excel (*.csv)|*.csv",
                FileName = $"{nombreSugerido}_{DateTime.Now:yyyyMMdd_HHmm}.csv",
                OverwritePrompt = true
            };

            if (dialogo.ShowDialog() != DialogResult.OK)
                return null;

            var columnas = grid.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .OrderBy(c => c.DisplayIndex)
                .ToList();

            var csv = new StringBuilder();
            csv.AppendLine(string.Join(",", columnas.Select(c => Escapar(c.HeaderText))));

            foreach (DataGridViewRow fila in grid.Rows)
            {
                csv.AppendLine(string.Join(",", columnas.Select(c =>
                    Escapar(Convert.ToString(fila.Cells[c.Index].FormattedValue) ?? string.Empty))));
            }

            File.WriteAllText(dialogo.FileName, csv.ToString(), new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));
            return dialogo.FileName;
        }

        private static string Escapar(string valor)
        {
            // Un texto que empieza con = + @ lo interpretaría Excel como fórmula (por ejemplo, una
            // observación escrita por un usuario): se antepone una comilla para que se quede como texto.
            if (valor.Length > 0 && "=+@".Contains(valor[0]))
                valor = "'" + valor;

            if (valor.IndexOfAny(new[] { ',', '"', '\n', '\r' }) >= 0)
                valor = "\"" + valor.Replace("\"", "\"\"") + "\"";

            return valor;
        }
    }
}
