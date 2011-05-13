using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class OrdenCompraRegistroDespachoForm : Cedeira.UI.frmBase
    {
        static string titulo = "Registro de Despacho";
        CedForecastEntidades.OrdenCompraInfoRegistroDespacho infoRegistroDespacho = new CedForecastEntidades.OrdenCompraInfoRegistroDespacho();
        List<CedForecastEntidades.OrdenCompra> ordenesCompra;

        public OrdenCompraRegistroDespachoForm(List<CedForecastEntidades.OrdenCompra> OrdenesCompra) : base(titulo)
        {
            InitializeComponent();
            ordenesCompra = OrdenesCompra;
        }
        private void AceptarUiButton_Click(object sender, EventArgs e)
        {
            try
            {
                LlenarCampos();
                CedForecastRN.OrdenCompra.RegistroDespacho(ordenesCompra, infoRegistroDespacho, Aplicacion.Sesion);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
        private void LlenarCampos()
        {
            infoRegistroDespacho.FechaIngresoAPuerto = FechaIngresoAPuertoCalendarCombo.Value.Date;
            infoRegistroDespacho.NroDespacho = NroDespachoEditBox.Text;
            infoRegistroDespacho.FechaOficializacion = FechaOficializacionCalendarCombo.Value.Date;
        }
    }
}