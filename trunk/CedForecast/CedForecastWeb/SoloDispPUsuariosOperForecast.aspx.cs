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
using CedeiraUIWebForms;

namespace CedForecastWeb
{
    public partial class SoloDispPUsuariosOperForecast: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UrlParameterPasser urlWrapper = new UrlParameterPasser();
                TituloLabel.Text = urlWrapper["Opcion"];
            }
            catch (Exception ex)
            {
                CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Excepcion.aspx");
            }
        }
    }

}
