using System;
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
        private int CantidadControlesFijos;
        private int BotonesBase = 32;
        private enum IconoEnum
        {
            Aceptar,
            Consultar,
            Rechazar,
            Modificar,
            Eliminar,
            SinDefinir
        }
		public OrdenCompraBrowserForm(BrowserModoEnum Modo)
		{
			InitializeComponent();
            ////Cargo ImageList                                                                                                                         
            //iconos = new ImageList();
            //iconos.ImageSize = new Size(16, 16);
            //iconos.ColorDepth = ColorDepth.Depth8Bit;

            //System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            ////ordeno por nombre de archivo para cargar en orden
            //string[] resNames = a.GetManifestResourceNames();
            //int i = 0;
            //int j = 0;
            //while (i < resNames.Length)
            //{
            //    j = i + 1;
            //    while (j < resNames.Length)
            //    {
            //        if (String.CompareOrdinal(resNames[i], resNames[j]) > 0)
            //        {
            //            string auxnom;
            //            auxnom = resNames[j];
            //            resNames[j] = resNames[i];
            //            resNames[i] = auxnom;
            //        }
            //        j++;
            //    }
            //    i++;
            //}
            //foreach (string s in resNames)
            //{
            //    int auxIndex = s.IndexOf("PrecioBrowserForm");
            //    if (s.EndsWith("ico") && auxIndex > 0)
            //    {
            //        iconos.Images.Add(new System.Drawing.Icon(a.GetManifestResourceStream(@s)));
            //    }
            //}
            modo = Modo;
            CantidadControlesFijos = HerramientasUiPanelContainer.Controls.Count;
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
            EstadoUiCheckBox.Checked = true;
            ActualizarBrowserGrid(EjecutarSeleccionUiButton, System.EventArgs.Empty);
        }
        public OrdenCompraBrowserForm()
		{
			InitializeComponent();
		}
        private void ConfigurarFiltros()
        {
            FechaDsdCalendarCombo.Value = DateTime.Now;
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
        //private void EstadoUiCheckBox_CheckedChanged(object sender, System.EventArgs e)
        //{
        //    Cedeira.UI.Fun.ChequeoNodosTreeView(EstadoTreeView, EstadoUiCheckBox.Checked);
        //}
        //private void MonedaUiCheckBox_CheckedChanged(object sender, System.EventArgs e)
        //{
        //    Cedeira.UI.Fun.ChequeoNodosTreeView(EspecieTreeView, MonedaUiCheckBox.Checked);
        //}
        //private void BrowserGridEX_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        //{
        //    for (int i = CantidadControlesFijos; i < HerramientasUiPanelContainer.Controls.Count; i++)
        //    {
        //        if (((Janus.Windows.EditControls.UIButton)HerramientasUiPanelContainer.Controls[i]).Tag.ToString() == "Consulta")
        //        {
        //            BotonEventoClick(HerramientasUiPanelContainer.Controls[i], System.EventArgs.Empty);
        //            return;
        //        }
        //    }
        //}
        //private void BrowserGridEX_SelectionChanged(object sender, System.EventArgs e)
        //{
        //    if (BrowserGridEX.SelectedItems.Count > 0 && !(BrowserGridEX.FilterMode == Janus.Windows.GridEX.FilterMode.Automatic && BrowserGridEX.SelectedItems[0].Position == -2))
        //    {
        //        try
        //        {
        //            Cursor = Cursors.Default;
        //            EliminarBotonesConfigurables();
        //            if (BrowserGridEX.SelectedItems.Count == 1)
        //            {
        //                // Creo botones nuevos
        //                Precio precio = new Precio(Convert.ToDateTime(BrowserGridEX.SelectedItems[0].GetRow().Cells["Fecha"].Value), Convert.ToInt32(BrowserGridEX.SelectedItems[0].GetRow().Cells["IdEspecie"].Value), Aplicacion.Sesion, "Consulta");
        //                DataTable dt = precio.EventosPosibles;
        //                int Orden = 0;
        //                for (int i = 0; i < dt.Rows.Count; i++)
        //                {
        //                    if (!Convert.ToBoolean(dt.Rows[i]["Automatico"]))
        //                    {
        //                        CrearBotonEvento(dt.Rows[i]["TextoAccion"].ToString(), dt.Rows[i]["IdEvento"].ToString(), Orden++, false);
        //                    }
        //                }
        //                CrearBotonEvento("Consultar", "Consulta", Orden++, false);
        //            }
        //            else
        //            {
        //                ConfigBotonesEventosXLote();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Cedeira.Ex.ExceptionManager.Publish(ex);
        //        }
        //        finally
        //        {
        //            Cursor = Cursors.Default;
        //        }
        //    }
        //}
        //private void CrearBotonEvento(string TextoAccion, string IdEvento, int Orden, bool XLote)
        //{
        //    Janus.Windows.EditControls.UIButton boton = new Janus.Windows.EditControls.UIButton();
        //    boton.UseThemes = false;
        //    boton.Location = new Point(8, BotonesBase + Orden * 24);
        //    boton.Text = TextoAccion;
        //    boton.Tag = IdEvento;
        //    boton.Size = AltaUiButton.Size;
        //    boton.Appearance = AltaUiButton.Appearance;
        //    boton.FlatBorderColor = AltaUiButton.FlatBorderColor;
        //    switch (TextoAccion)
        //    {
        //        case "Autorizar":
        //            boton.Icon = Icon.FromHandle(((Bitmap)iconos.Images[Convert.ToInt32(IconoEnum.Aceptar)]).GetHicon());
        //            if (modo == BrowserModoEnum.Ingreso || modo == BrowserModoEnum.Consulta)
        //            {
        //                boton.Enabled = false;
        //            }
        //            break;
        //        case "Consultar":
        //            boton.Icon = Icon.FromHandle(((Bitmap)iconos.Images[Convert.ToInt32(IconoEnum.Consultar)]).GetHicon());
        //            break;
        //        case "Solicitar reingreso":
        //        case "Rechazar":
        //            boton.Icon = Icon.FromHandle(((Bitmap)iconos.Images[Convert.ToInt32(IconoEnum.Rechazar)]).GetHicon());
        //            if (modo == BrowserModoEnum.Ingreso || modo == BrowserModoEnum.Consulta)
        //            {
        //                boton.Enabled = false;
        //            }
        //            break;
        //        case "Eliminar":
        //            boton.Icon = Icon.FromHandle(((Bitmap)iconos.Images[Convert.ToInt32(IconoEnum.Eliminar)]).GetHicon());
        //            if (modo == BrowserModoEnum.Ingreso || modo == BrowserModoEnum.Consulta)
        //            {
        //                boton.Enabled = false;
        //            }
        //            break;
        //        case "Ingresar":
        //            boton.Icon = Icon.FromHandle(((Bitmap)iconos.Images[Convert.ToInt32(IconoEnum.Modificar)]).GetHicon());
        //            if (modo == BrowserModoEnum.Autorizacion || modo == BrowserModoEnum.Consulta)
        //            {
        //                boton.Enabled = false;
        //            }
        //            break;
        //    }
        //    boton.ShowFocusRectangle = AltaUiButton.ShowFocusRectangle;
        //    if (!XLote)
        //    {
        //        boton.StateStyles.FormatStyle.BackColor = AltaUiButton.StateStyles.FormatStyle.BackColor;
        //    }
        //    else
        //    {
        //        boton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Gold;
        //        boton.AccessibleDescription = "XLote";
        //    }
        //    boton.TextHorizontalAlignment = AltaUiButton.TextHorizontalAlignment;
        //    boton.Click += new System.EventHandler(this.BotonEventoClick);
        //    HerramientasUiPanelContainer.Controls.Add(boton);
        //}
        //private void BotonEventoClick(object sender, System.EventArgs e)
        //{
        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        Precio objeto;
        //        PrecioForm oFrm;
        //        string idEvento = ((Janus.Windows.EditControls.UIButton)sender).Tag.ToString();
        //        if (((Janus.Windows.EditControls.UIButton)sender).Name == "AltaUiButton")
        //        {
        //            objeto = new Precio("Alta", Aplicacion.Sesion);
        //            oFrm = new PrecioForm(objeto, (Janus.Windows.EditControls.UIButton)sender);
        //            Cursor = Cursors.Default;
        //            oFrm.ShowDialog();
        //        }
        //        else if (BrowserGridEX.SelectedItems.Count == 1 && !(BrowserGridEX.FilterMode == Janus.Windows.GridEX.FilterMode.Automatic && BrowserGridEX.SelectedItems[0].Position == -2))
        //        {
        //            objeto = new Precio(
        //                Convert.ToDateTime(BrowserGridEX.SelectedItems[0].GetRow().Cells["Fecha"].Value),
        //                Convert.ToInt32(BrowserGridEX.SelectedItems[0].GetRow().Cells["IdEspecie"].Value),
        //                Aplicacion.Sesion,
        //                idEvento);
        //            oFrm = new PrecioForm(objeto, (Janus.Windows.EditControls.UIButton)sender);
        //            Cursor = Cursors.Default;
        //            oFrm.ShowDialog();
        //        }
        //        else if (Convert.ToString(((Janus.Windows.EditControls.UIButton)sender).AccessibleDescription) == "XLote" && BrowserGridEX.SelectedItems.Count > 1 && !(BrowserGridEX.FilterMode == Janus.Windows.GridEX.FilterMode.Automatic && BrowserGridEX.SelectedItems[0].Position == -2))
        //        {
        //            string comentario = String.Empty;
        //            if (idEvento != "Autoriz")
        //            {
        //                ComentarioForm oFrmC = new ComentarioForm();
        //                Cursor = Cursors.Default;
        //                if (oFrmC.ShowDialog() == DialogResult.Cancel)
        //                {
        //                    return;
        //                }
        //                else
        //                {
        //                    comentario = oFrmC.Comentario;
        //                }
        //            }
        //            Cursor = Cursors.WaitCursor;
        //            for (int i = 0; i < BrowserGridEX.SelectedItems.Count; i++)
        //            {
        //                objeto = new Precio(Convert.ToDateTime(BrowserGridEX.SelectedItems[i].GetRow().Cells["Fecha"].Value), Convert.ToInt32(BrowserGridEX.SelectedItems[i].GetRow().Cells["IdEspecie"].Value), Aplicacion.Sesion, idEvento);
        //                objeto.PropiedadesBindeadas = false;
        //                try
        //                {
        //                    objeto.Comentario = comentario;
        //                    objeto.EjecutarEvento();
        //                }
        //                catch (Cedeira.Ex.Validaciones.FCIs.Revaluo.EnProceso ex)
        //                {
        //                    throw ex;
        //                }
        //                catch (Exception ex)
        //                {
        //                    Cedeira.Ex.ExceptionManager.Publish(ex);
        //                }
        //            }
        //            Cursor = Cursors.Default;
        //            EliminarBotonesConfigurables();
        //        }
        //        else
        //        {
        //            Cursor = Cursors.Default;
        //            return;
        //        }
        //        Cursor = Cursors.Default;
        //        ActualizarBrowserGrid(EjecutarSeleccionUiButton, System.EventArgs.Empty);
        //    }
        //    catch (Exception ex)
        //    {
        //        Cedeira.Ex.ExceptionManager.Publish(ex);
        //    }
        //    finally
        //    {
        //        Cursor = Cursors.Default;
        //    }
        //}
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
                BrowserGridEX.DataSource = CedForecastRN.OrdenCompra.LeerLista(FechaDsdCalendarCombo.Value, FechaHstCalendarCombo.Value, Cedeira.UI.Fun.ListaTreeView(EstadoTreeView), Aplicacion.Sesion);
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

        //private void BrowserGridEX_CellUpdated(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        //{
        //    try
        //    {
        //        Precio precio = new Precio(Convert.ToDateTime(BrowserGridEX.SelectedItems[0].GetRow().Cells["Fecha"].Value), Convert.ToInt32(BrowserGridEX.SelectedItems[0].GetRow().Cells["IdEspecie"].Value), Aplicacion.Sesion, CedADM.Precio.Evento.Ingreso);
        //        precio.PropiedadesBindeadas = false;
        //        precio.PrecioCierre = Convert.ToDecimal(BrowserGridEX.SelectedItems[0].GetRow().Cells["PrecioCierre"].Value);
        //        precio.EjecutarEvento();
        //    }
        //    catch (Exception ex)
        //    {
        //        Cedeira.Ex.ExceptionManager.Publish(ex);
        //        BrowserGridEX.CancelCurrentEdit();
        //    }
        //    finally
        //    {
        //        ActualizarBrowserGrid(EjecutarSeleccionUiButton, System.EventArgs.Empty);
        //    }
        //}
        //private void BrowserUiTab_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        //{
        //    if (BrowserUiTab.SelectedTab == TabFiltroUiTabPage)
        //    {
        //        TabBrowserUiTabPage.TabVisible = false;
        //    }
        //}
        //private void CancelarUiButton_Click(object sender, System.EventArgs e)
        //{
        //    TabBrowserUiTabPage.TabVisible = true;
        //    BrowserUiTab.SelectedTab = TabBrowserUiTabPage;
        //}
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
        //private void IncorporarPtesIngUiButton_Click(object sender, System.EventArgs e)
        //{
        //    Cursor = Cursors.WaitCursor;
        //    Precios p = new Precios(Aplicacion.Sesion);
        //    p.Inicializar();
        //    ActualizarBrowserGrid(EjecutarSeleccionUiButton, System.EventArgs.Empty);
        //    Cursor = Cursors.Default;
        //}
        //private void ConfigBotonesEventosXLote()
        //{
        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        // Determinacion de eventos (XLote) comunes a todas las operaciones seleccionadas
        //        DataTable eventosXLote = null;
        //        for (int i = 0; i < BrowserGridEX.SelectedItems.Count; i++)
        //        {
        //            Precio precio = new Precio(Convert.ToDateTime(BrowserGridEX.SelectedItems[i].GetRow().Cells["Fecha"].Value), Convert.ToInt32(BrowserGridEX.SelectedItems[i].GetRow().Cells["IdEspecie"].Value), Aplicacion.Sesion, "Consulta");
        //            if (i == 0)
        //            {
        //                eventosXLote = precio.EventosXLotePosibles;
        //                for (int k = 0; k < eventosXLote.Rows.Count; k++)
        //                {
        //                    string idEventoXLote = Convert.ToString(eventosXLote.Rows[k]["IdEvento"]);
        //                    if (!precio.IntervencionPermitida(idEventoXLote))
        //                    {
        //                        eventosXLote.Rows[k].Delete();
        //                    }
        //                }
        //                eventosXLote.AcceptChanges();
        //            }
        //            else
        //            {
        //                DataTable eventosXLoteCHK = precio.EventosXLotePosibles;
        //                for (int k = 0; k < eventosXLote.Rows.Count; k++)
        //                {
        //                    string idEventoXLote = Convert.ToString(eventosXLote.Rows[k]["IdEvento"]);
        //                    if (eventosXLoteCHK.Select("IdEvento='" + idEventoXLote + "'").Length == 0 && !precio.IntervencionPermitida(idEventoXLote))
        //                    {
        //                        eventosXLote.Rows[k].Delete();
        //                    }
        //                }
        //            }
        //        }
        //        eventosXLote.AcceptChanges();
        //        // Botones X Lote
        //        if (eventosXLote != null && eventosXLote.Rows.Count != 0)
        //        {
        //            int CantBotones = eventosXLote.Rows.Count;
        //            for (int i = 1; i <= CantBotones; i++)
        //            {
        //                CrearBotonEvento(Convert.ToString(eventosXLote.Rows[i - 1]["TextoAccion"]), Convert.ToString(eventosXLote.Rows[i - 1]["IdEvento"]), i - 1, true);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Cedeira.Ex.ExceptionManager.Publish(ex);
        //    }
        //    finally
        //    {
        //        Cursor = System.Windows.Forms.Cursors.Default;
        //    }
        //}
        //private void EliminarBotonesConfigurables()
        //{
        //    while (HerramientasUiPanelContainer.Controls.Count > CantidadControlesFijos)
        //    {
        //        HerramientasUiPanelContainer.Controls.Remove(HerramientasUiPanelContainer.Controls[CantidadControlesFijos]);
        //    }
        //}
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
    }
}