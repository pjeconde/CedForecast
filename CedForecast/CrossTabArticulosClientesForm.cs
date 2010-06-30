using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class CrossTabArticulosClientesForm : Cedeira.UI.frmBase
    {
        private bool volverATabBrowser;

        public CrossTabArticulosClientesForm(string Titulo) : base(Titulo)
        {
            InitializeComponent();
            TabBrowserUiTabPage.StateStyles.FormatStyle.BackColor = Color.PeachPuff;
            TabFiltroUiTabPage.StateStyles.FormatStyle.BackColor = Color.Cornsilk; 
            TabBrowserUiTabPage.TabVisible = false;
            CancelarUiButton.Text = "Salir";
            volverATabBrowser = false;
        }
        private void CancelarUiButton_Click(object sender, EventArgs e)
        {
            if (volverATabBrowser)
            {
                TabBrowserUiTabPage.TabVisible = true;
                BrowserUiTab.SelectedTab = TabBrowserUiTabPage;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
        private void EjecutarSeleccionUiButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                DataTable dt = CedForecastRN.Reporte.CrossTabArticulosClientes(PeriodoDesdeCalendarCombo.Value.ToString("yyyyMM"), PeriodoHastaCalendarCombo.Value.ToString("yyyyMM"), ArticulosyVendedoresUiRadioButton.Checked, Aplicacion.Sesion);
                PersonalizarGrilla(dt);
                BrowserGridEX.DataSource = dt;
                BrowserGridEX.RootTable.Columns[2].Key = "Pirulo";
                TabBrowserUiTabPage.TabVisible = true;
                BrowserUiTab.SelectedTab = TabBrowserUiTabPage;
                volverATabBrowser = true;
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
        private void PersonalizarGrilla(DataTable Datos)
        {
            //Columnas
            BrowserGridEX.RootTable.Columns.Clear();
            for (int i = 0; i<Datos.Columns.Count; i++)
            {
                string nombre = Datos.Columns[i].ColumnName;
                BrowserGridEX.RootTable.Columns.Add(nombre, Janus.Windows.GridEX.ColumnType.Text);
                int elemento = BrowserGridEX.RootTable.Columns.Count - 1;
                string tipo = Datos.Columns[i].DataType.Name;
                switch (tipo)
                {
                    case "String":
                        switch (nombre)
                        {
                            case "Articulo":
                                BrowserGridEX.RootTable.Columns[elemento].Width = 250;
                                break;
                            case "Vendedor":
                                BrowserGridEX.RootTable.Columns[elemento].Width = 150;
                                break;
                        }
                        break;
                    case "Decimal":
                        BrowserGridEX.RootTable.Columns[elemento].FormatMode = Janus.Windows.GridEX.FormatMode.UseIFormattable;
                        BrowserGridEX.RootTable.Columns[elemento].FormatString = "######,##0.00;(-######,##0.00)";
                        BrowserGridEX.RootTable.Columns[elemento].TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                        BrowserGridEX.RootTable.Columns[elemento].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
                        BrowserGridEX.RootTable.Columns[elemento].Width = 75;
                        break;
                    default:
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Tipo de dato " + tipo);
                }
                BrowserGridEX.RootTable.Columns[elemento].Caption = Datos.Columns[i].Caption;
            }
            //Cortes de control
            if (ArticulosyVendedoresUiRadioButton.Checked)
            {
                Janus.Windows.GridEX.GridEXGroup grupo = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.Columns[0]);
                grupo.GroupFormatMode = Janus.Windows.GridEX.FormatMode.UseIFormattable;
                grupo.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
                BrowserGridEX.RootTable.Groups.Add(grupo);
                BrowserGridEX.RootTable.Columns[0].Visible = false;
            }
        }
        private void BrowserUiTab_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (BrowserUiTab.SelectedTab == TabFiltroUiTabPage)
            {
                TabBrowserUiTabPage.TabVisible = false;
            }
        }
        private void EnviarAUiCommandManager_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            switch (e.Command.Key)
            {
                case "Impresora":
                    Cedeira.SV.Fun.ImprimirGrilla(this, BrowserGridEX, Aplicacion.Titulo, true);
                    break;
                case "Planilla":
                    try
                    {
                        Cedeira.SV.Export planilla = new Cedeira.SV.Export();
                        Cursor = Cursors.WaitCursor;
                        planilla.ExportDetails(BrowserGridEX, Cedeira.SV.Export.ExportFormat.Excel, this.Text + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls");
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