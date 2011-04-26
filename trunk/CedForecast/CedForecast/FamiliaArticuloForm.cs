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
        }
        private void MaximizarUiButton_Click(object sender, EventArgs e)
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
                if (ex.InnerException != null && ex.InnerException.Message.Substring(0, 60) == "Instrucción DELETE en conflicto con la restricción REFERENCE")
                {
                    MessageBox.Show("Esta Familia todavía tiene Artículos asociados.  Asocie estos Artículos a otra Familia, antes de volver a intentar eliminarla.", "ADVERTENCIA");
                }
                else
                {
                    Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
                }
            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }
    }
}