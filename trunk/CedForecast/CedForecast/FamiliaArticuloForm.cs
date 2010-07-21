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
        CedForecastEntidades.FamiliaArticulo familia;
        string evento;

        public FamiliaArticuloForm(string Titulo) : base(Titulo)
        {
            familia = new CedForecastEntidades.FamiliaArticulo();
            evento = "Alta";
            InitializeComponent();
            BindearControles();
            IdFamiliaArticuloEditBox.Focus();
        }
        public FamiliaArticuloForm(string Titulo, string Evento, CedForecastEntidades.FamiliaArticulo Familia) : base(Titulo)
        {
            InitializeComponent();
            CedForecastRN.FamiliaArticulo accion = new CedForecastRN.FamiliaArticulo(Aplicacion.Sesion);
            accion.Leer(Familia);
            familia = Familia;
            evento = Evento;
            IdFamiliaArticuloEditBox.Text = familia.Id;
            IdFamiliaArticuloEditBox.Enabled = false;
            DescrFamiliaArticuloEditBox.Text = familia.Descr;
            BindearControles();
            switch (evento)
            {
                case "Baja":
                    InhabilitarControles();
                    AceptarUiButton.Focus();
                    break;
                case "Consulta":
                    InhabilitarControles();
                    SalirUiButton.Text = "Salir";
                    AceptarUiButton.Visible = false;
                    SalirUiButton.Focus();
                    break;
                case "Modificacion":
                    DescrFamiliaArticuloEditBox.Focus();
                    break;
            }
        }
        private void InhabilitarControles()
        {
            DescrFamiliaArticuloEditBox.Enabled = false;
            AltaUiButton.Enabled = false;
            BajaUiButton.Enabled = false;
            NuevoArticuloLabel.Enabled = false;
            NuevoArticuloMultiColumnCombo.Enabled = false;
        }
        private void BindearGrilla()
        {
            ArticulosGridEX.DataSource = null;
            ArticulosGridEX.DataSource = familia.Articulos;
            ArticulosGridEX.SelectedItems.Clear();
        }
        private void BindearControles()
        {
            BindearGrilla();
            List<CedForecastEntidades.Bejerman.Articulos> articulos = new CedForecastDB.Bejerman.Articulos(Aplicacion.Sesion).LeerLista();
            NuevoArticuloMultiColumnCombo.DataSource = articulos;
            NuevoArticuloMultiColumnCombo.DisplayMember = "Art_CodGen";
            NuevoArticuloMultiColumnCombo.ValueMember = "Art_DescGen";
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
        private void AceptarUiButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                familia.Id = IdFamiliaArticuloEditBox.Text;
                familia.Descr = DescrFamiliaArticuloEditBox.Text;
                CedForecastRN.FamiliaArticulo accion = new CedForecastRN.FamiliaArticulo(Aplicacion.Sesion);
                switch (evento)
                {
                    case "Alta":
                        accion.Crear(familia);
                        break;
                    case "Baja":
                        accion.Eliminar(familia);
                        break;
                    case "Modificacion":
                        accion.Modificar(familia);
                        break;
                    case "Consulta":
                        break;
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }
        private void AltaUiButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (NuevoArticuloMultiColumnCombo.SelectedItem == null)
                {
                    MessageBox.Show("Primero seleccione, en el combo, el Nuevo Artículo que desea agregar.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    CedForecastEntidades.Articulo nuevoArticulo = new CedForecastEntidades.Articulo();
                    nuevoArticulo.Id = NuevoArticuloMultiColumnCombo.Text;
                    nuevoArticulo.Descr = NuevoArticuloMultiColumnCombo.Value.ToString();
                    new CedForecastRN.FamiliaArticulo(Aplicacion.Sesion).AgregarArticulo(familia, nuevoArticulo);
                    BindearGrilla();
                    NuevoArticuloMultiColumnCombo.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
        private void BajaUiButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ArticulosGridEX.SelectedItems.Count > 0)
                {
                    new CedForecastRN.FamiliaArticulo(Aplicacion.Sesion).EliminarArticulo(familia, (CedForecastEntidades.Articulo)ArticulosGridEX.SelectedItems[0].GetRow().DataRow);
                    BindearGrilla();
                }
                else
                {
                    MessageBox.Show("Primero seleccione, en la grilla, el Artículo que desea eliminar.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
        private void EnviarAUiCommandManager_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            switch (e.Command.Key)
            {
                case "Impresora":
                    Cedeira.SV.Fun.ImprimirGrilla(this, ArticulosGridEX, Aplicacion.Titulo, true);
                    break;
                case "Planilla":
                    try
                    {
                        Cedeira.SV.Export planilla = new Cedeira.SV.Export();
                        Cursor = Cursors.WaitCursor;
                        planilla.ExportDetails(ArticulosGridEX, Cedeira.SV.Export.ExportFormat.Excel, "Articulos de " + familia.Descr + " " + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls");
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
    }
}