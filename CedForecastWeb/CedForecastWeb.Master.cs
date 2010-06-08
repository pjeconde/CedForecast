using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CedForecastWeb
{
    public partial class CedForecastWeb : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MensajeGeneralLabel.Text = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).MensajeGeneral;
            if (((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Nombre != null)
            {
                NombreCuentaLabel.Text = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Nombre;
                Separador1Label.Visible = true;
                SalirLinkButton.Visible = true;
                ConfiguracionLinkButton.Visible = true;
                Separador2Label.Visible = true;
                //Menu
                ForecastLinkButton.Enabled = false;
                ProyectadoLinkButton.Enabled = false;
                ConfirmacionCargaButton.Enabled = false;
                ConsultaLinkButton.Enabled = false;
                AdministracionLinkButton.Enabled = false;
                switch (((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.TipoCuenta.Id)
                {
                    case "Admin":
                        AdministracionLinkButton.Enabled = true;
                        break;
                    case "OperForecast":
                        switch (((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.EstadoCuenta.Id)
                        {
                            case "Vigente":
                                ForecastLinkButton.Enabled = true;
                                ProyectadoLinkButton.Enabled = true;
                                ConfirmacionCargaButton.Enabled = true;
                                ConsultaLinkButton.Enabled = true;
                                break;
                            case "Suspend":
                                NombreCuentaLabel.Text += " (suspendido)";
                                break;
                        }
                        break;
                }
            }
            else
            {
                NombreCuentaLabel.Text = string.Empty;
                Separador1Label.Visible = false;
                ConfiguracionLinkButton.Visible = false;
                Separador2Label.Visible = false;
                SalirLinkButton.Visible = false;
            }
            if (Request.UrlReferrer != null)
            {
                Session["ref"] = Request.UrlReferrer.AbsoluteUri;
            }
        }
        public void SalirLinkButton_Click(object sender, EventArgs e)
        {
            CaducarIdentificacion();
			Response.Redirect("~/Inicio.aspx");
		}
        public void CaducarIdentificacion()
        {
            CedForecastWebEntidades.Sesion sesion = (CedForecastWebEntidades.Sesion)Session["Sesion"];
            sesion.Cuenta = new CedForecastWebEntidades.Cuenta();
            NombreCuentaLabel.Text = String.Empty;
            Separador1Label.Visible = false;
            ConfiguracionLinkButton.Enabled = false;
            Separador2Label.Enabled = false;
            SalirLinkButton.Enabled = false;

            ForecastLinkButton.Enabled = false;
            ProyectadoLinkButton.Enabled = false;
            ConfirmacionCargaButton.Enabled = false;
            ConsultaLinkButton.Enabled = false;
            AdministracionLinkButton.Enabled = false;
            Session["AceptarTYC"] = null;
			Application.Lock();
			Application["Registrados"] = (int)Application["Registrados"] - 1;
			Application.UnLock();

        }

    }
}
