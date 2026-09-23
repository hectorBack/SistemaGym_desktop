using Negocio.Exceptions;
using Presentacion.Controller;
using Presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.Roles
{
    public partial class FrmRolModal : Form
    {
        private readonly RolController _controller;
        private readonly int? _rolId;

        public FrmRolModal(RolController controller, int? rolId = null)
        {
            InitializeComponent();
            _controller = controller;
            _rolId = rolId;
        }

        private async void FrmRolModal_Load(object sender, EventArgs e)
        {
            CargarModulosDisponibles();

            if (_rolId.HasValue)
            {
                lblTitulo.Text = "Editar Rol";
                await CargarDatosRolAsync(_rolId.Value);
            }
            else
            {
                lblTitulo.Text = "Nuevo Rol";
            }
        }

        private void CargarModulosDisponibles()
        {
            clbModulos.Items.Clear();

            // Lista de módulos del sistema
            string[] modulos = new string[]
            {
                "Usuarios",
                "Roles",
                "Socios",
                "Membresias",
                "Clases",
                "Productos",
                "Compras",
                "Ventas",
                "Registro",
                "Reportes",
                "Configuracion",
                "Respaldar",
                "Restaurar",
                "Corte de Caja",
                "Eliminar",
                "Conceptos",
                "Movimientos"
            };

            foreach (var modulo in modulos)
            {
                clbModulos.Items.Add(modulo, false);
            }
        }

        private async Task CargarDatosRolAsync(int id)
        {
            try
            {
                var rol = await _controller.ObtenerPorIdAsync(id);
                if (rol != null)
                {
                    txtNombre.Text = rol.Nombre;
                    txtDescripcion.Text = rol.Descripcion;

                    // Marcar los módulos asignados al rol
                    if (rol.ModulosPermitidos != null)
                    {
                        for (int i = 0; i < clbModulos.Items.Count; i++)
                        {
                            string moduloItem = clbModulos.Items[i].ToString()!;
                            if (rol.ModulosPermitidos.Contains(moduloItem))
                            {
                                clbModulos.SetItemChecked(i, true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del rol: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> ObtenerModulosSeleccionados()
        {
            var seleccionados = new List<string>();
            foreach (var item in clbModulos.CheckedItems)
            {
                seleccionados.Add(item.ToString()!);
            }
            return seleccionados;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidationHelper.EsTextoVacio(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre para el rol.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var modulosSeleccionados = ObtenerModulosSeleccionados();
            if (modulosSeleccionados.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un módulo permitido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await _controller.GuardarRolAsync(
                    _rolId,
                    txtNombre.Text.Trim(),
                    txtDescripcion.Text.Trim(),
                    modulosSeleccionados
                );

                MessageBox.Show("Rol guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
