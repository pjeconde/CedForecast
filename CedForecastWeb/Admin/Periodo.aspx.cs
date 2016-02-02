using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CedForecastWeb.Admin
{
    public partial class Configuracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ((LinkButton)Master.FindControl("AdministracionLinkButton")).ForeColor = System.Drawing.Color.DarkBlue;
                if (!IsPostBack)
                {
                    if (CedForecastWebRN.Fun.NoHayNadieLogueado((CedForecastWebEntidades.Sesion)Session["Sesion"]))
                    {
                        CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosAdministradores.aspx");
                    }
                    else
                    {
                        if (CedForecastWebRN.Fun.NoEstaLogueadoUnAdministrador((CedForecastWebEntidades.Sesion)Session["Sesion"]))
                        {
                            CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosAdministradores.aspx");
                        }
                        else
                        {
                            Leer();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
            }
        }

        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try 
            {
                List<CedForecastWebEntidades.Periodo> periodoLista = new List<CedForecastWebEntidades.Periodo>();
                CedForecastWebEntidades.Periodo periodo = new CedForecastWebEntidades.Periodo();
                ValidarPeriodo(PeriodoTextBox.Text);
                periodo.IdPeriodo = PeriodoTextBox.Text;
                ValidarFecha(FechaInhabilitacionCargaTextBox.Text);
                periodo.FechaInhabilitacionCarga = Convert.ToDateTime(FechaInhabilitacionCargaTextBox.Text.Substring(6, 2) + "/" + FechaInhabilitacionCargaTextBox.Text.Substring(4, 2) + "/" + FechaInhabilitacionCargaTextBox.Text.Substring(0, 4));
                periodo.CargaHabilitada = CargaHabilitadaCheckBox.Checked;
                periodo.IdTipoPlanilla = "RollingForecast";
                periodoLista.Add(periodo);

                CedForecastWebEntidades.Periodo periodoProyectado = new CedForecastWebEntidades.Periodo();
                ValidarPeriodoProyectado(PeriodoProyectadoTextBox.Text);
                periodoProyectado.IdPeriodo = PeriodoProyectadoTextBox.Text;
                ValidarFecha(FechaInhabilitacionCargaProyectadoTextBox.Text);
                periodoProyectado.FechaInhabilitacionCarga = Convert.ToDateTime(FechaInhabilitacionCargaProyectadoTextBox.Text.Substring(6, 2) + "/" + FechaInhabilitacionCargaProyectadoTextBox.Text.Substring(4, 2) + "/" + FechaInhabilitacionCargaProyectadoTextBox.Text.Substring(0, 4));
                periodoProyectado.CargaHabilitada = CargaHabilitadaProyectadoCheckBox.Checked;
                periodoProyectado.IdTipoPlanilla = "Proyectado";
                periodoLista.Add(periodoProyectado);

                CedForecastWebRN.Periodo.Modificar(periodoLista, (CedEntidades.Sesion)Session["Sesion"]);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Periodo modificado satisfactoriamente');</SCRIPT>", false);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
            }
        }
        private void ValidarPeriodo(string Periodo)
        {
            try
            {
                DateTime d = Convert.ToDateTime("01/" + Periodo.Substring(4, 2) + "/" + Periodo.Substring(0, 4));
            }
            catch
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Periodo");
            }
        }
        private void ValidarPeriodoProyectado(string Periodo)
        {
            try
            {
                DateTime d = Convert.ToDateTime("01/" + Periodo.Substring(4, 2) + "/" + Periodo.Substring(0, 4));
            }
            catch
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Periodo Proyectado");
            }
        }
        private void ValidarFecha(string Fecha)
        {
            try
            {
                DateTime d = Convert.ToDateTime(Fecha.Substring(6, 2) + "/" + Fecha.Substring(4, 2) + "/" + Fecha.Substring(0, 4));
            }
            catch
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha");
            }
        }
        private void Leer()
        {
            CedForecastWebEntidades.Periodo periodo = new CedForecastWebEntidades.Periodo();
            periodo.IdTipoPlanilla = "RollingForecast";
            CedForecastWebRN.Periodo.Leer(periodo, (CedEntidades.Sesion)Session["Sesion"]);
            PeriodoTextBox.Text = periodo.IdPeriodo;
            FechaInhabilitacionCargaTextBox.Text = periodo.FechaInhabilitacionCarga.ToString("yyyyMMdd");
            CargaHabilitadaCheckBox.Checked = periodo.CargaHabilitada;

            CedForecastWebEntidades.Periodo periodoProyectado = new CedForecastWebEntidades.Periodo();
            periodoProyectado.IdTipoPlanilla = "Proyectado";
            CedForecastWebRN.Periodo.Leer(periodoProyectado, (CedEntidades.Sesion)Session["Sesion"]);
            PeriodoProyectadoTextBox.Text = periodoProyectado.IdPeriodo;
            FechaInhabilitacionCargaProyectadoTextBox.Text = periodoProyectado.FechaInhabilitacionCarga.ToString("yyyyMMdd");
            CargaHabilitadaProyectadoCheckBox.Checked = periodoProyectado.CargaHabilitada;
        }
        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            Leer();
        }
    }
}
