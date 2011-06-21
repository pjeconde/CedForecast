using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class StockXArticuloForm : Cedeira.UI.frmBaseEnviarA
    {
        private bool volverATabBrowser;

        public StockXArticuloForm(string Titulo)
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
            TipoReporte_CheckedChanged((object)FamiliayArticulosUiRadioButton, EventArgs.Empty);
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

            PeriodoDesdeCalendarCombo.Value = DateTime.Today;
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
                periodoDesde = PeriodoDesdeCalendarCombo.Value.ToString("yyyyMM");
                DataSet ds = CedForecastRN.Reporte.StockXArticulo(periodoDesde, TipoReporteNicePanel.Tag.ToString(), Cedeira.UI.Fun.ListaTreeView(ArticulosTreeView), ValorizadoUiCheckBox.Checked, Aplicacion.Sesion, out advertencias);
                PersonalizarGrillaDs(ds);
                if (ds.Tables.Count != 0)
                {
                    BrowserGridEX.DataSource = ds.Tables["Nivel1"];
                }
                else
                {
                    BrowserGridEX.DataSource = ds;
                }
                
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

        private void PersonalizarGrillaDs(DataSet Datos)
        {
            //Columnas
            BrowserGridEX.RootTable.Columns.Clear();
            if (BrowserGridEX.RootTable.ChildTables.Count != 0)
            {
                BrowserGridEX.RootTable.ChildTables.Clear();
            }
            BrowserGridEX.Hierarchical = true;
            BrowserGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            BrowserGridEX.RootTable.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            for (int t = 0; t < Datos.Tables.Count; t++)
            {
                if (t == 1)
                {
                    Janus.Windows.GridEX.GridEXTable table = new Janus.Windows.GridEX.GridEXTable();
                    BrowserGridEX.RootTable.ChildTables.Add(table);
                    BrowserGridEX.RootTable.ChildTables[t - 1].Key = "Nivel" + Convert.ToString(t + 1);
                    BrowserGridEX.RootTable.ChildTables[t - 1].Caption = "Nivel" + Convert.ToString(t + 1);
                }
                else if (t > 1)
                {
                    Janus.Windows.GridEX.GridEXTable table = new Janus.Windows.GridEX.GridEXTable();
                    BrowserGridEX.RootTable.ChildTables[0].ChildTables.Add(table);
                    BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Key = "Nivel" + Convert.ToString(t + 1);
                    BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Caption = "Nivel" + Convert.ToString(t + 1);
                }
                for (int i = 0; i < Datos.Tables[t].Columns.Count; i++)
                {
                    string nombre = Datos.Tables[t].Columns[i].ColumnName;
                    if (t == 1)
                    {
                        BrowserGridEX.RootTable.ChildTables[t - 1].Columns.Add(nombre, Janus.Windows.GridEX.ColumnType.Text);
                        int elemento = BrowserGridEX.RootTable.ChildTables[t - 1].Columns.Count - 1;
                        BrowserGridEX.RootTable.ChildTables[t - 1].Columns[elemento].Caption = Datos.Tables[t].Columns[i].Caption;
                        if (elemento == 2)
                        {
                            BrowserGridEX.RootTable.ChildTables[0].Columns[elemento].Width = 300;
                        }
                    }
                    else if (t > 1)
                    {
                        BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns.Add(nombre, Janus.Windows.GridEX.ColumnType.Text);
                        int elemento = BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns.Count - 1;
                        BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns[elemento].Caption = Datos.Tables[t].Columns[i].Caption;
                        string tipo = Datos.Tables[t].Columns[i].DataType.Name;
                        switch (tipo)
                        {
                            case "String":
                                switch (nombre)
                                {
                                    case "Descr":
                                        BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns[elemento].Width = 350;
                                        break;
                                }
                                break;
                            case "Double":
                            case "Decimal":
                                BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns[elemento].FormatMode = Janus.Windows.GridEX.FormatMode.UseIFormattable;
                                BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns[elemento].FormatString = "######,##0.00;(-######,##0.00)";
                                BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns[elemento].DefaultGroupFormatString = "######,##0.00;(-######,##0.00)";
                                BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns[elemento].TotalFormatString = "######,##0.00;(-######,##0.00)";
                                BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns[elemento].TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                                BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns[elemento].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
                                switch (nombre)
                                {
                                    case "Total Saldo":
                                        BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns[elemento].Width = 95;
                                        break;
                                    default:
                                        BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns[elemento].Width = 75;
                                        break;
                                }
                                break;
                            case "DateTime":
                                BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns[elemento].FormatMode = Janus.Windows.GridEX.FormatMode.UseIFormattable;
                                BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns[elemento].FormatString = "dd/MM/yyyy";
                                BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns[elemento].TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                                BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns[elemento].Width = 75;
                                BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Columns[elemento].Visible = true;
                                break;
                        }
                    }
                    else
                    {
                        BrowserGridEX.RootTable.Columns.Add(nombre, Janus.Windows.GridEX.ColumnType.Text);
                        int elemento = BrowserGridEX.RootTable.Columns.Count - 1;
                        BrowserGridEX.RootTable.Key = "Nivel1";
                        BrowserGridEX.RootTable.Caption = "Nivel1";
                        BrowserGridEX.RootTable.Columns[elemento].Width = 100;
                        BrowserGridEX.RootTable.Columns[elemento].Caption = Datos.Tables[t].Columns[i].Caption;
                    }
                }
            }
            BrowserGridEX.BindingContext = new BindingContext();
            BrowserGridEX.RootTable.ChildTables["Nivel2"].DataMember = "Nivel1_Nivel2";
            BrowserGridEX.RootTable.ChildTables["Nivel2"].ChildTables["Nivel3"].DataMember = "Nivel2_Nivel3";
            BrowserGridEX.RootTable.ChildTables["Nivel2"].ChildTables["Nivel4"].DataMember = "Nivel2_Nivel4";

            BrowserGridEX.RootTable.ChildTables[0].Columns[0].Visible = false;
            BrowserGridEX.RootTable.Groups.Clear();
            Janus.Windows.GridEX.GridEXGroup grupo1 = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Columns[4]);
            grupo1.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Columns[0].Visible = false;
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Columns[1].Visible = false;
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Columns[3].Visible = false;
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Columns[4].Visible = false;
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Columns[5].Visible = false;
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Groups.Add(grupo1);
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Groups[0].GroupPrefix = "";
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Groups[0].HeaderCaption = "";
            
            Janus.Windows.GridEX.GridEXSortKey s = new Janus.Windows.GridEX.GridEXSortKey();
            s.Column = BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Columns[0];
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].SortKeys.Add(s);

            Janus.Windows.GridEX.GridEXGroup grupo2 = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Columns[1]);
            grupo2.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Groups.Add(grupo2);
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Groups[1].GroupPrefix = "";
            grupo2.SortOrder = Janus.Windows.GridEX.SortOrder.Descending;

            Janus.Windows.GridEX.GridEXGroup grupo3 = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Columns[3]);
            grupo3.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Groups.Add(grupo3);
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Groups[0].GroupPrefix = "";
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Columns[0].Visible = false;
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Columns[3].Visible = false;

            //BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Columns[0].Visible = false;
            //BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Columns[1].Visible = false;
            //BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Columns[2].Visible = false;

            //if (BrowserGridEX.RootTable.ChildTables[0].ChildTables.Count > 1)
            //{
            //    BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Columns[0].Visible = false;
            //    BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Columns[1].Visible = false;
            //    BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Columns[2].Visible = false;

            //    Janus.Windows.GridEX.GridEXGroup grupo3 = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Columns[1]);
            //    grupo2.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
            //    BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Groups.Add(grupo3);
            //    BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Groups[0].GroupPrefix = "Crédito Disponible Cliente:";
            //}
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
                case "Familia-Articulo":
                    ArmaGruposUiCheckBox.Text = "Agrupa por familia de artículos";
                    break;
                case "Articulo":
                    ArmaGruposUiCheckBox.Text = "Agrupa artículo";
                    break;
            }
        }
        private void ArticulosUiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Cedeira.UI.Fun.ChequeoNodosTreeView(ArticulosTreeView.Nodes, ArticulosUiCheckBox.Checked);
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