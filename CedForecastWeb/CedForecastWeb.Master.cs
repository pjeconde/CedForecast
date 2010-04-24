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
                switch (((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.TipoCuenta.Id)
                {
                    case "Admin":
                        AdministracionLinkButton.Visible = true;
                        break;
                     case "OperForecast":
                        AdministracionLinkButton.Visible = false;
                        switch (((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.EstadoCuenta.Id)
                        {
                            case "Vigente":
                                ForecastLinkButton.Visible = true;
                                break;
                            case "Suspend":
                                NombreCuentaLabel.Text += " (suspendido)";
                                ForecastLinkButton.Visible = false;
                                break;
                        }
                        break;
                }
            }
            else
            {
                NombreCuentaLabel.Text = string.Empty;
                Separador1Label.Visible = false;
                //ConfiguracionLinkButton.Visible = false;
                //Separador2Label.Visible = false;
                SalirLinkButton.Visible = false;
                AdministracionLinkButton.Visible = false;
                //ServicioPremiumEstadoLabel.Text = string.Empty;
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
            //ConfiguracionLinkButton.Visible = false;
            //Separador2Label.Visible = false;
            //BackupLinkButton.Visible = false;
            //Separador3Label.Visible = false;
            SalirLinkButton.Visible = false;
            AdministracionLinkButton.Visible = false;
            Session["AceptarTYC"] = null;
			Application.Lock();
			Application["Registrados"] = (int)Application["Registrados"] - 1;
			Application.UnLock();

        }

    }
}
