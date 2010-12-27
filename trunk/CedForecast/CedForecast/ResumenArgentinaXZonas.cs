using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class ResumenArgentinaXZonasForm : Cedeira.UI.frmBaseEnviarA
    {
        private bool volverATabBrowser;

        public ResumenArgentinaXZonasForm(string Titulo)
            : base(Titulo)
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
            TipoReporte_CheckedChanged((object)ZonaFamiliayArticulosUiRadioButton, EventArgs.Empty);
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
            CedForecastDB.Forecast db = new CedForecastDB.Forecast(Aplicacion.Sesion);
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
                string periodoDesde;
                string periodoHasta;
                if (PeriodoAnualUIRadioButton.Checked)
                {
                    periodoDesde = PeriodoDesdeCalendarCombo.Value.ToString("yyyy") + "01";
                    periodoHasta = PeriodoDesdeCalendarCombo.Value.ToString("yyyy") + "12";
                }
                else
                {
                    ValidarRangoFechas(PeriodoRangoDesdeCalendarCombo, PeriodoRangoHastaCalendarCombo);
                    periodoDesde = PeriodoRangoDesdeCalendarCombo.Value.ToString("yyyyMM");
                    periodoHasta = PeriodoRangoHastaCalendarCombo.Value.ToString("yyyyMM");
                }
                DataTable dt = CedForecastRN.Reporte.ResumenArgentinaXZonas(periodoDesde, periodoHasta, TipoReporteNicePanel.Tag.ToString(), Cedeira.UI.Fun.ListaTreeView(ArticulosTreeView), Cedeira.UI.Fun.ListaTreeView(ClientesTreeView), Cedeira.UI.Fun.ListaTreeView(VendedoresTreeView), ValorizadoUiCheckBox.Checked, Aplicacion.Sesion, out advertencias);
                PersonalizarGrilla(dt);
                BrowserGridEX.DataSource = dt;
                //ModificarTotalDesvioGridEx(BrowserGridEX);
                
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
                            case "Zona":
                            case "Vendedor":
                                BrowserGridEX.RootTable.Columns[elemento].Width = 100;
                                break;
                            case "Articulo":
                                BrowserGridEX.RootTable.Columns[elemento].Width = 250;
                                break;
                            case "Familia":
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
                        if (elemento != Datos.Columns.Count - 1)
                        {
                            BrowserGridEX.RootTable.Columns[elemento].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
                        }
                        if (nombre == "Total Plan-" + PeriodoDesdeCalendarCombo.Value.ToString("yyyy") || nombre == "Total Real-" + PeriodoDesdeCalendarCombo.Value.ToString("yyyy") || nombre == "Desvio Plan-" + PeriodoDesdeCalendarCombo.Value.ToString("yyyy"))
                        {
                            BrowserGridEX.RootTable.Columns[elemento].Width = 110;
                        }
                        else
                        {
                            BrowserGridEX.RootTable.Columns[elemento].Width = 75;
                        }
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

                Janus.Windows.GridEX.GridEXGroup grupo0 = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.Columns[0]);
                grupo0.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
                BrowserGridEX.RootTable.Groups.Add(grupo0);
                BrowserGridEX.RootTable.Columns[0].Visible = false;

                Janus.Windows.GridEX.GridEXGroup grupo1 = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.Columns[1]);
                grupo1.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
                BrowserGridEX.RootTable.Groups.Add(grupo1);
                BrowserGridEX.RootTable.Columns[1].Visible = false;

                Janus.Windows.GridEX.GridEXGroup grupo2 = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.Columns[2]);
                grupo2.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
                BrowserGridEX.RootTable.Groups.Add(grupo2);
                BrowserGridEX.RootTable.Columns[2].Visible = false;
            }
        }

        public static void ModificarTotalDesvioGridEx(Janus.Windows.GridEX.GridEX JanusGridEx)
        {
            JanusGridEx.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
            int columnas = JanusGridEx.RootTable.Columns.Count;
            for (int registros = 0; registros < JanusGridEx.RowCount; registros++)
            {
                if (JanusGridEx.GetRow(registros).Cells[0].Text == "" && JanusGridEx.GetRow(registros).Cells[1].Text == "" && JanusGridEx.GetRow(registros).Cells[2].Text == "")
                {
                    if (JanusGridEx.GetRow(registros).Cells[columnas - 3].Text != "")
                    {
                        decimal real = 0;
                        decimal plan = 0;
                        real = Convert.ToDecimal(JanusGridEx.GetRow(registros).Cells[columnas - 2].Text);
                        plan = Convert.ToDecimal(JanusGridEx.GetRow(registros).Cells[columnas - 3].Text);
                        if (plan != 0)
                        {
                            Janus.Windows.GridEX.GridEXRow gr = JanusGridEx.GetRow(registros);
                            gr.BeginEdit();
                            gr.Cells[columnas - 1].Value=Convert.ToString((real / plan - 1) * 100);
                            gr.EndEdit();
                            //JanusGridEx.GetRows().SetValue( gr, 0);
                        }
                    }
                }
            }
            JanusGridEx.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
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
                        ExportDetails(BrowserGridEX, Cedeira.SV.Export.ExportFormat.Excel, this.Text + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls");
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
        public void ExportDetails(Janus.Windows.GridEX.GridEX Grilla, Cedeira.SV.Export.ExportFormat FormatType, string FileName)
        {
            Cedeira.SV.Export export = new Cedeira.SV.Export();
            System.Diagnostics.Process loProcess = System.Diagnostics.Process.GetCurrentProcess();
            loProcess.MaxWorkingSet = (IntPtr)10000000;
            loProcess.MinWorkingSet = (IntPtr)5000000;
            try
            {
                DataSet dsExport = Cedeira.SV.Fun.GetDataSetFromJanusGridEx(Grilla, FileName);
                dsExport.DataSetName = "Export";
                dsExport.Tables[0].TableName = "Values";
                string[] sHeaders = new string[dsExport.Tables[0].Columns.Count];
                string[] sFileds = new string[dsExport.Tables[0].Columns.Count];
                for (int i = 0; i < dsExport.Tables[0].Columns.Count; i++)
                {
                    dsExport.Tables[0].Columns[i].ColumnName = Convert.ToString(i);
                }
                for (int i = 0; i < dsExport.Tables[0].Columns.Count; i++)
                {
                    sHeaders[i] = export.ReemplazarEspaciosyAcentos(dsExport.Tables[0].Columns[i].Caption);
                    dsExport.Tables[0].Columns[i].ColumnName = sHeaders[i];
                    sFileds[i] = sHeaders[i];
                }
                int columnas = dsExport.Tables[0].Columns.Count;
                for (int l = 0; l < dsExport.Tables[0].Rows.Count; l++)
                {
                    for (int i = 0; i < dsExport.Tables[0].Columns.Count; i++)
                    {
                        string aux = export.ReemplazarXPath(Convert.ToString(dsExport.Tables[0].Rows[l].ItemArray[i]));
                        dsExport.Tables[0].Rows[l][i] = aux;
                        dsExport.Tables[0].Rows[l].AcceptChanges();
                    }
                    if (dsExport.Tables[0].Rows[l][0].ToString() == "")
                    {
                        decimal real = 0;
                        decimal plan = 0;
                        if (dsExport.Tables[0].Rows[l][columnas - 2].ToString().Trim() != "")
                        {
                            real = Convert.ToDecimal(dsExport.Tables[0].Rows[l][columnas - 2].ToString());
                        }
                        if (dsExport.Tables[0].Rows[l][columnas - 3].ToString().Trim() != "")
                        {
                            plan = Convert.ToDecimal(dsExport.Tables[0].Rows[l][columnas - 3].ToString());
                        }
                        if (plan != 0)
                        {
                            dsExport.Tables[0].Rows[l][columnas - 1] = Convert.ToString(Math.Round((real / plan - 1) * 100, 2));
                            dsExport.Tables[0].Rows[l].AcceptChanges();
                        }
                    }
                }
                string dir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\CedForecast\\";
                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }
                FileName = dir + export.ReemplazarCaracteresMalos(FileName);
                export.Export_with_XSLT_Windows(dsExport, sHeaders, sFileds, FormatType, FileName);
                System.Diagnostics.Process.Start(FileName);
            }
            catch (Exception Ex)
            {
                throw Ex;
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
            TipoReporteNicePanel.Tag = ((Janus.Windows.EditControls.UIRadioButton)sender).Tag;
            switch (((Janus.Windows.EditControls.UIRadioButton)sender).Tag.ToString())
            {
                case "Zona-Familia-Articulo":
                    ArmaGruposUiCheckBox.Text = "Agrupa por zona y familia de artículos";
                    break;
                case "Vendedor-Familia-Articulo":
                    ArmaGruposUiCheckBox.Text = "Agrupa por vendedor y familia de artículos";
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
        private void ValidarRangoFechas(Janus.Windows.CalendarCombo.CalendarCombo desde, Janus.Windows.CalendarCombo.CalendarCombo hasta)
        {
            if (Convert.ToInt32(desde.Value.ToString("yyyyMM")) > Convert.ToInt32(hasta.Value.ToString("yyyyMM")))
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Rango de fechas");
            }
        }
    }
}