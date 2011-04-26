using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class TablaGrillaForm : Cedeira.UI.frmBaseEnviarA
    {
        string tabla;
        string concepto;

        public TablaGrillaForm(CedForecastEntidades.Opcion Tabla) : base(Tabla.Descr)
        {
            tabla = Tabla.Id;
            concepto = tabla;
            if (concepto == "PaisOrigen") concepto = "Pais de origen";
            InitializeComponent();
            ActualizarGrilla();
            SalirUiButton.Focus();
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
                ListaGridEX.DataSource = CedForecastRN.Tabla.Leer(tabla, Aplicacion.Sesion);
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
            Cursor = Cursors.WaitCursor;
            System.Windows.Forms.Form oFrm = new TablaForm(tabla, "Alta de " + concepto);
            oFrm.ShowDialog();
            ActualizarGrilla();
            Cursor = Cursors.Default;
        }
        private void BajaUiButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (ListaGridEX.SelectedItems.Count > 0)
            {
                System.Windows.Forms.Form oFrm = new TablaForm(tabla, "Baja de " + concepto, "Baja", (CedForecastEntidades.Codigo)ListaGridEX.SelectedItems[0].GetRow().DataRow);
                oFrm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Primero seleccione, en la grilla, el item que desea eliminar.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ActualizarGrilla();
            Cursor = Cursors.Default;
        }
        private void ModificacionUiButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (ListaGridEX.SelectedItems.Count > 0)
            {
                System.Windows.Forms.Form oFrm = new TablaForm(tabla, "Modificación de " + concepto, "Modificacion", (CedForecastEntidades.Codigo)ListaGridEX.SelectedItems[0].GetRow().DataRow);
                oFrm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Primero seleccione, en la grilla, el item que desea modificar.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ActualizarGrilla();
            Cursor = Cursors.Default;
        }
        private void ConsultauiButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (ListaGridEX.SelectedItems.Count > 0)
            {
                System.Windows.Forms.Form oFrm = new TablaForm(tabla, "Consulta de " + concepto, "Consulta", (CedForecastEntidades.Codigo)ListaGridEX.SelectedItems[0].GetRow().DataRow);
                oFrm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Primero seleccione, en la grilla, el item que desea consultar.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ActualizarGrilla();
            Cursor = Cursors.Default;
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