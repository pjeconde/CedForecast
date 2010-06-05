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
    public partial class SincronizacionForm : Cedeira.UI.frmBase
    {
        private Thread thread;

        public SincronizacionForm(string Titulo) : base(Titulo)
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
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
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
                if (ProyeccionAnualUiCheckBox.Checked)
                {
                    BarraActivar(ProyeccionAnualUiProgressBar);
                    CedForecastRN.ProyeccionAnual proceso = new CedForecastRN.ProyeccionAnual(Aplicacion.Sesion, cedForecastWSURL, ProyeccionAnualCalendarCombo.Value.Year.ToString());
                    thread = new Thread(new ThreadStart(proceso.RecibirNovedades));
                    thread.Start();
                    while (true)
                    {
                        BarraActualizar(ProyeccionAnualUiProgressBar, proceso);
                        this.Refresh();
                        this.BringToFront();
                        Thread.Sleep(cantidadMilisegundos);
                        if (thread.ThreadState == ThreadState.Stopped) { break; }
                    } 
                    BarraDesactivar(ProyeccionAnualUiProgressBar);
                    seChequeoAlgo = true;
                }
                if (RollingForecastUiCheckBox.Checked)
                {
                    BarraActivar(RollingForecastUiProgressBar);
                    CedForecastRN.RollingForecast proceso = new CedForecastRN.RollingForecast(Aplicacion.Sesion, cedForecastWSURL, RollingForecastCalendarCombo.Value.ToString("yyyyMM"));
                    thread = new Thread(new ThreadStart(proceso.RecibirNovedades));
                    thread.Start();
                    while (true)
                    {
                        BarraActualizar(RollingForecastUiProgressBar, proceso);
                        this.Refresh();
                        this.BringToFront();
                        Thread.Sleep(cantidadMilisegundos);
                        if (thread.ThreadState == ThreadState.Stopped) { break; }
                    }
                    BarraDesactivar(RollingForecastUiProgressBar);
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
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default;
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
        private void EnviarTodoUiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ArticuloUiCheckBox.Checked = EnviarTodoUiCheckBox.Checked;
            ClienteUiCheckBox.Checked = EnviarTodoUiCheckBox.Checked;
            CuentaUiCheckBox.Checked = EnviarTodoUiCheckBox.Checked;
            VentaUiCheckBox.Checked = EnviarTodoUiCheckBox.Checked;
            ZonaUiCheckBox.Checked = EnviarTodoUiCheckBox.Checked;
        }
        private void RecibirTodoUiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ProyeccionAnualUiCheckBox.Checked = RecibirTodoUiCheckBox.Checked;
            RollingForecastUiCheckBox.Checked = RecibirTodoUiCheckBox.Checked;
        }
    }
}
