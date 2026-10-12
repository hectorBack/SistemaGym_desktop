using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Presentacion.Forms.Reportes
{
    public static class GridTemaExtensiones
    {
        private static readonly string[] PalabrasDinero = { "precio", "costo", "total", "subtotal", "monto", "importe", "ingreso", "egreso" };
        private static readonly string[] PalabrasNumero = { "stock", "cantidad", "existencia" };

        public static void FormatoAutomatico(this DataGridView grid)
        {
            grid.DataBindingComplete += (_, _) =>
            {
                foreach (DataGridViewColumn col in grid.Columns)
                {
                    string nombre = col.DataPropertyName.Length > 0 ? col.DataPropertyName : col.Name;
                    string minuscula = nombre.ToLowerInvariant();

                    // "FechaMovimiento" -> "Fecha Movimiento" (solo si el encabezado no se personalizó)
                    if (col.HeaderText == col.Name || col.HeaderText == nombre)
                        col.HeaderText = Regex.Replace(nombre, "(?<=[a-záéíóú])(?=[A-Z])", " ");

                    bool dinero = PalabrasDinero.Any(minuscula.Contains);
                    bool numero = PalabrasNumero.Any(minuscula.Contains)
                                  || minuscula.EndsWith("id")
                                  || minuscula == "id";

                    if (dinero)
                        col.DefaultCellStyle.Format = "C2";

                    if (dinero || numero)
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    if (col.ValueType == typeof(DateTime) || col.ValueType == typeof(DateTime?))
                        col.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
            };
        }
    }
}
