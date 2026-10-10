using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Forms
{
    public class ListaOrdenable<T> : BindingList<T>
    {
        private bool _ordenada;
        private PropertyDescriptor? _propiedadOrden;
        private ListSortDirection _direccionOrden;

        public ListaOrdenable() : base()
        {
        }

        public ListaOrdenable(IEnumerable<T> elementos) : base(elementos.ToList())
        {
        }

        protected override bool SupportsSortingCore => true;

        protected override bool IsSortedCore => _ordenada;

        protected override PropertyDescriptor? SortPropertyCore => _propiedadOrden;

        protected override ListSortDirection SortDirectionCore => _direccionOrden;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var lista = (List<T>)Items;

            var ordenados = direction == ListSortDirection.Ascending
                ? lista.OrderBy(x => prop.GetValue(x)).ToList()
                : lista.OrderByDescending(x => prop.GetValue(x)).ToList();

            lista.Clear();
            lista.AddRange(ordenados);

            _propiedadOrden = prop;
            _direccionOrden = direction;
            _ordenada = true;

            ResetBindings();
        }

        protected override void RemoveSortCore()
        {
            _ordenada = false;
            _propiedadOrden = null;
        }
    }
}
