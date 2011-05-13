using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class OrdenCompraIngresoADepositoForm : Cedeira.UI.frmBase
    {
        static string titulo = "Ingreso a Depósito";
        CedForecastEntidades.OrdenCompraInfoIngresoADeposito infoIngresoADeposito = new CedForecastEntidades.OrdenCompraInfoIngresoADeposito();
        List<CedForecastEntidades.OrdenCompra> ordenesCompra;

        public OrdenCompraIngresoADepositoForm(List<CedForecastEntidades.OrdenCompra> OrdenesCompra) : base(titulo)
        {
            InitializeComponent();
            ordenesCompra = OrdenesCompra;
        }
        private void AceptarUiButton_Click(object sender, EventArgs e)
        {
            try
            {
                LlenarCampos();
                CedForecastRN.OrdenCompra.IngresoADeposito(ordenesCompra, infoIngresoADeposito, Aplicacion.Sesion);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
        private void LlenarCampos()
        {
            infoIngresoADeposito.FechaIngresoDeposito = FechaIngresoDepositoCalendarCombo.Value.Date;
        }
    }
}