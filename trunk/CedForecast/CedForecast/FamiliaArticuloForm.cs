using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class FamiliaArticuloForm : Cedeira.UI.frmBaseEnviarA
    {
        public FamiliaArticuloForm(string Titulo) : base(Titulo)
        {
            InitializeComponent();
            ActualizarGrilla();
        }
        private void ActualizarGrilla()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                int fr;
                int cr;
                fr = ListaGridEX.FirstRow;
                cr = ListaGridEX.Row;
                Janus.Windows.GridEX.IFilterCondition fc = ListaGridEX.RootTable.FilterCondition;
                ListaGridEX.DataSource = new CedForecastDB.FamiliaArticulo(Aplicacion.Sesion).LeerLista();
                ListaGridEX.RootTable.FilterCondition = fc;
                try
                {
                    ListaGridEX.FirstRow = fr;
                }
                catch { }
                try
                {
                    ListaGridEX.Row = cr;
                }
                catch { }
                FondoNicePanel.HeaderText = tituloOriginal + " (" + ListaGridEX.RecordCount + ")";
                ListaGridEX.SelectedItems.Clear();
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

