using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class SincronizacionForm : Form
    {
        public SincronizacionForm()
        {
            InitializeComponent();
        }

        private void SincronizarButton_Click(object sender, EventArgs e)
        {
            bool seChequeoAlgo = false;
            //WS.Sincronizacion ws = new CedForecast.WS.Sincronizacion();
            //ws.Url = "http://localhost:3000/Sincronizacion.asmx";
            if (ArticuloCheckBox.Checked)
            {
                //List<WS.Articulo> lista = new List<CedForecast.WS.Articulo>();
                //ws.EnviarArticulos(lista);
                seChequeoAlgo = true;
            }
            if (ClienteCheckBox.Checked)
            {
                seChequeoAlgo = true;
            }
            if (CuentaCheckBox.Checked)
            {
                seChequeoAlgo = true;
            }
            if (VentaCheckBox.Checked)
            {
                seChequeoAlgo = true;
            }
            if ( ZonaCheckBox.Checked)
            {
                seChequeoAlgo = true;
            }
            if (ForecastCheckBox.Checked)
            {
                seChequeoAlgo = true;
            }
            if (!seChequeoAlgo)
            {
                MessageBox.Show("Elija el elemento que desea sincronizar", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Sincronización concluída satisfactoriamente");
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}