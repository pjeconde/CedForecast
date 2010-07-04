using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class CrossTabArticulosClientesForm : Cedeira.UI.frmBaseEnviarA
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
            ConfigurarFiltros();
            ArticulosUiCheckBox.Checked = true;
            VendedoresUiCheckBox.Checked = true;
        }
        private void ConfigurarFiltros()
        {

            ArticulosTreeView.Nodes.Clear();
            CedForecastDB.Bejerman.Articulos articulos = new CedForecastDB.Bejerman.Articulos(Aplicacion.Sesion);
            List<CedForecastEntidades.Bejerman.Articulos> listaArticulos = articulos.LeerLista();
            for (int i = 0; i < listaArticulos.Count; i++)
            {
                TreeNode nd = new TreeNode(listaArticulos[i].Art_CodGen+"-"+listaArticulos[i].Art_DescGen);
                nd.Tag = listaArticulos[i].Art_CodGen;
                ArticulosTreeView.Nodes.Add(nd);
            }
            VendedoresTreeView.Nodes.Clear();
            CedForecastDB.Bejerman.Vendedor vendedores = new CedForecastDB.Bejerman.Vendedor(Aplicacion.Sesion);
            List<CedForecastEntidades.Bejerman.Vendedor> listaVendedores = vendedores.LeerLista();
            for (int i = 0; i < listaVendedores.Count; i++)
            {
                TreeNode nd = new TreeNode(listaVendedores[i].Ven_Cod + "-" + listaVendedores[i].Ven_Desc);
                nd.Tag = listaVendedores[i].Ven_Cod;
                VendedoresTreeView.Nodes.Add(nd);
            }
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
                DataTable dt = CedForecastRN.Reporte.CrossTabArticulosClientes(PeriodoDesdeCalendarCombo.Value.ToString("yyyyMM"), PeriodoHastaCalendarCombo.Value.ToString("yyyyMM"), TipoReporteNicePanel.Tag.ToString(), Cedeira.UI.Fun.ListaTreeView(ArticulosTreeView), Cedeira.UI.Fun.ListaTreeView(VendedoresTreeView), Aplicacion.Sesion);
                PersonalizarGrilla(dt);
                BrowserGridEX.DataSource = dt;
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
            BrowserGridEX.RootTable.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
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
                        BrowserGridEX.RootTable.Columns[elemento].DefaultGroupFormatString = "######,##0.00;(-######,##0.00)";
                        BrowserGridEX.RootTable.Columns[elemento].TotalFormatString = "######,##0.00;(-######,##0.00)";
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
            switch (TipoReporteNicePanel.Tag.ToString())
            {
                case "Artículos-Vendedores":
                case "Vendedores-Artículos":
                    Janus.Windows.GridEX.GridEXGroup grupo = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.Columns[0]);
                    grupo.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
                    BrowserGridEX.RootTable.Groups.Add(grupo);
                    BrowserGridEX.RootTable.Columns[0].Visible = false;
                    break;
                case "Sólo Artículos":
                    break;
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
        private void TipoReporte_CheckedChanged(object sender, EventArgs e)
        {
            TipoReporteNicePanel.Tag = ((Janus.Windows.EditControls.UIRadioButton)sender).Text;
            if (((Janus.Windows.EditControls.UIRadioButton)sender).Text == "Sólo Artículos")
            {
                VendedoresNicePanel.Enabled = false;
                VendedoresUiCheckBox.Checked = false;
            }
            else
            {
                VendedoresNicePanel.Enabled = true;
                VendedoresUiCheckBox.Checked = true;
            }
        }
        private void VendedoresUiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
			Cedeira.UI.Fun.ChequeoNodosTreeView(VendedoresTreeView, VendedoresUiCheckBox.Checked);
        }
        private void ArticulosUiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Cedeira.UI.Fun.ChequeoNodosTreeView(ArticulosTreeView, ArticulosUiCheckBox.Checked);
        }
    }
}