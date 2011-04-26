using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class TablaForm : Cedeira.UI.frmBaseEnviarA
    {
        string tabla;
        CedForecastEntidades.Codigo codigo;
        string evento;

        public TablaForm(string Tabla, string Titulo) : base(Titulo)
        {
            tabla = Tabla;
            codigo = new CedForecastEntidades.Codigo();
            evento = "Alta";
            InitializeComponent();
        }
        public TablaForm(string Tabla, string Titulo, string Evento, CedForecastEntidades.Codigo Codigo) : base(Titulo)
        {
            tabla = Tabla;
            codigo = Codigo;
            evento = Evento;
            InitializeComponent();
            LlenarCampos();
            InhabilitarCampos();
            switch (evento)
            {
                case "Baja":
                    AceptarUiButton.Focus();
                    break;
                case "Consulta":
                    SalirUiButton.Text = "Salir";
                    AceptarUiButton.Visible = false;
                    SalirUiButton.Focus();
                    break;
                case "Modificacion":
                    DescrEditBox.Focus();
                    break;
            }
        }
        private void LlenarCampos()
        {
            IdEditBox.Text = codigo.Id;
            DescrEditBox.Text = codigo.Descr;
        }
        private void InhabilitarCampos()
        {
            IdEditBox.Enabled = false;
            if (evento != "Modificacion")
            {
                DescrEditBox.Enabled = false;
            }
        }
        private void AceptarUiButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                switch (evento)
                {
                    case "Alta":
                    case "Modificacion":
                        codigo.Descr = DescrEditBox.Text;
                        if (evento == "Alta")
                        {
                            codigo.Id = IdEditBox.Text;
                            CedForecastRN.Tabla.Crear(tabla, codigo, Aplicacion.Sesion);
                        }
                        else
                        {
                            CedForecastRN.Tabla.Modificar(tabla, codigo, Aplicacion.Sesion);
                        }
                        break;
                    case "Baja":
                        CedForecastRN.Tabla.Eliminar(tabla, codigo, Aplicacion.Sesion);
                        break;
                    default:
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
    }
}