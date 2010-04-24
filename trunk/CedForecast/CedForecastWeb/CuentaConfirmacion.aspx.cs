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
    public partial class CuentaConfirmacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string a = HttpContext.Current.Request.Url.Query.ToString();
                if (a == String.Empty)
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.CuentaConfFormatoMsgErroneo();
                }
                else
                {
                    if (a.Substring(0, 4) == "?Id=")
                    {
                        a = a.Substring(4);
                    }
                    string idUsuario = a;
                    CedForecastWebEntidades.Cuenta cuenta = new CedForecastWebEntidades.Cuenta();
                    cuenta.Id = idUsuario;
                    CedForecastWebRN.Cuenta.Confirmar(cuenta, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                    MensajeLabel.Text = "Felicitaciones !!!.  Su nueva cuenta '" + cuenta.Id + "' ya está disponible.";
                }
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                MensajeLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.CuentaConfFormatoMsgErroneo());
            }
            catch (System.FormatException)
            {
                MensajeLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.CuentaConfFormatoMsgErroneo());
            }
            catch (Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente)
            {
                MensajeLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.CuentaConfFormatoMsgErroneo());
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
    }
}
