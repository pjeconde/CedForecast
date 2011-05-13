using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class OrdenCompraIngresoInfoEmbarqueForm : Cedeira.UI.frmBase
    {
        static string titulo = "Ingreso Info Embarque";
        CedForecastEntidades.OrdenCompraInfoEmbarque infoEmbarque = new CedForecastEntidades.OrdenCompraInfoEmbarque();
        List<CedForecastEntidades.OrdenCompra> ordenesCompra;

        public OrdenCompraIngresoInfoEmbarqueForm(List<CedForecastEntidades.OrdenCompra> OrdenesCompra) : base(titulo)
        {
            InitializeComponent();
            ordenesCompra = OrdenesCompra;
        }

        private void AceptarUiButton_Click(object sender, EventArgs e)
        {
            try
            {
                LlenarCampos();
                CedForecastRN.OrdenCompra.IngresoInfoEmbarque(ordenesCompra, infoEmbarque, Aplicacion.Sesion);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
        private void LlenarCampos()
        {
            infoEmbarque.IdReferenciaSAP = IdReferenciaSAPEditBox.Text;
            infoEmbarque.FechaEstimadaSalida = FechaEstimadaSalidaCalendarCombo.Value.Date;
            infoEmbarque.Vapor = VaporEditBox.Text;
            infoEmbarque.FechaEstimadaArribo = FechaEstimadaArriboCalendarCombo.Value.Date;
        }
    }
}