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
            BrowserUiTabPage.StateStyles.FormatStyle.BackColor = Color.PeachPuff;
            FiltroUiTabPage.StateStyles.FormatStyle.BackColor = Color.Cornsilk;
            MensajesUiTabPage.StateStyles.FormatStyle.BackColor = Color.LightCoral;
            BrowserUiTabPage.TabVisible = false;
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
            CedForecastDB.FamiliaArticulo familias = new CedForecastDB.FamiliaArticulo(Aplicacion.Sesion);
            List<CedForecastEntidades.FamiliaArticulo> listaFamilias = familias.LeerLista();
            for (int i = 0; i < listaFamilias.Count; i++)
            {
                TreeNode ndFamilia = new TreeNode(listaFamilias[i].Descr);
                ndFamilia.Tag = String.Empty;
                for (int j = 0; j < listaFamilias[i].Articulos.Count; j++)
                {
                    TreeNode ndArticulo = new TreeNode(listaFamilias[i].Articulos[j].Id + "-" + listaFamilias[i].Articulos[j].Descr);
                    ndArticulo.Tag = listaFamilias[i].Articulos[j].Id;
                    ndFamilia.Nodes.Add(ndArticulo);
                }
                ArticulosTreeView.Nodes.Add(ndFamilia);
            }
            //Agrego Articulos sin Familia
            CedForecastDB.ArticuloInfoAdicional db = new CedForecastDB.ArticuloInfoAdicional(Aplicacion.Sesion);
            List<CedForecastEntidades.Articulo> listaArticulosSinFamilia = db.LeerArticulosSinFamilia();
            if (listaArticulosSinFamilia.Count > 0)
            {
                TreeNode ndSinFamilia = new TreeNode("<<<Desconocida>>>");
                ndSinFamilia.Tag = String.Empty;
                for (int j = 0; j < listaArticulosSinFamilia.Count; j++)
                {
                    TreeNode ndArticuloSinFamilia = new TreeNode(listaArticulosSinFamilia[j].Id + "-" + listaArticulosSinFamilia[j].Descr);
                    ndArticuloSinFamilia.Tag = listaArticulosSinFamilia[j].Id;
                    ndSinFamilia.Nodes.Add(ndArticuloSinFamilia);
                }
                ArticulosTreeView.Nodes.Add(ndSinFamilia);
            }
            ClientesTreeView.Nodes.Clear();
            CedForecastDB.Bejerman.Zona zonas = new CedForecastDB.Bejerman.Zona(Aplicacion.Sesion);
            List<CedForecastEntidades.Bejerman.Zona> listaZonas = zonas.LeerLista();
            for (int i = 0; i < listaZonas.Count; i++)
            {
                TreeNode ndZona = new TreeNode(listaZonas[i].Zon_Desc);
                ndZona.Tag = String.Empty;
                for (int j = 0; j < listaZonas[i].Clientes.Count; j++)
                {
                    TreeNode ndCliente = new TreeNode(listaZonas[i].Clientes[j].Cli_Cod + "-" + listaZonas[i].Clientes[j].Cli_RazSoc);
                    ndCliente.Tag = listaZonas[i].Clientes[j].Cli_Cod;
                    ndZona.Nodes.Add(ndCliente);
                }
                ClientesTreeView.Nodes.Add(ndZona);
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
                BrowserUiTabPage.TabVisible = true;
                MensajesUiTabPage.TabVisible = true;
                BrowserUiTab.SelectedTab = BrowserUiTabPage;
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
                List<CedForecastEntidades.Advertencia> advertencias;
                DataTable dt = CedForecastRN.Reporte.CrossTabArticulosClientes(PeriodoDesdeCalendarCombo.Value.ToString("yyyyMM"), PeriodoHastaCalendarCombo.Value.ToString("yyyyMM"), TipoReporteNicePanel.Tag.ToString(), Cedeira.UI.Fun.ListaTreeView(ArticulosTreeView), Cedeira.UI.Fun.ListaTreeView(ClientesTreeView), Cedeira.UI.Fun.ListaTreeView(VendedoresTreeView), ValorizadoUiCheckBox.Checked, Aplicacion.Sesion, out advertencias);
                PersonalizarGrilla(dt);
                BrowserGridEX.DataSource = dt;
                BrowserUiTabPage.TabVisible = true;
                MensajesUiTabPage.TabVisible = (advertencias.Count > 0);
                if (MensajesUiTabPage.TabVisible)
                {
                    MensajesGridEX.DataSource = advertencias;
                    CedForecastEntidades.Advertencia error = advertencias.Find(delegate(CedForecastEntidades.Advertencia a) { return a.Tipo == CedForecastEntidades.Advertencia.TipoSeveridad.Error.ToString(); });
                    if (error != null)
                    {
                        BrowserUiTab.SelectedTab = MensajesUiTabPage;
                    }
                    else
                    {
                        BrowserUiTab.SelectedTab = BrowserUiTabPage;
                    }
                }
                else
                {
                    MensajesGridEX.DataSource = null;
                    BrowserUiTab.SelectedTab = BrowserUiTabPage;
                }
                volverATabBrowser = true;
                if (ValorizadoUiCheckBox.Checked)
                {
                    FondoNicePanel.HeaderText = this.Text + " (valorizado)";
                }
                else
                {
                    FondoNicePanel.HeaderText = this.Text + " (cantidades)";
                }
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
                    case "Art�culos-Vendedores":
                    case "Vendedores-Art�culos":
                        Janus.Windows.GridEX.GridEXGroup grupo2 = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.Columns[1]);
                        grupo2.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
                        BrowserGridEX.RootTable.Groups.Add(grupo2);
                        BrowserGridEX.RootTable.Columns[1].Visible = false;
                        break;
                    case "S�lo Art�culos":
                        break;
                }
            }
        }
        private void BrowserUiTab_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (BrowserUiTab.SelectedTab == FiltroUiTabPage)
            {
                BrowserUiTabPage.TabVisible = false;
                MensajesUiTabPage.TabVisible = false;
                EnviarAUiButton.Visible = false;
                CancelarUiButton.Visible = true;
                CancelarUiButton.Text = "Cancelar";
                FondoNicePanel.HeaderText = this.Text;
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
                case "Art�culos-Vendedores":
                    VendedoresNicePanel.Enabled = true;
                    VendedoresUiCheckBox.Checked = true;
                    ArmaGruposUiCheckBox.Text = "Agrupa por familia de art�culos y art�culo";
                    break;
                case "Vendedores-Art�culos":
                    VendedoresNicePanel.Enabled = true;
                    VendedoresUiCheckBox.Checked = true;
                    ArmaGruposUiCheckBox.Text = "Agrupa por vendedor y familia de art�culos";
                    break;
                case "S�lo Art�culos":
                    VendedoresNicePanel.Enabled = false;
                    VendedoresUiCheckBox.Checked = false;
                    ArmaGruposUiCheckBox.Text = "Agrupa por familia de art�culos";
                    break;
            }
        }
        private void ArticulosUiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Cedeira.UI.Fun.ChequeoNodosTreeView(ArticulosTreeView.Nodes, ArticulosUiCheckBox.Checked);
        }
        private void ClientesUiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Cedeira.UI.Fun.ChequeoNodosTreeView(ClientesTreeView.Nodes, ClientesUiCheckBox.Checked);
        }
        private void VendedoresUiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Cedeira.UI.Fun.ChequeoNodosTreeView(VendedoresTreeView.Nodes, VendedoresUiCheckBox.Checked);
        }
        private void TreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                Cedeira.UI.Fun.ChequeoNodosTreeView(e.Node.Nodes, e.Node.Checked);
            }
        }
    }
}