using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Forms
{
    public class GridTema : DataGridView
    {
        public GridTema()
        {
            DoubleBuffered = true; // menos parpadeo al hacer scroll

            // Comportamiento
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            ReadOnly = true;
            MultiSelect = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RowHeadersVisible = false;

            // Volvemos a Fill para que la tabla luzca limpia y completa a lo ancho del contenedor,
            // controlando el espacio mediante los pesos (FillWeight) de cada columna.
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Aspecto general
            BorderStyle = BorderStyle.None;
            BackgroundColor = Tema.Fondo;
            GridColor = Tema.AzulBase;
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            EnableHeadersVisualStyles = false;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ColumnHeadersHeight = 38;
            RowTemplate.Height = 32;

            var relleno = new Padding(12, 0, 12, 0); // Un poco más de espacio interno para mayor elegancia

            // Encabezados
            var encabezado = ColumnHeadersDefaultCellStyle;
            encabezado.BackColor = Tema.AzulBase;
            encabezado.ForeColor = Tema.Acento;
            encabezado.SelectionBackColor = Tema.AzulBase;
            encabezado.SelectionForeColor = Tema.Acento;
            encabezado.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            encabezado.Alignment = DataGridViewContentAlignment.MiddleLeft;
            encabezado.Padding = relleno;

            // Celdas
            var celda = DefaultCellStyle;
            celda.BackColor = Tema.Fondo;
            celda.ForeColor = Tema.Texto;
            celda.SelectionBackColor = Tema.Primario;
            celda.SelectionForeColor = Color.White;
            celda.Alignment = DataGridViewContentAlignment.MiddleLeft;
            celda.Padding = relleno;

            AlternatingRowsDefaultCellStyle.BackColor = Tema.FilaAlterna;
        }

        /// <summary>
        /// Agrega una columna de texto enlazada a una propiedad del modelo.
        /// </summary>
        /// <param name="propiedad">Nombre de la propiedad del modelo.</param>
        /// <param name="encabezado">Texto del encabezado.</param>
        /// <param name="peso">Proporción de ancho relativa (FillWeight).</param>
        /// <param name="anchoMinimo">Ancho mínimo en píxeles.</param>
        /// <param name="formato">Formato opcional (ej. "C2", "dd/MM/yyyy HH:mm").</param>
        /// <param name="alinearDerecha">Alineación a la derecha para valores numéricos.</param>
        public DataGridViewTextBoxColumn AgregarTexto(
            string propiedad,
            string encabezado,
            float peso = 100f,
            int anchoMinimo = 60,
            string? formato = null,
            bool alinearDerecha = false)
        {
            var columna = new DataGridViewTextBoxColumn
            {
                Name = "col" + propiedad,
                DataPropertyName = propiedad,
                HeaderText = encabezado,
                FillWeight = peso, // Controla qué tan ancha es una columna en proporción a las demás
                MinimumWidth = anchoMinimo,
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            if (formato != null)
                columna.DefaultCellStyle.Format = formato;

            if (alinearDerecha)
            {
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else
            {
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            Columns.Add(columna);
            return columna;
        }
    }
}
