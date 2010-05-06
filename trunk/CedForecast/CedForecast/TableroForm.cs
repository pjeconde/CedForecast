using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class TableroForm : Cedeira.UI.frmBase
    {
        public TableroForm(string Titulo) : base(Titulo)
        {
            InitializeComponent();
            VersionVerticalLabel.Text = "Versi�n " + Aplicacion.Version;
        }
        private void SalirUiButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sincronizaci�nUiButton_Click(object sender, EventArgs e)
        {
            SincronizacionBejermanCedForecastWebForm frm = new SincronizacionBejermanCedForecastWebForm(((Janus.Windows.EditControls.UIButton)sender).Text);
            frm.ShowDialog();
        }
    }
}

