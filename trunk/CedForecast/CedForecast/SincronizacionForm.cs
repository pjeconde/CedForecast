using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CedForecast
{
    public partial class SincronizacionForm : Form
    {
        private Thread thread;

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
                    BarraActivar(ClienteProgressBar);
                    CedForecastRN.Cliente proceso = new CedForecastRN.Cliente(Aplicacion.Sesion, cedForecastWSURL);
                    thread = new Thread(new ThreadStart(proceso.EnviarNovedades));
                    thread.Start();
                    while (true)
                    {
                        BarraActualizar(ClienteProgressBar, proceso);
                        this.Refresh();
                        this.BringToFront();
                        Thread.Sleep(1000);
                        if (thread.ThreadState == ThreadState.Stopped) { break; }
                    }
                    BarraDesactivar(ClienteProgressBar);
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
                    BarraActivar(ZonaProgressBar);
                    CedForecastRN.Zona proceso = new CedForecastRN.Zona(Aplicacion.Sesion, cedForecastWSURL);
                    thread = new Thread(new ThreadStart(proceso.EnviarNovedades));
                    thread.Start();
                    while (true)
                    {
                        BarraActualizar(ZonaProgressBar, proceso);
                        this.Refresh();
                        this.BringToFront();
                        Thread.Sleep(1000);
                        if (thread.ThreadState == ThreadState.Stopped) { break; }
                    }
                    BarraDesactivar(ZonaProgressBar);
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
                    MessageBox.Show("Elija el elemento que desea sincronizar", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Sincronización concluída satisfactoriamente");
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
        private void BarraActivar(ProgressBar Barra)
        {
            Barra.Visible = true;
        }
        private void BarraActualizar(ProgressBar Barra, CedForecastRN.Proceso Objeto)
        {
            try
            {
                Barra.Maximum = Objeto.ContadorTope;
                Barra.Value = Objeto.Contador;
            }
            catch
            {
            }
        }
        private void BarraDesactivar(ProgressBar Barra)
        {
            Barra.Value = 0;
            Barra.Visible = false;
        }
    }
}