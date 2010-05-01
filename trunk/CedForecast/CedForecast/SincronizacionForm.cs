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
            try
            {
                string cedForecastWSURL = System.Configuration.ConfigurationManager.AppSettings["CedForecastWSURL"];
                bool seChequeoAlgo = false;
                if (ArticuloCheckBox.Checked)
                {
                    ArticuloProgressBar.Visible = true;
                    ArticuloProgressBar.Visible = false;
                    seChequeoAlgo = true;
                }
                if (ClienteCheckBox.Checked)
                {
                    ClienteProgressBar.Visible = true;
                    ClienteProgressBar.Visible = false;
                    seChequeoAlgo = true;
                }
                if (CuentaCheckBox.Checked)
                {
                    CuentaProgressBar.Visible = true;
                    CuentaProgressBar.Visible = false;
                    seChequeoAlgo = true;
                }
                if (VentaCheckBox.Checked)
                {
                    VentaProgressBar.Visible = true;
                    VentaProgressBar.Visible = false;
                    seChequeoAlgo = true;
                }
                if (ZonaCheckBox.Checked)
                {
                    ZonaProgressBar.Visible = true;
                    CedForecastRN.Zona.EnviarNovedades(Aplicacion.Sesion, cedForecastWSURL);
                    ZonaProgressBar.Visible = false;
                    seChequeoAlgo = true;
                }
                if (ForecastCheckBox.Checked)
                {
                    ForecastProgressBar.Visible = true;
                    ForecastProgressBar.Visible = false;
                    seChequeoAlgo = true;
                }
                if (!seChequeoAlgo)
                {
                    MessageBox.Show("Elija el elemento que desea sincronizar", "ATENCI�N", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Sincronizaci�n conclu�da satisfactoriamente");
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
    }
}