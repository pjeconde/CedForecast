using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CedForecastWeb
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
			Application["Visitantes"] = 0;
			Application["Registrados"] = 0;
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        protected void Session_Start(object sender, EventArgs e)
        {
            CedForecastWebEntidades.Sesion s = new CedForecastWebEntidades.Sesion();
            s.CnnStr = System.Configuration.ConfigurationManager.AppSettings["CnnStr"];
            s.MensajeGeneral = System.Configuration.ConfigurationManager.AppSettings["MensajeGeneral"];
            //s.CantidadDiasPremiumSinCostoEnAltaCuenta = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CantidadDiasPremiumSinCostoEnAltaCuenta"]);
            CedForecastWebRN.Flag.Leer(s.Flag, s);
            Session["Sesion"] = s;
			Application.Lock();
			Application["Visitantes"] = (int)Application["Visitantes"] + 1;
			Application.UnLock();
		}
		protected void Session_End(object sender, EventArgs e)
		{
			Application.Lock();
			Application["Visitantes"] = (int)Application["Visitantes"] - 1;
			Application.UnLock();
			if (!((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id.Equals(string.Empty))
			{
				Application.Lock();
				Application["Registrados"] = (int)Application["Registrados"] - 1;
				Application.UnLock();
			}
		}
    }
}
