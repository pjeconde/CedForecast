using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class OrdenCompraAltaForm : Cedeira.UI.frmBaseEnviarA
    {
        static string titulo = "Alta de Orden de Compra";
        CedForecastEntidades.OrdenCompraInfoAlta ordenCompraInfoAlta;

        public OrdenCompraAltaForm() : base(titulo)
        {
            InitializeComponent();
            LlenarCombos();
            IdProveedorUiComboBox.SelectedValue = "COM";
            IdPaisOrigenUiComboBox.SelectedValue = "A";
            FechaEstimadaArriboRequeridaCalendarCombo.Focus();
            ordenCompraInfoAlta = new CedForecastEntidades.OrdenCompraInfoAlta();
            ListaGridEX.DataSource = ordenCompraInfoAlta.Minutas;
        }
        private void LlenarCombos()
        {
            LlenarComboProveedor();
            LlenarComboPaisOrigen();
        }
        private void LlenarComboProveedor()
        {
            List<CedForecastEntidades.Codigo> datos = CedForecastRN.Tabla.Leer("Proveedor", Aplicacion.Sesion);
            IdProveedorUiComboBox.DataSource = datos;
            IdProveedorUiComboBox.ValueMember = "Id";
            IdProveedorUiComboBox.DisplayMember = "Descr";
        }
        private void LlenarComboPaisOrigen()
        {
            List<CedForecastEntidades.Codigo> datos = CedForecastRN.Tabla.Leer("PaisOrigen", Aplicacion.Sesion);
            IdPaisOrigenUiComboBox.DataSource = datos;
            IdPaisOrigenUiComboBox.ValueMember = "Id";
            IdPaisOrigenUiComboBox.DisplayMember = "Descr";
        }
        private void MaxMinUiButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            MinimizarUiButton.Visible = true;
            MaximizarUiButton.Visible = false;
        }
        private void MinimizarUiButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            MinimizarUiButton.Visible = false;
            MaximizarUiButton.Visible = true;
        }
        private void IdProveedorUiButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form oFrm = new TablaGrillaForm(new CedForecastEntidades.Opcion("Proveedor", "Proveedor"));
            oFrm.ShowDialog();
            LlenarComboProveedor();
        }
        private void IdPaisOrigenUiButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form oFrm = new TablaGrillaForm(new CedForecastEntidades.Opcion("PaisOrigen", "Pais de Origen"));
            oFrm.ShowDialog();
            LlenarComboPaisOrigen();
        }
        private void EnviarAUiCommandManager_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            switch (e.Command.Key)
            {
                case "Impresora":
                    Cedeira.SV.Fun.ImprimirGrilla(this, ListaGridEX, Aplicacion.Titulo, true);
                    break;
                case "Planilla":
                    try
                    {
                        Cedeira.SV.Export planilla = new Cedeira.SV.Export();
                        Cursor = Cursors.WaitCursor;
                        planilla.ExportDetails(ListaGridEX, Cedeira.SV.Export.ExportFormat.Excel, this.Text + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls");
                    }
                    catch (Exception ex)
                    {
                        Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                    break;
            }
        }
        private void AltaUiButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ordenCompraInfoAlta.Prefijo = PrefijoEditBox.Text;
            ordenCompraInfoAlta.IdProveedor = IdProveedorUiComboBox.SelectedValue.ToString();
            ordenCompraInfoAlta.DescrProveedor = IdProveedorUiComboBox.Text;
            ordenCompraInfoAlta.Fecha = FechaCalendarCombo.Value.Date;
            ordenCompraInfoAlta.IdPaisOrigen = IdPaisOrigenUiComboBox.SelectedValue.ToString();
            ordenCompraInfoAlta.DescrPaisOrigen = IdPaisOrigenUiComboBox.Text;
            ordenCompraInfoAlta.FechaEstimadaArriboRequerida = FechaEstimadaArriboRequeridaCalendarCombo.Value.Date;
            ordenCompraInfoAlta.Comentario = ComentarioEditBox.Text;
            System.Windows.Forms.Form oFrm = new OrdenCompraAltaMinutaForm(ordenCompraInfoAlta, "Alta de minuta de Orden de Compra");
            oFrm.ShowDialog();
            ListaGridEX.DataSource = ordenCompraInfoAlta.Minutas;
            if (ordenCompraInfoAlta.Minutas.Count == 9)
            {
                AltaUiButton.Enabled = false;
            }
            ListaGridEX.Update();
            this.Update();
            Cursor = Cursors.Default;
        }
        private void BajaUiButton_Click(object sender, EventArgs e)
        {
            if (ordenCompraInfoAlta.Minutas.Count < 9)
            {
                AltaUiButton.Enabled = true;
            }
        }
        private void IdPaisOrigenUiComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrefijoEditBox.Text = IdPaisOrigenUiComboBox.SelectedValue.ToString();
        }
    }
}