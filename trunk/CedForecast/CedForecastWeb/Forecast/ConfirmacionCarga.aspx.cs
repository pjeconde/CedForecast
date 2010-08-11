using System;
using System.Data;
using System.Globalization;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using System.Xml;
//using System.IO;

namespace CedForecastWeb.Forecast
{
    public partial class ConfirmacionCarga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((LinkButton)Master.FindControl("ConfirmacionLinkButton")).ForeColor = System.Drawing.Color.DarkBlue;
            if (!IsPostBack)
            {
                if (CedForecastWebRN.Fun.NoHayNadieLogueado((CedForecastWebEntidades.Sesion)Session["Sesion"]))
                {
                    CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosOperForecast.aspx");
                }
                else
                {
                    if (CedForecastWebRN.Fun.NoEstaLogueadoUnOperForecast((CedForecastWebEntidades.Sesion)Session["Sesion"]))
                    {
                        CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosOperForecast.aspx");
                    }
                    else
                    {
                        Leer();                        
                        DataBind();
                        AnularConfirmacionButton.Attributes.Add("onclick", "return confirm('Desea anular de confimación de la carga de datos ?');");
                        AnularConfirmacionButton.Attributes.Add("title", "Anular de confimación de la carga de datos."); ;
                        ConfirmarButton.Attributes.Add("onclick", "return confirm('Desea confirmar la carga de datos ?');");
                        ConfirmarButton.Attributes.Add("title", "Confirmar la carga de datos."); ;
                    }
                }
            }
        }
        protected void ConfirmarButton_Click(object sender, EventArgs e)
        {
            CedForecastWebEntidades.ConfirmacionCarga confirmacionCarga = new CedForecastWebEntidades.ConfirmacionCarga();
            CompletarDatosEntidad(confirmacionCarga);
            confirmacionCarga.IdEstadoConfirmacionCarga = "Vigente";
            CedForecastWebRN.ConfirmacionCarga.Confirmar(confirmacionCarga, IdEstadoConfirmacionCargaTextBox.Text, ((CedForecastWebEntidades.Sesion)Session["Sesion"]));
            Leer();
        }
        protected void AnularConfirmacionButton_Click(object sender, EventArgs e)
        {
            CedForecastWebEntidades.ConfirmacionCarga confirmacionCarga = new CedForecastWebEntidades.ConfirmacionCarga();
            CompletarDatosEntidad(confirmacionCarga);
            confirmacionCarga.IdEstadoConfirmacionCarga = "Anulada";
            CedForecastWebRN.ConfirmacionCarga.AnularConfirmacion(confirmacionCarga, IdEstadoConfirmacionCargaTextBox.Text, ((CedForecastWebEntidades.Sesion)Session["Sesion"]));
            Leer();
        }
        private void CompletarDatosEntidad(CedForecastWebEntidades.ConfirmacionCarga confirmacionCarga)
        {
            confirmacionCarga.IdTipoPlanilla = "RollingForecast";
            confirmacionCarga.IdPeriodo = PeriodoTextBox.Text;
            confirmacionCarga.Cuenta.Id = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
            confirmacionCarga.FechaConfirmacionCarga = DateTime.Now;
        }
        private void Leer()
        {
            CedForecastWebEntidades.Periodo periodo = new CedForecastWebEntidades.Periodo();
            periodo.IdTipoPlanilla = "RollingForecast";
            CedForecastWebRN.Periodo.Leer(periodo, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
            PeriodoTextBox.Text = periodo.IdPeriodo;
            PeriodoTextBox.ReadOnly = true;

            CedForecastWebEntidades.ConfirmacionCarga confirmacionCarga = new CedForecastWebEntidades.ConfirmacionCarga();
            confirmacionCarga.IdPeriodo = periodo.IdPeriodo;
            confirmacionCarga.Cuenta.Id = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
            confirmacionCarga.IdTipoPlanilla = "RollingForecast";
            CedForecastWebRN.ConfirmacionCarga.Leer(confirmacionCarga, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
            
            if ((!periodo.CargaHabilitada) || periodo.FechaInhabilitacionCarga < DateTime.Today)
            {
                AnularConfirmacionButton.Enabled = false;
                ConfirmarButton.Enabled = false;
                MsgLabel.Text = " (Carga inhabilitada).";
            }
            else
            {
                switch (confirmacionCarga.IdEstadoConfirmacionCarga)
                {
                    case "Vigente":
                    case "Rechazada":
                        AnularConfirmacionButton.Enabled = true;
                        ConfirmarButton.Enabled = false;
                        break;
                    case "Anulada":
                    case null:
                        AnularConfirmacionButton.Enabled = false;
                        ConfirmarButton.Enabled = true;
                        break;
                    case "Aceptada":
                        AnularConfirmacionButton.Enabled = false;
                        ConfirmarButton.Enabled = false;
                        break;
                }
            }
            FechaVtoConfimacionCargaLabel.Text = "Carga habilitada hasta el día: " + periodo.FechaInhabilitacionCarga.ToString("dd/MM/yyyy") + " inclusive.";
            FechaConfirmacionCargaTextBox.Text = Convert.ToString(confirmacionCarga.FechaConfirmacionCarga);
            ComentarioTextBox.Text = confirmacionCarga.Comentario;
            IdEstadoConfirmacionCargaTextBox.Text = confirmacionCarga.IdEstadoConfirmacionCarga;
        }
    }
}
