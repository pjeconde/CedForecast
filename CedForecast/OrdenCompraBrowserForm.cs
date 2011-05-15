using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class OrdenCompraBrowserForm : Cedeira.UI.frmBaseEnviarA
    {
        private string titulo = "Explorador de Órdenes de Compra";
        private BrowserModoEnum modo;

        public OrdenCompraBrowserForm(BrowserModoEnum Modo)
		{
			InitializeComponent();
            modo = Modo;
            TabBrowserUiTabPage.StateStyles.FormatStyle.BackColor = Color.PeachPuff;
            TabFiltroUiTabPage.StateStyles.FormatStyle.BackColor = Color.Cornsilk;
            ConfigurarFiltros();
            if (modo == BrowserModoEnum.Consulta)
            {
                titulo += " - Modo Consulta";
                AltaUiButton.Enabled = false;
            }
            Text = titulo;
            FondoNicePanel.HeaderText = titulo;
            ActualizarBrowserGrid(EjecutarSeleccionUiButton, System.EventArgs.Empty);
        }
        public OrdenCompraBrowserForm()
		{
			InitializeComponent();
		}
        private void ConfigurarFiltros()
        {
            FechaDsdCalendarCombo.Value = new DateTime(2011, 1, 1);
            FechaHstCalendarCombo.Value = DateTime.Now;

            CedEntidades.WF wf = new CedEntidades.WF();
            wf.IdFlow = "OrdenCpra";
            List<CedEntidades.Estado> estados = Cedeira.SV.WF.IdEstadoXFlowCombo(wf, Aplicacion.Sesion);
            for (int i = 0; i < estados.Count; i++)
            {
                TreeNode nd = new TreeNode(Convert.ToString(estados[i].DescrEstado));
                nd.Tag = estados[i].IdEstado;
                if (!estados[i].Final) nd.Checked = true;
                EstadoTreeView.Nodes.Add(nd);
            }
        }
        private void EstadoUiCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Cedeira.UI.Fun.ChequeoNodosTreeView(EstadoTreeView.Nodes, EstadoUiCheckBox.Checked);
        }
        private void BrowserGridEX_SelectionChanged(object sender, System.EventArgs e)
        {
            DeshabilitarBotones();
            if (BrowserGridEX.SelectedItems.Count > 0)
            {
                try
                {
                    Cursor = Cursors.Default;
                    CedForecastEntidades.OrdenCompra ordenCompra;
                    if (BrowserGridEX.SelectedItems.Count == 1)
                    {
                        ordenCompra = ((List<CedForecastEntidades.OrdenCompra>)BrowserGridEX.Tag)[BrowserGridEX.SelectedItems[0].Position];
                        for (int j = 0; j < ordenCompra.WF.EventosXLotePosibles.Count; j++)
                        {
                            HabilitarBoton(ordenCompra.WF.EventosXLotePosibles[j].Id, false);
                        }
                    }
                    else
                    {
                        List<EventoReferencia> eventosPosiblesEnComun = new List<EventoReferencia>();
                        List<CedEntidades.Evento> eventos = Cedeira.SV.WF.EventosXLote("OrdenCpra", Aplicacion.Sesion);
                        for (int i = 0; i < eventos.Count; i++)
                        {
                            eventosPosiblesEnComun.Add(new EventoReferencia(eventos[i]));
                        }
                        for (int i = 0; i < BrowserGridEX.SelectedItems.Count; i++)
                        {
                            ordenCompra = ((List<CedForecastEntidades.OrdenCompra>)BrowserGridEX.Tag)[BrowserGridEX.SelectedItems[i].Position];
                            for (int j = 0; j < ordenCompra.WF.EventosXLotePosibles.Count; j++)
                            {
                                EventoReferencia eventoPosibleEnComun = eventosPosiblesEnComun.Find(delegate(EventoReferencia r) { return r.Evento.Id == ordenCompra.WF.EventosXLotePosibles[j].Id; });
                                eventoPosibleEnComun.Cantidad++;
                            }
                        }
                        for (int i = 0; i < eventosPosiblesEnComun.Count; i++)
                        {
                            if (eventosPosiblesEnComun[i].Cantidad == BrowserGridEX.SelectedItems.Count)
                            {
                                HabilitarBoton(eventosPosiblesEnComun[i].Evento.Id, true);
                            }
                        }
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
        }
        private void HabilitarBoton(string IdEvento, bool XLote)
        {
            switch (IdEvento)
            {
                case "IngInfoEmb":
                    IngInfoEmbUiButton.Enabled = true;
                    if (XLote) IngInfoEmbUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Gold;
                    break;
                case "RecepDocs":
                    RecepDocsUiButton.Enabled = true;
                    if (XLote) RecepDocsUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Gold;
                    break;
                case "RegDesp":
                    RegDespUiButton.Enabled = true;
                    if (XLote) RegDespUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Gold;
                    break;
                case "InspRenar":
                    InspRenarUiButton.Enabled = true;
                    if (XLote) InspRenarUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Gold;
                    break;
                case "IngrADep":
                    IngrADepUiButton.Enabled = true;
                    if (XLote) IngrADepUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Gold;
                    break;
                case "Anul":
                    AnulacionUiButton.Enabled = true;
                    if (XLote) AnulacionUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Gold;
                    break;
                default:
                    break;
            }
        }
        private void DeshabilitarBotones()
        {
            IngInfoEmbUiButton.Enabled = false; 
            RecepDocsUiButton.Enabled = false;
            RegDespUiButton.Enabled = false;
            InspRenarUiButton.Enabled = false;
            IngrADepUiButton.Enabled = false;
            AnulacionUiButton.Enabled = false;

            IngInfoEmbUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            RecepDocsUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            RegDespUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            InspRenarUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            IngrADepUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            AnulacionUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
        }
        private void ActualizarBrowserGrid(object sender, System.EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                this.Refresh();
                if (FechaDsdCalendarCombo.Value > FechaHstCalendarCombo.Value)
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Fechas.FechaDsdMayorAHst();
                }
                int fr;
                int cr;
                fr = BrowserGridEX.FirstRow;
                cr = BrowserGridEX.Row;
                Janus.Windows.GridEX.IFilterCondition fc = BrowserGridEX.RootTable.FilterCondition;
                List<CedForecastEntidades.OrdenCompra> lista = CedForecastRN.OrdenCompra.LeerLista(FechaDsdCalendarCombo.Value, FechaHstCalendarCombo.Value, Cedeira.UI.Fun.ListaTreeView(EstadoTreeView), Aplicacion.Sesion);
                BrowserGridEX.Tag = lista;
                BrowserGridEX.DataSource = lista;
                BrowserGridEX.RootTable.FilterCondition = fc;
                try
                {
                    BrowserGridEX.FirstRow = fr;
                }
                catch { }
                try
                {
                    BrowserGridEX.Row = cr;
                }
                catch { }
                FondoNicePanel.HeaderText = titulo + " (" + BrowserGridEX.RecordCount + ")";
                if (BrowserGridEX.RecordCount > 0)
                {
                    BrowserGridEX.SelectedItems.Clear();
                    BrowserGridEX.SelectedItems.Add(0);
                }
                TabBrowserUiTabPage.TabVisible = true;
                BrowserUiTab.SelectedTab = TabBrowserUiTabPage;
                BrowserGridEX.HorizontalScrollPosition = 0;
                BrowserGridEX.VerticalScrollPosition = 0;
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
        private void CancelarUiButton_Click(object sender, EventArgs e)
        {
            TabBrowserUiTabPage.TabVisible = true;
            BrowserUiTab.SelectedTab = TabBrowserUiTabPage;
        }
        private void AltaUiButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            System.Windows.Forms.Form oFrm = new OrdenCompraAltaForm();
            oFrm.ShowDialog();
            ActualizarBrowserGrid(EjecutarSeleccionUiButton, System.EventArgs.Empty);
            Cursor = Cursors.Default;
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
                    Cedeira.SV.Fun.ImprimirGrilla(this, BrowserGridEX, Aplicacion.Titulo, false);
                    break;
                case "Planilla":
                    try
                    {
                        Cedeira.SV.Export exc = new Cedeira.SV.Export();
                        Cursor = Cursors.WaitCursor;
                        exc.ExportDetails(BrowserGridEX, Cedeira.SV.Export.ExportFormat.Excel, titulo + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls");
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
        private void IngInfoEmbUiButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            System.Windows.Forms.Form oFrm = new OrdenCompraIngresoInfoEmbarqueForm(OrdenesCompraSeleccionadas());
            oFrm.ShowDialog();
            ActualizarBrowserGrid(EjecutarSeleccionUiButton, System.EventArgs.Empty);
            Cursor = Cursors.Default;
        }
        private void RecepDocsUiButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            System.Windows.Forms.Form oFrm = new OrdenCompraRecepcionDocumentosForm(OrdenesCompraSeleccionadas());
            oFrm.ShowDialog();
            ActualizarBrowserGrid(EjecutarSeleccionUiButton, System.EventArgs.Empty);
            Cursor = Cursors.Default;
        }
        private void RegDespUiButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            System.Windows.Forms.Form oFrm = new OrdenCompraRegistroDespachoForm(OrdenesCompraSeleccionadas());
            oFrm.ShowDialog();
            ActualizarBrowserGrid(EjecutarSeleccionUiButton, System.EventArgs.Empty);
            Cursor = Cursors.Default;
        }
        private void InspRenarUiButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            System.Windows.Forms.Form oFrm = new OrdenCompraInspeccionRENARForm(OrdenesCompraSeleccionadas());
            oFrm.ShowDialog();
            ActualizarBrowserGrid(EjecutarSeleccionUiButton, System.EventArgs.Empty);
            Cursor = Cursors.Default;
        }
        private void IngrADepUiButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            System.Windows.Forms.Form oFrm = new OrdenCompraIngresoADepositoForm(OrdenesCompraSeleccionadas());
            oFrm.ShowDialog();
            ActualizarBrowserGrid(EjecutarSeleccionUiButton, System.EventArgs.Empty);
            Cursor = Cursors.Default;
        }
        private void AnulacionUiButton_Click(object sender, EventArgs e)
        {
            if (BrowserGridEX.SelectedItems.Count > 0 && MessageBox.Show("Confirma la anulación ?", "IMPORTANTE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                CedForecastRN.OrdenCompra.Anulacion(OrdenesCompraSeleccionadas(), Aplicacion.Sesion);
                ActualizarBrowserGrid(EjecutarSeleccionUiButton, System.EventArgs.Empty);
                Cursor = Cursors.Default;
            }
        }
        private List<CedForecastEntidades.OrdenCompra> OrdenesCompraSeleccionadas()
        {
            List<CedForecastEntidades.OrdenCompra> ordenesCompraSeleccionadas = new List<CedForecastEntidades.OrdenCompra>();
            for (int i = 0; i < BrowserGridEX.SelectedItems.Count; i++)
            {
                ordenesCompraSeleccionadas.Add(((List<CedForecastEntidades.OrdenCompra>)BrowserGridEX.Tag)[BrowserGridEX.SelectedItems[i].Position]);
            }
            return ordenesCompraSeleccionadas;
        }
    }
    public class EventoReferencia
    {
        protected CedEntidades.Evento evento;
        protected int cantidad;

        public EventoReferencia(CedEntidades.Evento Evento)
        {
            evento = Evento;
        }

        public CedEntidades.Evento Evento
        {
            set
            {
                evento = value;
            }
            get
            {
                return evento;
            }
        }
        public int Cantidad
        {
            set
            {
                cantidad = value;
            }
            get
            {
                return cantidad;
            }
        }
    }
}