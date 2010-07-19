using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class FamiliaArticuloGrillaForm : Cedeira.UI.frmBaseEnviarA
    {
        public FamiliaArticuloGrillaForm(string Titulo) : base(Titulo)
        {
            InitializeComponent();
            ActualizarGrilla();
        }
        private void ActualizarGrilla()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                int fr;
                int cr;
                fr = ListaGridEX.FirstRow;
                cr = ListaGridEX.Row;
                Janus.Windows.GridEX.IFilterCondition fc = ListaGridEX.RootTable.FilterCondition;
                ListaGridEX.DataSource = new CedForecastDB.FamiliaArticulo(Aplicacion.Sesion).LeerLista();
                ListaGridEX.RootTable.FilterCondition = fc;
                try
                {
                    ListaGridEX.FirstRow = fr;
                }
                catch { }
                try
                {
                    ListaGridEX.Row = cr;
                }
                catch { }
                FondoNicePanel.HeaderText = tituloOriginal + " (" + ListaGridEX.RecordCount + ")";
                ListaGridEX.SelectedItems.Clear();
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
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
        private void AltaUiButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form oFrm = new FamiliaArticuloForm("Alta de Familia de Articulos");
            oFrm.ShowDialog();
        }
        private void BajaUiButton_Click(object sender, EventArgs e)
        {
            if (ListaGridEX.SelectedItems.Count > 0)
            {
                System.Windows.Forms.Form oFrm = new FamiliaArticuloForm("Baja de Familia de Articulos", "Baja", (CedForecastEntidades.FamiliaArticulo) ListaGridEX.SelectedItems[0].GetRow().DataRow);
                oFrm.ShowDialog();
            }
        }
        private void ModificacionUiButton_Click(object sender, EventArgs e)
        {
            if (ListaGridEX.SelectedItems.Count > 0)
            {
                System.Windows.Forms.Form oFrm = new FamiliaArticuloForm("Modificación de Familia de Articulos", "Modificacion", (CedForecastEntidades.FamiliaArticulo)ListaGridEX.SelectedItems[0].GetRow().DataRow);
                oFrm.ShowDialog();
            }
        }
        private void ConsultauiButton_Click(object sender, EventArgs e)
        {
            if (ListaGridEX.SelectedItems.Count > 0)
            {
                System.Windows.Forms.Form oFrm = new FamiliaArticuloForm("Consulta de Familia de Articulos", "Consulta", (CedForecastEntidades.FamiliaArticulo)ListaGridEX.SelectedItems[0].GetRow().DataRow);
                oFrm.ShowDialog();
            }
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
    }
}

