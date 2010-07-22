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
            CancelarUiButton.Visible = false;
            volverATabBrowser = false;
            ConfigurarFiltros();
            ArticulosUiCheckBox.Checked = true;
            ClientesUiCheckBox.Checked = true;
            VendedoresUiCheckBox.Checked = true;
            TipoReporte_CheckedChanged((object)ArticulosyVendedoresUiRadioButton, EventArgs.Empty);
        }
        private void ConfigurarFiltros()
        {

            ArticulosTreeView.Nodes.Clear();
            CedForecastDB.Bejerman.Articulos articulos = new CedForecastDB.Bejerman.Articulos(Aplicacion.Sesion);
            List<CedForecastEntidades.Bejerman.Articulos> listaArticulos = articulos.LeerLista();
            for (int i = 0; i < listaArticulos.Count; i++)
            {
                TreeNode nd = new TreeNode(listaArticulos[i].Art_CodGen + "-" + listaArticulos[i].Art_DescGen);
                nd.Tag = listaArticulos[i].Art_CodGen;
                ArticulosTreeView.Nodes.Add(nd);
            }
            ClientesTreeView.Nodes.Clear();
            CedForecastDB.Bejerman.Clientes clientes = new CedForecastDB.Bejerman.Clientes(Aplicacion.Sesion);
            List<CedForecastEntidades.Bejerman.Clientes> listaClientes = clientes.LeerLista();
            for (int i = 0; i < listaClientes.Count; i++)
            {
                TreeNode nd = new TreeNode(listaClientes[i].Cli_Cod + "-" + listaClientes[i].Cli_RazSoc);
                nd.Tag = listaClientes[i].Cli_Cod;
                ClientesTreeView.Nodes.Add(nd);
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
                DataTable dt = CedForecastRN.Reporte.CrossTabArticulosClientes(PeriodoDesdeCalendarCombo.Value.ToString("yyyyMM"), PeriodoHastaCalendarCombo.Value.ToString("yyyyMM"), TipoReporteNicePanel.Tag.ToString(), Cedeira.UI.Fun.ListaTreeView(ArticulosTreeView), Cedeira.UI.Fun.ListaTreeView(ClientesTreeView), Cedeira.UI.Fun.ListaTreeView(VendedoresTreeView), Aplicacion.Sesion);
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
                                BrowserGridEX.RootTable.Columns[elemento].Width = 170;
                                break;
                            case "Familia":
                                BrowserGridEX.RootTable.Columns[elemento].Width = 120;
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
            if (ArmaGruposUiCheckBox.Checked)
            {
                BrowserGridEX.RootTable.Groups.Clear();
                Janus.Windows.GridEX.GridEXGroup grupo1 = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.Columns[0]);
                grupo1.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
                BrowserGridEX.RootTable.Groups.Add(grupo1);
                BrowserGridEX.RootTable.Columns[0].Visible = false;
                switch (TipoReporteNicePanel.Tag.ToString())
                {
                    case "Artículos-Vendedores":
                    case "Vendedores-Artículos":
                        Janus.Windows.GridEX.GridEXGroup grupo2 = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.Columns[1]);
                        grupo2.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
                        BrowserGridEX.RootTable.Groups.Add(grupo2);
                        BrowserGridEX.RootTable.Columns[1].Visible = false;
                        break;
                    case "Sólo Artículos":
                        break;
                }
            }
        }
        private void BrowserUiTab_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (BrowserUiTab.SelectedTab == TabFiltroUiTabPage)
            {
                TabBrowserUiTabPage.TabVisible = false;
                EnviarAUiButton.Visible = false;
                CancelarUiButton.Visible = true;
                CancelarUiButton.Text = "Cancelar";
            }
            else
            {
                EnviarAUiButton.Visible = true;
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
            switch (((Janus.Windows.EditControls.UIRadioButton)sender).Text)
            {
                case "Artículos-Vendedores":
                    VendedoresNicePanel.Enabled = true;
                    VendedoresUiCheckBox.Checked = true;
                    ArmaGruposUiCheckBox.Text = "Agrupa por familia de artículos y artículo";
                    break;
                case "Vendedores-Artículos":
                    VendedoresNicePanel.Enabled = true;
                    VendedoresUiCheckBox.Checked = true;
                    ArmaGruposUiCheckBox.Text = "Agrupa por vendedor y familia de artículos";
                    break;
                case "Sólo Artículos":
                    VendedoresNicePanel.Enabled = false;
                    VendedoresUiCheckBox.Checked = false;
                    ArmaGruposUiCheckBox.Text = "Agrupa por familia de artículos";
                    break;
            }
        }
        private void ArticulosUiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Cedeira.UI.Fun.ChequeoNodosTreeView(ArticulosTreeView, ArticulosUiCheckBox.Checked);
        }
        private void ClientesUiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Cedeira.UI.Fun.ChequeoNodosTreeView(ClientesTreeView, ClientesUiCheckBox.Checked);
        }
        private void VendedoresUiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Cedeira.UI.Fun.ChequeoNodosTreeView(VendedoresTreeView, VendedoresUiCheckBox.Checked);
        }
    }
}