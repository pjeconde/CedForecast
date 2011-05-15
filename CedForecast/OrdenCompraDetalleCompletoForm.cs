using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class OrdenCompraDetalleCompletoForm : Cedeira.UI.frmBase
    {
        public OrdenCompraDetalleCompletoForm(string Evento, CedForecastEntidades.OrdenCompra OrdenCompra) : base(TituloForm(Evento, OrdenCompra))
        {
            InitializeComponent();
        }
        private static string TituloForm(string Evento, CedForecastEntidades.OrdenCompra OrdenCompra)
        {
            if (OrdenCompra.IdItem != "0")
            {
                return Evento + " del Item " + OrdenCompra.IdItem.ToString() + " de la Orden de Compra Nº " + OrdenCompra.Id.ToString();
            }
            else
            {
                return Evento + " de la Orden de Compra Nº " + OrdenCompra.Id.ToString();
            }
        }
    }
}