using System;
using System.Collections;
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
                bool huboErrores = false;
                int cantidadMilisegundos = 100;
                #region Articulos
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
                    if (proceso.Errores().Count != 0)
                    {
                        huboErrores = true;
                        if (proceso.Errores()[0].InnerException != null)
                        {
                            MostrarMensajeError(proceso.Errores()[0].InnerException);
                        }
                        else
                        {
                            MostrarMensajeError(proceso.Errores()[0]);
                        }
                    } 
                    BarraDesactivar(ArticuloUIProgressBar);
                    seChequeoAlgo = true;
                }
                #endregion
                #region Clientes
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
                    if (proceso.Errores().Count != 0)
                    {
                        huboErrores = true;
                        if (proceso.Errores()[0].InnerException != null)
                        {
                            MostrarMensajeError(proceso.Errores()[0].InnerException);
                        }
                        else
                        {
                            MostrarMensajeError(proceso.Errores()[0]);
                        }
                    } 
                    BarraDesactivar(ClienteUiProgressBar);
                    seChequeoAlgo = true;
                }
                #endregion
                #region Cuentas (vendedores)
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
                    if (proceso.Errores().Count != 0)
                    {
                        huboErrores = true;
                        if (proceso.Errores()[0].InnerException != null)
                        {
                            MostrarMensajeError(proceso.Errores()[0].InnerException);
                        }
                        else
                        {
                            MostrarMensajeError(proceso.Errores()[0]);
                        }
                    } 
                    BarraDesactivar(CuentaUiProgressBar);
                    seChequeoAlgo = true;
                }
                #endregion
                #region Ventas
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
                    if (proceso.Errores().Count != 0)
                    {
                        huboErrores = true;
                        if (proceso.Errores()[0].InnerException != null)
                        {
                            MostrarMensajeError(proceso.Errores()[0].InnerException);
                        }
                        else
                        {
                            MostrarMensajeError(proceso.Errores()[0]);
                        }
                    } 
                    BarraDesactivar(VentaUiProgressBar);
                    seChequeoAlgo = true;
                }
                #endregion
                #region Zonas
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
                    if (proceso.Errores().Count != 0)
                    {
                        huboErrores = true;
                        if (proceso.Errores()[0].InnerException != null)
                        {
                            MostrarMensajeError(proceso.Errores()[0].InnerException);
                        }
                        else
                        {
                            MostrarMensajeError(proceso.Errores()[0]);
                        }
                    }
                    BarraDesactivar(ZonaUiProgressBar);
                    seChequeoAlgo = true;
                }
                #endregion
                #region Proyección Anual
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
                    if (proceso.Errores().Count != 0)
                    {
                        huboErrores = true;
                        if (proceso.Errores()[0].InnerException != null)
                        {
                            MostrarMensajeError(proceso.Errores()[0].InnerException);
                        }
                        else
                        {
                            MostrarMensajeError(proceso.Errores()[0]);
                        }
                    } 
                    BarraDesactivar(ProyeccionAnualUiProgressBar);
                    seChequeoAlgo = true;
                }
                #endregion
                #region Rolling Forecast
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
                    if (proceso.Errores().Count != 0)
                    {
                        huboErrores = true;
                        if (proceso.Errores()[0].InnerException != null)
                        {
                            MostrarMensajeError(proceso.Errores()[0].InnerException);
                        }
                        else
                        {
                            MostrarMensajeError(proceso.Errores()[0]);
                        }
                    } 
                    BarraDesactivar(RollingForecastUiProgressBar);
                    seChequeoAlgo = true;
                }
                #endregion
                if (!seChequeoAlgo)
                {
                    MessageBox.Show("Elija el elemento que desea sincronizar", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (!huboErrores)
                    {
                        MessageBox.Show("Sincronización concluída satisfactoriamente", "NOTIFICACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sincronización concluída con errores", "NOTIFICACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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

