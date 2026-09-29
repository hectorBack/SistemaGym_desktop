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
        protected override void WndProc(ref Message m)
        {
            // Intercepta el mensaje TCM_ADJUSTRECT para expandir las páginas sobre el borde blanco nativo
            if (m.Msg == 0x1328 && !DesignMode)
            {
                object rectObj = m.GetLParam(typeof(Rectangle));
                if (rectObj != null)
                {
                    Rectangle rect = (Rectangle)rectObj;
                    rect.X -= 5;
                    rect.Y -= 5;
                    rect.Width += 10;
                    rect.Height += 10;
                    System.Runtime.InteropServices.Marshal.StructureToPtr(rect, m.LParam, true);
                }
            }
            base.WndProc(ref m);
        }
    }
}
