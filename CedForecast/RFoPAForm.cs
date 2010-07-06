using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class RFoPAForm : Cedeira.UI.frmBaseEnviarA
    {
        private bool volverATabBrowser;

        public RFoPAForm(string Titulo)
            : base(Titulo)
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
                CedForecastEntidades.RFoPA forecast = new CedForecastEntidades.RFoPA();
                if (RFUiRadioButton.Checked)
                {
                    forecast.IdTipoPlanilla = "RollingForecast";
                    forecast.IdPeriodo = PeriodoRFCalendarCombo.Value.ToString("yyyyMM");
                }
                else
                {
                    forecast.IdTipoPlanilla = "Proyectado";
                    forecast.IdPeriodo = PeriodoPACalendarCombo.Value.ToString("yyyy");
                }
                List<CedForecastEntidades.RFoPA> l = CedForecastRN.RFoPA.Lista(forecast, Cedeira.UI.Fun.ListaTreeView(ArticulosTreeView), Cedeira.UI.Fun.ListaTreeView(VendedoresTreeView), Aplicacion.Sesion);
                PersonalizarGrilla(l);
                BrowserGridEX.DataSource = l;
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
        private string TextoCantidadHeader(int ColCantidad, string PeriodoInicial)
        {
            DateTime fechaAux = new DateTime(Convert.ToInt32(PeriodoInicial.Substring(0, 4)), Convert.ToInt32(PeriodoInicial.Substring(4, 2)), 1);
            fechaAux = fechaAux.AddMonths(ColCantidad - 1);
            return fechaAux.ToString("MM-yyyy");
        }
        private void PersonalizarGrilla(List<CedForecastEntidades.RFoPA> Datos)
        {
            //Columnas
            BrowserGridEX.RootTable.Columns.Clear();
            BrowserGridEX.RootTable.Columns.Add("DescrArticulo", Janus.Windows.GridEX.ColumnType.Text);
            BrowserGridEX.RootTable.Columns.Add("DescrCliente", Janus.Windows.GridEX.ColumnType.Text);
            BrowserGridEX.RootTable.Columns.Add("IdCuenta", Janus.Windows.GridEX.ColumnType.Text);
            for (int i = 1; i <= 12; i++)
            {
                BrowserGridEX.RootTable.Columns.Add("Cantidad" +Convert.ToString(i), Janus.Windows.GridEX.ColumnType.Text);
            }
            BrowserGridEX.RootTable.Columns.Add("CantidadTotal", Janus.Windows.GridEX.ColumnType.Text);
            //ForecastPagingGridView.Columns[13 + colFijas].HeaderText = "Total";
            //TextoCantidadHeader(PeriodoRFCalendarCombo.Value.Year + PeriodoRFCalendarCombo.Value.Month));

            //BrowserGridEX.RootTable.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            //for (int i = 0; i<Datos.Count; i++)
            //{
            //    string nombre = Datos[i].Columns[i].ColumnName;
            //    BrowserGridEX.RootTable.Columns.Add(nombre, Janus.Windows.GridEX.ColumnType.Text);
            //    int elemento = BrowserGridEX.RootTable.Columns.Count - 1;
            //    string tipo = Datos.Columns[i].DataType.Name;
            //    switch (tipo)
            //    {
            //        case "String":
            //            BrowserGridEX.RootTable.Columns[elemento].Width = 150;
            //            break;
            //        case "Decimal":
            //            BrowserGridEX.RootTable.Columns[elemento].FormatMode = Janus.Windows.GridEX.FormatMode.UseIFormattable;
            //            BrowserGridEX.RootTable.Columns[elemento].FormatString = "######,##0.00;(-######,##0.00)";
            //            BrowserGridEX.RootTable.Columns[elemento].DefaultGroupFormatString = "######,##0.00;(-######,##0.00)";
            //            BrowserGridEX.RootTable.Columns[elemento].TotalFormatString = "######,##0.00;(-######,##0.00)";
            //            BrowserGridEX.RootTable.Columns[elemento].TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            //            BrowserGridEX.RootTable.Columns[elemento].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
            //            BrowserGridEX.RootTable.Columns[elemento].Width = 75;
            //            break;
            //        default:
            //            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Tipo de dato " + tipo);
            //    }
            //    BrowserGridEX.RootTable.Columns[elemento].Caption = Datos.Columns[i].Caption;
            //}
            //Cortes de control
            switch (TipoReporteNicePanel.Tag.ToString())
            {
                case "Vendedores-Art�culos":
                    //Janus.Windows.GridEX.GridEXGroup grupo = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.Columns[0]);
                    //grupo.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
                    //BrowserGridEX.RootTable.Groups.Add(grupo);
                    //BrowserGridEX.RootTable.Columns[0].Visible = false;
                    break;
                case "S�lo Art�culos":
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
            if (((Janus.Windows.EditControls.UIRadioButton)sender).Text == "S�lo Art�culos")
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