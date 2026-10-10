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

            var relleno = new Padding(8, 0, 8, 0);

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
        /// Se llama una sola vez al construir el formulario (con AutoGenerateColumns = false).
        /// </summary>
        /// <param name="propiedad">Nombre de la propiedad del modelo (usa nameof).</param>
        /// <param name="encabezado">Texto que se muestra arriba de la columna.</param>
        /// <param name="peso">Ancho relativo (FillWeight) respecto a las demás columnas.</param>
        /// <param name="anchoMinimo">Ancho mínimo en píxeles.</param>
        /// <param name="formato">Formato opcional, por ejemplo "C2" o "dd/MM/yyyy".</param>
        /// <param name="alinearDerecha">Para columnas numéricas o de dinero.</param>
        public DataGridViewTextBoxColumn AgregarTexto(
            string propiedad,
            string encabezado,
            float peso,
            int anchoMinimo = 55,
            string? formato = null,
            bool alinearDerecha = false)
        {
            var columna = new DataGridViewTextBoxColumn
            {
                Name = "col" + propiedad,
                DataPropertyName = propiedad,
                HeaderText = encabezado,
                FillWeight = peso,
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

            Columns.Add(columna);
            return columna;
        }
    }
}
