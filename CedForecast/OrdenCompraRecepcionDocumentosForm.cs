using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class OrdenCompraRecepcionDocumentosForm : Cedeira.UI.frmBase
    {
        static string titulo = "Recepción de Documentos";
        CedForecastEntidades.OrdenCompraInfoRecepcionDocumentos infoRecepcionDocumentos = new CedForecastEntidades.OrdenCompraInfoRecepcionDocumentos();
        List<CedForecastEntidades.OrdenCompra> ordenesCompra;

        public OrdenCompraRecepcionDocumentosForm(List<CedForecastEntidades.OrdenCompra> OrdenesCompra) : base(titulo)
        {
            InitializeComponent();
            ordenesCompra = OrdenesCompra;
        }
        private void AceptarUiButton_Click(object sender, EventArgs e)
        {
            try
            {
                LlenarCampos();
                CedForecastRN.OrdenCompra.RecepcionDocumentos(ordenesCompra, infoRecepcionDocumentos, Aplicacion.Sesion);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
        private void LlenarCampos()
        {
            infoRecepcionDocumentos.NroConocimientoEmbarque = NroConocimientoEmbarqueEditBox.Text;
            infoRecepcionDocumentos.Factura = FacturaEditBox.Text;
            infoRecepcionDocumentos.FechaRecepcionDocumentos = FechaRecepcionDocumentosCalendarCombo.Value.Date;
        }
    }
}