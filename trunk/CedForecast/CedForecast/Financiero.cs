using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class FinancieroForm : Cedeira.UI.frmBaseEnviarA
    {
        private bool volverATabBrowser;

        public FinancieroForm(string Titulo)
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
            ClientesUiCheckBox.Checked = true;
            TipoReporte_CheckedChanged((object)ZonaClienteUiRadioButton, EventArgs.Empty);
            PeriodoDesdeCalendarCombo.Value = DateTime.Today;
            PeriodoDesdeCalendarCombo.ReadOnly = true;
        }
        private void ConfigurarFiltros()
        {
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
                if (JerarquicaUiCheckBox.Checked)
                {
                    DataSet ds = CedForecastRN.Reporte.FinancieroDs(PeriodoDesdeCalendarCombo.Value.ToString("yyyyMM"), TipoReporteNicePanel.Tag.ToString(), Cedeira.UI.Fun.ListaTreeView(ClientesTreeView), Aplicacion.Sesion, out advertencias);
                    PersonalizarGrillaDs(ds);
                    if (ds.Tables.Count != 0)
                    {
                        BrowserGridEX.DataSource = ds.Tables["Finan1"];
                    }
                    else
                    {
                        BrowserGridEX.DataSource = ds;
                    }
                }
                else
                {
                    DataTable dt = CedForecastRN.Reporte.Financiero(PeriodoDesdeCalendarCombo.Value.ToString("yyyyMM"), TipoReporteNicePanel.Tag.ToString(), Cedeira.UI.Fun.ListaTreeView(ClientesTreeView), Aplicacion.Sesion, out advertencias);
                    PersonalizarGrilla(dt);
                    BrowserGridEX.DataSource = dt;
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
            BrowserGridEX.Hierarchical = true;
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
                                BrowserGridEX.RootTable.Columns[elemento].Width = 100;
                                break;
                            case "Cliente":
                                BrowserGridEX.RootTable.Columns[elemento].Width = 250;
                                break;
                            case "Descr":
                                BrowserGridEX.RootTable.Columns[elemento].Width = 300;
                                break;
                        }
                        break;
                    case "Double":
                    case "Decimal":
                        BrowserGridEX.RootTable.Columns[elemento].FormatMode = Janus.Windows.GridEX.FormatMode.UseIFormattable;
                        BrowserGridEX.RootTable.Columns[elemento].FormatString = "######,##0.00;(-######,##0.00)";
                        BrowserGridEX.RootTable.Columns[elemento].DefaultGroupFormatString = "######,##0.00;(-######,##0.00)";
                        BrowserGridEX.RootTable.Columns[elemento].TotalFormatString = "######,##0.00;(-######,##0.00)";
                        BrowserGridEX.RootTable.Columns[elemento].TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                        BrowserGridEX.RootTable.Columns[elemento].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
                        switch (nombre)
                        {
                            case "Total Saldo":
                                BrowserGridEX.RootTable.Columns[elemento].Width = 95;
                                break;
                            default:
                                BrowserGridEX.RootTable.Columns[elemento].Width = 75;
                                break;
                        }
                        break;
                    case "DateTime":
                        BrowserGridEX.RootTable.Columns[elemento].FormatMode = Janus.Windows.GridEX.FormatMode.UseIFormattable;
                        BrowserGridEX.RootTable.Columns[elemento].FormatString = "dd/MM/yyyy";
                        BrowserGridEX.RootTable.Columns[elemento].TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                        BrowserGridEX.RootTable.Columns[elemento].Width = 75;
                        BrowserGridEX.RootTable.Columns[elemento].Visible = true;
                        break;
                    default:
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Tipo de dato " + tipo);
                }
                BrowserGridEX.RootTable.Columns[elemento].Caption = Datos.Columns[i].Caption;
            }

            //Resaltar deuda vencida.
            Janus.Windows.GridEX.GridEXFormatCondition condicional = new Janus.Windows.GridEX.GridEXFormatCondition();
            condicional.Column = BrowserGridEX.RootTable.Columns["FecVto"];
            Janus.Windows.GridEX.GridEXFilterCondition fc = new Janus.Windows.GridEX.GridEXFilterCondition();
            condicional.ConditionOperator = Janus.Windows.GridEX.ConditionOperator.LessThan;
            condicional.FormatStyle.ForeColor = System.Drawing.Color.Red;
            condicional.TargetColumn = BrowserGridEX.RootTable.Columns["Descr"];
            condicional.Value1 = PeriodoDesdeCalendarCombo.Value;
            BrowserGridEX.RootTable.FormatConditions.Add(condicional);

            //Cortes de control
            if (ArmaGruposUiCheckBox.Checked)
            {
                BrowserGridEX.Hierarchical = true;

                BrowserGridEX.RootTable.Groups.Clear();
                Janus.Windows.GridEX.GridEXGroup grupo1 = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.Columns[0]);
                grupo1.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
                BrowserGridEX.RootTable.Groups.Add(grupo1);
                BrowserGridEX.RootTable.Columns[0].Visible = false;

                Janus.Windows.GridEX.GridEXGroup grupo2 = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.Columns[1]);
                grupo2.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
                BrowserGridEX.RootTable.Groups.Add(grupo2);
                BrowserGridEX.RootTable.Columns[1].Visible = false;

                Janus.Windows.GridEX.GridEXGroup grupo3 = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.Columns[2]);
                grupo2.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
                BrowserGridEX.RootTable.Groups.Add(grupo3);
                BrowserGridEX.RootTable.Columns[2].Visible = false;
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
                    BrowserGridEX.RootTable.ChildTables[t - 1].Key = "Finan" + Convert.ToString(t + 1);
                    BrowserGridEX.RootTable.ChildTables[t - 1].Caption = "Finan" + Convert.ToString(t + 1);
                }
                else if (t > 1)
                {
                    Janus.Windows.GridEX.GridEXTable table = new Janus.Windows.GridEX.GridEXTable();
                    BrowserGridEX.RootTable.ChildTables[0].ChildTables.Add(table);
                    BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Key = "Finan" + Convert.ToString(t + 1);
                    BrowserGridEX.RootTable.ChildTables[0].ChildTables[t - 2].Caption = "Finan" + Convert.ToString(t + 1);
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
                        BrowserGridEX.RootTable.Key = "Finan1";
                        BrowserGridEX.RootTable.Caption = "Finan1";
                        BrowserGridEX.RootTable.Columns[elemento].Width = 100;
                        BrowserGridEX.RootTable.Columns[elemento].Caption = Datos.Tables[t].Columns[i].Caption;
                    }
                }
            }
            BrowserGridEX.BindingContext = new BindingContext();
            BrowserGridEX.RootTable.ChildTables["Finan2"].DataMember = "Finan1_Finan2";
            BrowserGridEX.RootTable.ChildTables["Finan2"].ChildTables["Finan3"].DataMember = "Finan2_Finan3";
            BrowserGridEX.RootTable.ChildTables["Finan2"].ChildTables["Finan4"].DataMember = "Finan2_Finan4";

            BrowserGridEX.RootTable.ChildTables[0].Columns[0].Visible = false;
            BrowserGridEX.RootTable.Groups.Clear();
            Janus.Windows.GridEX.GridEXGroup grupo1 = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Columns[1]);
            grupo1.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Groups.Add(grupo1);
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Groups[0].GroupPrefix = "Total Cliente:";
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Groups[0].HeaderCaption = "";

            Janus.Windows.GridEX.GridEXGroup grupo2 = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Columns[2]);
            grupo2.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Groups.Add(grupo2);
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Groups[1].GroupPrefix = "";
            
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Columns[0].Visible = false;
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Columns[1].Visible = false;
            BrowserGridEX.RootTable.ChildTables[0].ChildTables[0].Columns[2].Visible = false;
 
            if (BrowserGridEX.RootTable.ChildTables[0].ChildTables.Count > 1)
            {
                BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Columns[0].Visible = false;
                BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Columns[1].Visible = false;
                BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Columns[2].Visible = false;
                
                Janus.Windows.GridEX.GridEXGroup grupo3 = new Janus.Windows.GridEX.GridEXGroup(BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Columns[1]);
                grupo2.GroupInterval = Janus.Windows.GridEX.GroupInterval.Value;
                BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Groups.Add(grupo3);
                BrowserGridEX.RootTable.ChildTables[0].ChildTables[1].Groups[0].GroupPrefix = "Crédito Disponible Cliente:";
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
                        ExportDetailsDS(BrowserGridEX, Cedeira.SV.Export.ExportFormat.Excel, this.Text + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls");
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
        public void ExportDetailsDS(Janus.Windows.GridEX.GridEX Grilla, Cedeira.SV.Export.ExportFormat FormatType, string FileName)
        {
            Cedeira.SV.Export export = new Cedeira.SV.Export();
            System.Diagnostics.Process loProcess = System.Diagnostics.Process.GetCurrentProcess();
            loProcess.MaxWorkingSet = (IntPtr)10000000;
            loProcess.MinWorkingSet = (IntPtr)5000000;
            try
            {
                DataSet dsExport = Cedeira.SV.Fun.GetDataSetFromJanusGridExDS(Grilla, FileName);
                dsExport.DataSetName = "Export";
                for (int t = 0; t < dsExport.Tables.Count; t++)
                {
                    for (int i = 0; i < dsExport.Tables[t].Columns.Count; i++)
                    {
                        if (dsExport.Tables[t].Columns[i].Caption != "")
                        {
                            dsExport.Tables[t].Columns[i].ColumnName = Convert.ToString(i);
                        }
                    }
                    for (int i = 0; i < dsExport.Tables[t].Columns.Count; i++)
                    {
                        if (dsExport.Tables[t].Columns[i].Caption != "")
                        {
                            dsExport.Tables[t].Columns[i].ColumnName = export.ReemplazarEspaciosyAcentos(dsExport.Tables[t].Columns[i].Caption);
                        }
                    }
                    int columnas = dsExport.Tables[t].Columns.Count;
                    for (int l = 0; l < dsExport.Tables[t].Rows.Count; l++)
                    {
                        for (int i = 0; i < dsExport.Tables[t].Columns.Count; i++)
                        {
                            string aux = export.ReemplazarXPath(Convert.ToString(dsExport.Tables[t].Rows[l].ItemArray[i]));
                            dsExport.Tables[t].Rows[l][i] = aux;
                            dsExport.Tables[t].Rows[l].AcceptChanges();
                        }
                    }
                }
                string dir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\CedForecast\\";
                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }
                FileName = dir + export.ReemplazarCaracteresMalos(FileName);
                export.Export_with_XSLT_WindowsDS(dsExport, FormatType, FileName);
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
                case "Zona-Cliente":
                    ArmaGruposUiCheckBox.Text = "Agrupa por zona y cliente";
                    break;
            }
        }
        private void ClientesUiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Cedeira.UI.Fun.ChequeoNodosTreeView(ClientesTreeView.Nodes, ClientesUiCheckBox.Checked);
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