using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class CedForecastForm : Form
    {
        public CedForecastForm(string Titulo)
        {
            this.Text = Titulo;
            InitializeComponent();
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void sincronizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SincronizacionForm form = new SincronizacionForm();
            form.ShowDialog();
        }
    }
}