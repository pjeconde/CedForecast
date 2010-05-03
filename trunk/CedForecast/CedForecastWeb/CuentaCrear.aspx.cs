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
using CaptchaDotNet2.Security.Cryptography;

namespace CedForecastWeb
{
    public partial class CuentaCrear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PasswordTextBox.Attributes.Add("value", PasswordTextBox.Text);
            ConfirmacionPasswordTextBox.Attributes.Add("value", ConfirmacionPasswordTextBox.Text);
            if (!IsPostBack)
            {
                NombreTextBox.Focus();
                try
                {
                    GenerarImagenCaptcha();
                    CedForecastWebEntidades.Texto texto = new CedForecastWebEntidades.Texto();
                    texto.Id = "Forecast-TerminosyCondiciones";
                    CedForecastWebRN.Texto.Leer(texto, (CedEntidades.Sesion)Session["Sesion"]);
                    CondicionesTextBox.Text = texto.Descr;

                    DivisionDropDownList.DataValueField = "IdDivision";
                    DivisionDropDownList.DataTextField = "DescrDivision";
                    DivisionDropDownList.DataSource = CedForecastWebRN.Division.Lista(true, (CedEntidades.Sesion)Session["Sesion"]);
                    DivisionDropDownList.SelectedIndex = -1;

                    DataBind();
                }
                catch (Exception ex)
                {
                    CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Excepcion.aspx");
                }
            }
        }
        protected void CrearCuentaButton_Click(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
            ResultadoComprobarDisponibilidadLabel.Text = String.Empty;
            CedForecastWebEntidades.Cuenta cuenta = new CedForecastWebEntidades.Cuenta();
            cuenta.Nombre = NombreTextBox.Text;
            cuenta.Telefono = TelefonoTextBox.Text;
            cuenta.Email = EmailTextBox.Text;
            cuenta.Id = IdUsuarioTextBox.Text;
            cuenta.Password = PasswordTextBox.Text;
            cuenta.ConfirmacionPassword = ConfirmacionPasswordTextBox.Text;
            cuenta.Pregunta = PreguntaTextBox.Text;
            cuenta.Respuesta = RespuestaTextBox.Text;
            try
            {
                CedForecastWebRN.Cuenta.Validar(cuenta, Session["captcha"].ToString(), CaptchaTextBox.Text, (CedEntidades.Sesion)Session["Sesion"]);
                CedForecastWebRN.Cuenta.Registrar(cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                ComprobarDisponibilidadButton.Visible = false;
                NuevaClaveCaptchaButton.Visible = false;
                CrearCuentaButton.Visible = false;
                CancelarButton.Visible = false;
                CrearCuentaLabel.Visible = false;
                CaptchaImage.Visible = false;
                ClaveLabel.Visible = false;
                CaptchaTextBox.Visible = false;
                CaseSensitiveLabel.Visible = false;
                NombreTextBox.Enabled = false;
                TelefonoTextBox.Enabled = false;
                EmailTextBox.Enabled = false;
                IdUsuarioTextBox.Enabled = false;
                PasswordTextBox.Enabled = false;
                ConfirmacionPasswordTextBox.Enabled = false;
                PreguntaTextBox.Enabled = false;
                RespuestaTextBox.Enabled = false;
                MsgErrorLabel.Text = "Gracias por crear su cuenta.  Siga las instrucciones, que se enviaron por email, para confirmar la creación de su cuenta.  La recepción del email puede demorar unos minutos.";
            }
            catch (Exception ex)
            {
                string a = CedeiraUIWebForms.Excepciones.Detalle(ex);
                MsgErrorLabel.Text = a;
            }
        }
        protected void NuevaClaveCaptchaButton_Click(object sender, EventArgs e)
        {
            GenerarImagenCaptcha();
        }
        private void GenerarImagenCaptcha()
        {
            string s = RandomText.Generate();
            string ens = Encryptor.Encrypt(s, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
            Session["captcha"] = s.ToLower();
            string color = "#ffffff";
            CaptchaImage.ImageUrl = "~/Captcha.ashx?w=305&h=92&c=" + ens + "&bc=" + color;
            CaptchaTextBox.Text = String.Empty;
        }
        protected void ComprobarDisponibilidadButton_Click(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
            CedForecastWebEntidades.Cuenta cuenta = new CedForecastWebEntidades.Cuenta();
            cuenta.Id = IdUsuarioTextBox.Text;
            try
            {
                bool disponible = CedForecastWebRN.Cuenta.IdCuentaDisponible(cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                if (disponible)
                {
                    ResultadoComprobarDisponibilidadLabel.ForeColor = System.Drawing.Color.Green;
                    ResultadoComprobarDisponibilidadLabel.Text = "OK";
                }
                else
                {
                    ResultadoComprobarDisponibilidadLabel.ForeColor = System.Drawing.Color.Red;
                    ResultadoComprobarDisponibilidadLabel.Text = "No disponible";
                }
            }
            catch (Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo)
            {
                ResultadoComprobarDisponibilidadLabel.ForeColor = MsgErrorLabel.ForeColor;
                ResultadoComprobarDisponibilidadLabel.Text = "IdUsuario no informado";
            }
            catch (Exception ex)
            {
                ResultadoComprobarDisponibilidadLabel.ForeColor = MsgErrorLabel.ForeColor;
                ResultadoComprobarDisponibilidadLabel.Text = "ver detalle al pie de página";
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
    }
}
