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
    public partial class CuentaCambiarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PasswordTextBox.Attributes.Add("value", PasswordTextBox.Text);
            PasswordNuevaTextBox.Attributes.Add("value", PasswordNuevaTextBox.Text);
            ConfirmacionPasswordNuevaTextBox.Attributes.Add("value", ConfirmacionPasswordNuevaTextBox.Text);
            if (!IsPostBack)
            {
                PasswordTextBox.Focus();
                try
                {
                    if (CedForecastWebRN.Fun.NoHayNadieLogueado((CedForecastWebEntidades.Sesion)Session["Sesion"]))
                    {
                        CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosRegistrados.aspx");
                    }
                }
                catch (System.Threading.ThreadAbortException)
                {
                    Trace.Warn("Thread abortado");
                }
                catch (Exception ex)
                {
                    CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Excepcion.aspx");
                }
            }
        }
        protected void TextBox_TextChanged(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                MsgErrorLabel.Text = String.Empty;
                CedForecastWebEntidades.Sesion sesion = (CedForecastWebEntidades.Sesion)Session["Sesion"];
                CedForecastWebRN.Cuenta.CambiarPassword(sesion.Cuenta, PasswordTextBox.Text, PasswordNuevaTextBox.Text, ConfirmacionPasswordNuevaTextBox.Text, (CedEntidades.Sesion)Session["Sesion"]);
                ((CedForecastWeb)this.Master).CaducarIdentificacion();
                PasswordTextBox.Enabled = false;
                PasswordNuevaTextBox.Enabled = false;
                ConfirmacionPasswordNuevaTextBox.Enabled = false;
                AceptarButton.Visible = false;
                CancelarButton.Visible = false;
                MsgErrorLabel.Text = "La Contraseña fue modificada satisfactoriamente.  Si desea seguir trabajando, deberá volver a identificarse en la página de inicio.";
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Microsoft.ApplicationBlocks.ExceptionManagement.Login.PasswordNoMatch)
            {
                MsgErrorLabel.Text = "Contraseña actual incorrecta";
            }
            catch (Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.PasswordYConfirmacionNoCoincidente)
            {
                MsgErrorLabel.Text = "La Contraseña nueva no coincide con su Confirmación";
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
    }
}
