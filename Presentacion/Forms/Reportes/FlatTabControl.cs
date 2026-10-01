using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.Forms.Reportes
{
    public class FlatTabControl : TabControl
    {
        public FlatTabControl()
        {
            // Activar el dibujado personalizado total sin parpadeos
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            DrawMode = TabDrawMode.OwnerDrawFixed;
            SizeMode = TabSizeMode.Normal;
            Padding = new Point(16, 6);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 1. Fondo completo del control (elimina la barra blanca y bordes)
            using (SolidBrush bgBrush = new SolidBrush(ColorTranslator.FromHtml("#0b0f1a")))
            {
                e.Graphics.FillRectangle(bgBrush, ClientRectangle);
            }

            // Si no hay pestañas, terminar aquí
            if (TabCount == 0) return;

            // 2. Dibujar individualmente cada pestaña
            for (int i = 0; i < TabCount; i++)
            {
                TabPage page = TabPages[i];
                Rectangle tabRect = GetTabRect(i);
                bool isSelected = (SelectedIndex == i);

                // Colores por estado (Activa: #0f2a4f | Inactiva: #161b26)
                Color backColor = isSelected ? ColorTranslator.FromHtml("#0f2a4f") : ColorTranslator.FromHtml("#161b26");
                Color textColor = isSelected ? ColorTranslator.FromHtml("#2dd4ff") : Color.White;

                // Rectángulo interno para dejar 2px de margen/separación entre pestañas
                Rectangle innerRect = new Rectangle(tabRect.X + 2, tabRect.Y + 2, tabRect.Width - 4, tabRect.Height - 2);

                // Fondo de la pestaña
                using (SolidBrush tabBrush = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(tabBrush, innerRect);
                }

                // Texto de la pestaña centrado
                TextRenderer.DrawText(
                    e.Graphics,
                    page.Text,
                    Font,
                    innerRect,
                    textColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );
            }
        }
    }
}
