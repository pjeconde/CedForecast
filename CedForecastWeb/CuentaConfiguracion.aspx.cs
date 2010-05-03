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
    public partial class CuentaConfiguracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CedForecastWebRN.Cuenta.Leer(((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                NombreTextBox.Text = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Nombre;
                TelefonoTextBox.Text = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Telefono;
                EmailTextBox.Text = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Email;
                EmailSMSTextBox.Text = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.EmailSMS;
                PreguntaTextBox.Text = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Pregunta;
                RespuestaTextBox.Text = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Respuesta;
                PaginaDefaultDropDownList.DataValueField = "Id";
                PaginaDefaultDropDownList.DataTextField = "Descr";
                PaginaDefaultDropDownList.DataSource = CedForecastWebRN.PaginaDefault.Lista(((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                PaginaDefaultDropDownList.SelectedValue = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.PaginaDefault.Id;
                DivisionDropDownList.DataValueField = "IdDivision";
                DivisionDropDownList.DataTextField = "DescrDivision";
                DivisionDropDownList.DataSource = CedForecastWebRN.Division.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                DivisionDropDownList.SelectedValue = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Division.IdDivision;
                TipoCuentaDropDownList.DataValueField = "Id";
                TipoCuentaDropDownList.DataTextField = "Descr";
                TipoCuentaDropDownList.DataSource = CedForecastWebRN.TipoCuenta.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                TipoCuentaDropDownList.SelectedValue = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.TipoCuenta.Id;

                DataBind();
                CancelarButton.Focus();
            }
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
            CedForecastWebEntidades.Cuenta cuenta = new CedForecastWebEntidades.Cuenta();
            cuenta.Id = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
            cuenta.Nombre = NombreTextBox.Text;
            cuenta.Telefono = TelefonoTextBox.Text;
            cuenta.EmailSMS = EmailSMSTextBox.Text;
            cuenta.Division.IdDivision = DivisionDropDownList.SelectedValue;
            cuenta.Pregunta = PreguntaTextBox.Text;
            cuenta.Respuesta = RespuestaTextBox.Text;
            cuenta.PaginaDefault.Id = Convert.ToString(PaginaDefaultDropDownList.SelectedValue);
            try
            {
                CedForecastWebRN.Cuenta.Configurar(cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                GuardarButton.Visible = false;
                CancelarButton.Visible = false;
                NombreTextBox.Enabled = false;
                TelefonoTextBox.Enabled = false;
                EmailTextBox.Enabled = false;
                EmailSMSTextBox.Enabled = false;
                PaginaDefaultDropDownList.Enabled = false;
                DivisionDropDownList.Enabled = false;
                PreguntaTextBox.Enabled = false;
                RespuestaTextBox.Enabled = false;
                MsgErrorLabel.Text = "Se ha registrado la nueva configuración satisfactoriamente.";
            }
            catch (Exception ex)
            {
                string a = CedeiraUIWebForms.Excepciones.Detalle(ex);
                MsgErrorLabel.Text = a;
            }
        }

        protected void TipoCuentaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CedForecastWebEntidades.TipoCuenta tipoCuenta = new CedForecastWebEntidades.TipoCuenta();
            tipoCuenta.Id = TipoCuentaDropDownList.SelectedValue;
            PaginaDefaultDropDownList.DataSource = CedForecastWebRN.PaginaDefault.Lista(tipoCuenta, (CedEntidades.Sesion)Session["Sesion"]);
            PaginaDefaultDropDownList.SelectedValue = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.PaginaDefault.Id;
        }
    }
}
