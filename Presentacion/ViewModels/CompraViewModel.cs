using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class CompraViewModel
    {
        public int CompraID { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public string Estado { get; set; } = "Completada"; 
        public string? Observacion { get; set; }
        public int UsuarioID { get; set; }
        public string UsuarioNombre { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public DateTime? CreatedAt { get; set; }

        // Propiedades calculadas para visualización en DataGridView / UI
        public string EstadoTexto => Activo ? Estado : "Inactivo";
        public string TotalTexto => Total.ToString("C2");
        public string FechaTexto => CreatedAt.HasValue ? CreatedAt.Value.ToString("dd/MM/yyyy HH:mm") : "-";

        // Lista de detalles asociada
        public List<DetalleCompraViewModel> Detalles { get; set; } = new List<DetalleCompraViewModel>();
    }
}
