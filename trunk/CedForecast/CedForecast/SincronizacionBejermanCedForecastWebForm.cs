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
    public partial class SincronizacionBejermanCedForecastWebForm : Cedeira.UI.frmBase
    {
        private Thread thread;

        public SincronizacionBejermanCedForecastWebForm(string Titulo) : base(Titulo)
        {
            InitializeComponent();
            DateTime aux = DateTime.Now;
            VentaCalendarCombo.Value = aux;
        }
        private void SalirUiButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AceptarUiButton_Click(object sender, EventArgs e)
        {
            try
            {
                string cedForecastWSURL = System.Configuration.ConfigurationManager.AppSettings["CedForecastWSURL"];
                bool seChequeoAlgo = false;
                int cantidadMilisegundos = 100;
                if (ArticuloUiCheckBox.Checked)
                {
                    BarraActivar(ArticuloUIProgressBar);
                    CedForecastRN.Articulo proceso = new CedForecastRN.Articulo(Aplicacion.Sesion, cedForecastWSURL);
                    thread = new Thread(new ThreadStart(proceso.EnviarNovedades));
                    thread.Start();
                    while (true)
                    {
                        BarraActualizar(ArticuloUIProgressBar, proceso);
                        this.Refresh();
                        this.BringToFront();
                        Thread.Sleep(cantidadMilisegundos);
                        if (thread.ThreadState == ThreadState.Stopped) { break; }
                    }
                    BarraDesactivar(ArticuloUIProgressBar);
                    seChequeoAlgo = true;
                }
                if (ClienteUiCheckBox.Checked)
                {
                    BarraActivar(ClienteUiProgressBar);
                    CedForecastRN.Cliente proceso = new CedForecastRN.Cliente(Aplicacion.Sesion, cedForecastWSURL);
                    thread = new Thread(new ThreadStart(proceso.EnviarNovedades));
                    thread.Start();
                    while (true)
                    {
                        BarraActualizar(ClienteUiProgressBar, proceso);
                        this.Refresh();
                        this.BringToFront();
                        Thread.Sleep(cantidadMilisegundos);
                        if (thread.ThreadState == ThreadState.Stopped) { break; }
                    }
                    BarraDesactivar(ClienteUiProgressBar);
                    seChequeoAlgo = true;
                }
                if (CuentaUiCheckBox.Checked)
                {
                    BarraActivar(CuentaUiProgressBar);
                    CedForecastRN.Cuenta proceso = new CedForecastRN.Cuenta(Aplicacion.Sesion, cedForecastWSURL);
                    thread = new Thread(new ThreadStart(proceso.EnviarNovedades));
                    thread.Start();
                    while (true)
                    {
                        BarraActualizar(CuentaUiProgressBar, proceso);
                        this.Refresh();
                        this.BringToFront();
                        Thread.Sleep(cantidadMilisegundos);
                        if (thread.ThreadState == ThreadState.Stopped) { break; }
                    }
                    BarraDesactivar(CuentaUiProgressBar);
                    seChequeoAlgo = true;
                }
                if (VentaUiCheckBox.Checked)
                {
                    BarraActivar(VentaUiProgressBar);
                    CedForecastRN.Venta proceso = new CedForecastRN.Venta(VentaCalendarCombo.Value.ToString("yyyyMM"), Aplicacion.Sesion, cedForecastWSURL);
                    thread = new Thread(new ThreadStart(proceso.EnviarNovedades));
                    thread.Start();
                    while (true)
                    {
                        BarraActualizar(VentaUiProgressBar, proceso);
                        this.Refresh();
                        this.BringToFront();
                        Thread.Sleep(cantidadMilisegundos);
                        if (thread.ThreadState == ThreadState.Stopped) { break; }
                    }
                    BarraDesactivar(VentaUiProgressBar);
                    seChequeoAlgo = true;
                }
                if (ZonaUiCheckBox.Checked)
                {
                    BarraActivar(ZonaUiProgressBar);
                    CedForecastRN.Zona proceso = new CedForecastRN.Zona(Aplicacion.Sesion, cedForecastWSURL);
                    thread = new Thread(new ThreadStart(proceso.EnviarNovedades));
                    thread.Start();
                    while (true)
                    {
                        BarraActualizar(ZonaUiProgressBar, proceso);
                        this.Refresh();
                        this.BringToFront();
                        Thread.Sleep(cantidadMilisegundos);
                        if (thread.ThreadState == ThreadState.Stopped) { break; }
                    }
                    BarraDesactivar(ZonaUiProgressBar);
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
        private void BarraActivar(Janus.Windows.EditControls.UIProgressBar Barra)
        {
            //Barra.Visible = true;
        }
        private void BarraActualizar(Janus.Windows.EditControls.UIProgressBar Barra, CedForecastRN.Proceso Objeto)
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
        private void BarraDesactivar(Janus.Windows.EditControls.UIProgressBar Barra)
        {
            //Barra.Value = 0;
            //Barra.Visible = false;
        }
    }
}

