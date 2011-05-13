using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class OrdenCompraInspeccionRENARForm : Cedeira.UI.frmBase
    {
        static string titulo = "Ingreso Info Embarque";
        CedForecastEntidades.OrdenCompraInfoInspeccionRENAR infoInspeccionRENAR = new CedForecastEntidades.OrdenCompraInfoInspeccionRENAR();
        List<CedForecastEntidades.OrdenCompra> ordenesCompra;

        public OrdenCompraInspeccionRENARForm(List<CedForecastEntidades.OrdenCompra> OrdenesCompra) : base(titulo)
        {
            InitializeComponent();
            ordenesCompra = OrdenesCompra;
        }
        private void AceptarUiButton_Click(object sender, EventArgs e)
        {
            try
            {
                LlenarCampos();
                CedForecastRN.OrdenCompra.InspeccionRENAR(ordenesCompra, infoInspeccionRENAR, Aplicacion.Sesion);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
        private void LlenarCampos()
        {
            infoInspeccionRENAR.FechaInspeccionRENAR = FechaInspeccionRENARCalendarCombo.Value.Date;
        }
    }
}