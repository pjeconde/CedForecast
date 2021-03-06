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
            BrowserUiTabPage.StateStyles.FormatStyle.BackColor = Color.PeachPuff;
            FiltroUiTabPage.StateStyles.FormatStyle.BackColor = Color.Cornsilk; 
            BrowserUiTabPage.TabVisible = false;
            CancelarUiButton.Text = "Salir";
            volverATabBrowser = false;
            ConfigurarFiltros();
            ArticulosUiCheckBox.Checked = true;
            ClientesUiCheckBox.Checked = true;
            VendedoresUiCheckBox.Checked = true;
            TipoReporteNicePanel.Tag = "FamArtCliVen";
            PeriodoRFCalendarCombo.Value = DateTime.Today;
            PeriodoPACalendarCombo.Value = DateTime.Today;
            try
            {
                string ProyectadoMesInicio = System.Configuration.ConfigurationManager.AppSettings["ProyectadoMesInicio"];
                if (DateTime.Today.Month < Convert.ToInt32(ProyectadoMesInicio))
                {
                    PeriodoPACalendarCombo.Value = Convert.ToDateTime("01/" + ProyectadoMesInicio + "/" + DateTime.Today.AddYears(-1).Year);
                }
                else
                {
                    PeriodoPACalendarCombo.Value = Convert.ToDateTime("01/" + ProyectadoMesInicio + "/" + DateTime.Today.Year);
                }
            }
            catch
            {
                MessageBox.Show("Problemas para obtener el mes inicial del ejercicio ec�nomico.", "ATENCI�N", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                BrowserUiTabPage.TabVisible = true;
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
                CedForecastEntidades.RFoPA forecast = new CedForecastEntidades.RFoPA();
                if (RFUiRadioButton.Checked)
                {
                    forecast.IdTipoPlanilla = "RollingForecast";
                    forecast.IdPeriodo = PeriodoRFCalendarCombo.Value.ToString("yyyyMM");
                }
                else
                {
                    forecast.IdTipoPlanilla = "Proyectado";
                    forecast.IdPeriodo = PeriodoPACalendarCombo.Value.ToString("yyyyMM");
                }
                List<CedForecastEntidades.RFoPA> l = CedForecastRN.RFoPA.Lista(forecast, TipoReporteNicePanel.Tag.ToString(), Cedeira.UI.Fun.ListaTreeView(ArticulosTreeView), Cedeira.UI.Fun.ListaTreeView(ClientesTreeView), Cedeira.UI.Fun.ListaTreeView(VendedoresTreeView), Aplicacion.Sesion, out advertencias);
                PersonalizarGrilla(l);
                BrowserGridEX.DataSource = l;
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
            BrowserGridEX.RootTable.Columns.Add("IdFamiliaArticulo", Janus.Windows.GridEX.ColumnType.Text);
            BrowserGridEX.RootTable.Columns["IdFamiliaArticulo"].Caption = "Id.Familia";
            BrowserGridEX.RootTable.Columns["IdFamiliaArticulo"].Width = 60;
            BrowserGridEX.RootTable.Columns.Add("DescrFamiliaArticulo", Janus.Windows.GridEX.ColumnType.Text);
            BrowserGridEX.RootTable.Columns["DescrFamiliaArticulo"].Caption = "Familia";
            BrowserGridEX.RootTable.Columns["DescrFamiliaArticulo"].Width = 100;
            BrowserGridEX.RootTable.Columns.Add("IdArticulo", Janus.Windows.GridEX.ColumnType.Text);
            BrowserGridEX.RootTable.Columns["IdArticulo"].Caption = "Id.Articulo";
            BrowserGridEX.RootTable.Columns["IdArticulo"].Width = 60;
            BrowserGridEX.RootTable.Columns.Add("DescrArticulo", Janus.Windows.GridEX.ColumnType.Text);
            BrowserGridEX.RootTable.Columns["DescrArticulo"].Caption = "Articulo";
            BrowserGridEX.RootTable.Columns["DescrArticulo"].Width = 200;
            BrowserGridEX.RootTable.Columns.Add("IdCliente", Janus.Windows.GridEX.ColumnType.Text);
            BrowserGridEX.RootTable.Columns["IdCliente"].Caption = "Id.Cliente";
            BrowserGridEX.RootTable.Columns["IdCliente"].Width = 60;
            BrowserGridEX.RootTable.Columns.Add("DescrCliente", Janus.Windows.GridEX.ColumnType.Text);
            BrowserGridEX.RootTable.Columns["DescrCliente"].Caption = "Cliente";
            BrowserGridEX.RootTable.Columns["DescrCliente"].Width = 200;
            BrowserGridEX.RootTable.Columns.Add("IdCuenta", Janus.Windows.GridEX.ColumnType.Text);
            BrowserGridEX.RootTable.Columns["IdCuenta"].Caption = "Vendedor";
            BrowserGridEX.RootTable.Columns["IdCuenta"].Width = 60;
            
            if (!VisualizarCodigosUiCheckBox.Checked)
            {
                BrowserGridEX.RootTable.Columns["IdFamiliaArticulo"].Visible = false;
                BrowserGridEX.RootTable.Columns["IdArticulo"].Visible = false;
                BrowserGridEX.RootTable.Columns["IdCliente"].Visible = false;
            }
            switch (TipoReporteNicePanel.Tag.ToString())
            {
                case "FamArtCliVen":
                    break;
                case "FamArtCli":
                    BrowserGridEX.RootTable.Columns["IdCuenta"].Visible = false;
                    break;
                case "FamArtVen":
                    BrowserGridEX.RootTable.Columns["IdCliente"].Visible = false;
                    BrowserGridEX.RootTable.Columns["DescrCliente"].Visible = false;
                    break;
                case "FamArt":
                    BrowserGridEX.RootTable.Columns["IdCuenta"].Visible = false;
                    BrowserGridEX.RootTable.Columns["IdCliente"].Visible = false;
                    BrowserGridEX.RootTable.Columns["DescrCliente"].Visible = false;
                    break;
                case "Fam":
                    BrowserGridEX.RootTable.Columns["IdArticulo"].Visible = false;
                    BrowserGridEX.RootTable.Columns["DescrArticulo"].Visible = false;
                    BrowserGridEX.RootTable.Columns["IdCuenta"].Visible = false;
                    BrowserGridEX.RootTable.Columns["IdCliente"].Visible = false;
                    BrowserGridEX.RootTable.Columns["DescrCliente"].Visible = false;    
                    break;
            }
            if (RFUiRadioButton.Checked && (TipoReporteNicePanel.Tag.ToString() == "FamArtCli" || TipoReporteNicePanel.Tag.ToString() == "FamArt"))
            {
                BrowserGridEX.RootTable.Columns.Add("Proyectado", Janus.Windows.GridEX.ColumnType.Text);
                FormatoColumna("Proyectado", 75);
                BrowserGridEX.RootTable.Columns.Add("Ventas", Janus.Windows.GridEX.ColumnType.Text);
                FormatoColumna("Ventas", 75);
                BrowserGridEX.RootTable.Columns.Add("Desvio", Janus.Windows.GridEX.ColumnType.Text);
                FormatoColumna("Desvio", 75);
            }
            for (int i = 1; i <= 12; i++)
            {
                string elemento = "Cantidad" + Convert.ToString(i);
                BrowserGridEX.RootTable.Columns.Add(elemento, Janus.Windows.GridEX.ColumnType.Text);
                if (RFUiRadioButton.Checked)
                {
                    BrowserGridEX.RootTable.Columns[elemento].Caption = " " + TextoCantidadHeader(i, PeriodoRFCalendarCombo.Value.Year.ToString("0000") + PeriodoRFCalendarCombo.Value.Month.ToString("00"));
                }
                else
                {
                    BrowserGridEX.RootTable.Columns[elemento].Caption = " " + TextoCantidadHeader(i, PeriodoPACalendarCombo.Value.Year.ToString("0000") + PeriodoPACalendarCombo.Value.Month.ToString("00"));
                }
                FormatoColumna(elemento, 75);
            }
            BrowserGridEX.RootTable.Columns.Add("CantidadTotal", Janus.Windows.GridEX.ColumnType.Text);
            if (RFUiRadioButton.Checked)
            {
                BrowserGridEX.RootTable.Columns["CantidadTotal"].Caption = "Total";
                FormatoColumna("CantidadTotal", 75);
            }
            else
            {
                BrowserGridEX.RootTable.Columns["CantidadTotal"].Caption = "Total " + PeriodoPACalendarCombo.Value.Year.ToString("0000");
                FormatoColumna("CantidadTotal", 75);
                BrowserGridEX.RootTable.Columns.Add("Cantidad13", Janus.Windows.GridEX.ColumnType.Text);
                BrowserGridEX.RootTable.Columns["Cantidad13"].Caption = "Total " + PeriodoPACalendarCombo.Value.AddYears(1).Year.ToString("0000");
                FormatoColumna("Cantidad13", 75);
                BrowserGridEX.RootTable.Columns.Add("Cantidad14", Janus.Windows.GridEX.ColumnType.Text);
                BrowserGridEX.RootTable.Columns["Cantidad14"].Caption = "Total " + PeriodoPACalendarCombo.Value.AddYears(2).Year.ToString("0000");
                FormatoColumna("Cantidad14", 75);
            }
            //BrowserGridEX.EditMode = Janus.Windows.GridEX.EditMode.EditOn;
            //BrowserGridEX.RootTable.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
            BrowserGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
        }
        private void FormatoColumna(string elemento, int tama�o)
        {
            BrowserGridEX.RootTable.Columns[elemento].FormatMode = Janus.Windows.GridEX.FormatMode.UseIFormattable;
            BrowserGridEX.RootTable.Columns[elemento].FormatString = "######,##0.00;(-######,##0.00)";
            BrowserGridEX.RootTable.Columns[elemento].DefaultGroupFormatString = "######,##0.00;(-######,##0.00)";
            BrowserGridEX.RootTable.Columns[elemento].TotalFormatString = "######,##0.00;(-######,##0.00)";
            BrowserGridEX.RootTable.Columns[elemento].TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            BrowserGridEX.RootTable.Columns[elemento].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
            BrowserGridEX.RootTable.Columns[elemento].Width = tama�o;
        }
        private void BrowserUiTab_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (BrowserUiTab.SelectedTab == FiltroUiTabPage)
            {
                BrowserUiTabPage.TabVisible = false;
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
        //private void TipoReporte_CheckedChanged(object sender, EventArgs e)
        //{
        //    ReporteNicePanel.Tag = ((Janus.Windows.EditControls.UIRadioButton)sender).Text;
        //    if (((Janus.Windows.EditControls.UIRadioButton)sender).Text == "S�lo Art�culos")
        //    {
        //        VendedoresNicePanel.Enabled = false;
        //        VendedoresUiCheckBox.Checked = false;
        //    }
        //    else
        //    {
        //        VendedoresNicePanel.Enabled = true;
        //        VendedoresUiCheckBox.Checked = true;
        //    }
        //}
        private void VendedoresUiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
			Cedeira.UI.Fun.ChequeoNodosTreeView(VendedoresTreeView.Nodes, VendedoresUiCheckBox.Checked);
        }
        private void ClientesUiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Cedeira.UI.Fun.ChequeoNodosTreeView(ClientesTreeView.Nodes, ClientesUiCheckBox.Checked);
        }
        private void ArticulosUiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Cedeira.UI.Fun.ChequeoNodosTreeView(ArticulosTreeView.Nodes, ArticulosUiCheckBox.Checked);
        }
        private void TipoReporteUiRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (FamArtCliVenUiRadioButton.Checked)
            {
                TipoReporteNicePanel.Tag = "FamArtCliVen";
            }
            else if (FamArtCliUiRadioButton.Checked)
            {
                TipoReporteNicePanel.Tag = "FamArtCli";
            }
            else if (FamArtVenUiRadioButton.Checked)
            {
                TipoReporteNicePanel.Tag = "FamArtVen";
            }
            else if (FamArtUiRadioButton.Checked)
            {
                TipoReporteNicePanel.Tag = "FamArt";
            }
            else
            {
                TipoReporteNicePanel.Tag = "Fam";
            }
        }
    }
}