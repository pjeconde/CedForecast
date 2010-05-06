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
                string idPaginaDefault = "";
                string idDivision = "";
                string idTipoCuenta = "";
                //Verificar si el administrador seleciono una cuenta
                string a = HttpContext.Current.Request.Url.Query.ToString();
                if (a != String.Empty)
                {
                    if (a.Substring(0, 4) == "?Id=")
                    {
                        a = a.Substring(4);
                    }
                }
                if (((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.IdTipoCuenta == "Admin" && (((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id != a && a != String.Empty))
                {
                    CedForecastWebEntidades.Cuenta cuenta = new CedForecastWebEntidades.Cuenta();
                    cuenta.Id = a;
                    CedForecastWebRN.Cuenta.Leer(cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                    IdCuentaTextBox.Text = cuenta.Id;
                    NombreTextBox.Text = cuenta.Nombre;
                    TelefonoTextBox.Text = cuenta.Telefono;
                    EmailTextBox.Text = cuenta.Email;
                    EmailSMSTextBox.Text = cuenta.EmailSMS;
                    PreguntaTextBox.Text = cuenta.Pregunta;
                    RespuestaTextBox.Text = cuenta.Respuesta;
                    EstadoTextBox.Text = cuenta.IdEstadoCuenta;
                    idPaginaDefault = cuenta.PaginaDefault.Id;
                    idDivision = cuenta.Division.Id;
                    idTipoCuenta = cuenta.TipoCuenta.Id;
                    
                    PaginaDefaultDropDownList.DataValueField = "Id";
                    PaginaDefaultDropDownList.DataTextField = "Descr";
                    PaginaDefaultDropDownList.DataSource = CedForecastWebRN.PaginaDefault.Lista(cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                    PaginaDefaultDropDownList.SelectedValue = idPaginaDefault;
               
                    IdCuentaTextBox.Enabled = false;
                    NombreTextBox.Enabled = false;
                    TelefonoTextBox.Enabled = false;
                    EmailTextBox.Enabled = false;
                    EmailSMSTextBox.Enabled = false;
                    PreguntaTextBox.Enabled = false;
                    RespuestaTextBox.Enabled = false;
                    EstadoTextBox.Enabled = false;
                    DivisionDropDownList.Enabled = false;
                    TipoCuentaDropDownList.Enabled = true;
                    PaginaDefaultDropDownList.Enabled = true;
                }
                else
                {
                    CedForecastWebRN.Cuenta.Leer(((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                    IdCuentaTextBox.Text = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
                    NombreTextBox.Text = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Nombre;
                    TelefonoTextBox.Text = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Telefono;
                    EmailTextBox.Text = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Email;
                    EmailSMSTextBox.Text = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.EmailSMS;
                    PreguntaTextBox.Text = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Pregunta;
                    RespuestaTextBox.Text = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Respuesta;
                    EstadoTextBox.Text = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.IdEstadoCuenta;
                    idPaginaDefault = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.PaginaDefault.Id;
                    idDivision = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Division.Id;
                    idTipoCuenta = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.TipoCuenta.Id;
                    
                    PaginaDefaultDropDownList.DataValueField = "Id";
                    PaginaDefaultDropDownList.DataTextField = "Descr";
                    PaginaDefaultDropDownList.DataSource = CedForecastWebRN.PaginaDefault.Lista(((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                    PaginaDefaultDropDownList.SelectedValue = idPaginaDefault;
                    
                    IdCuentaTextBox.Enabled = false;
                    NombreTextBox.Enabled = false;
                    TelefonoTextBox.Enabled = false;
                    EmailTextBox.Enabled = false; 
                    EmailSMSTextBox.Enabled = true;
                    PreguntaTextBox.Enabled = true;
                    RespuestaTextBox.Enabled = true;
                    EstadoTextBox.Enabled = false;
                    DivisionDropDownList.Enabled = false;
                    if (((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.IdTipoCuenta == "Admin")
                    {
                        TipoCuentaDropDownList.Enabled = true;
                        PaginaDefaultDropDownList.Enabled = true;
                    }
                    else
                    {
                        TipoCuentaDropDownList.Enabled = false;
                        PaginaDefaultDropDownList.Enabled = false;
                    }
                }
                DivisionDropDownList.DataValueField = "Id";
                DivisionDropDownList.DataTextField = "Descr";
                DivisionDropDownList.DataSource = CedForecastWebRN.Division.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                DivisionDropDownList.SelectedValue = idDivision;
                TipoCuentaDropDownList.DataValueField = "Id";
                TipoCuentaDropDownList.DataTextField = "Descr";
                TipoCuentaDropDownList.DataSource = CedForecastWebRN.TipoCuenta.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                TipoCuentaDropDownList.SelectedValue = idTipoCuenta;

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
            cuenta.Division.Id = DivisionDropDownList.SelectedValue;
            cuenta.Pregunta = PreguntaTextBox.Text;
            cuenta.Respuesta = RespuestaTextBox.Text;
            cuenta.PaginaDefault.Id = Convert.ToString(PaginaDefaultDropDownList.SelectedValue);
            try
            {
                CedForecastWebRN.Cuenta.Configurar(cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                GuardarButton.Visible = false;
                CancelarButton.Visible = false;
                IdCuentaTextBox.Enabled = false;
                NombreTextBox.Enabled = false;
                TelefonoTextBox.Enabled = false;
                EmailTextBox.Enabled = false;
                EmailSMSTextBox.Enabled = false;
                PreguntaTextBox.Enabled = false;
                RespuestaTextBox.Enabled = false;
                EstadoTextBox.Enabled = false;
                DivisionDropDownList.Enabled = false;
                TipoCuentaDropDownList.Enabled = false;
                PaginaDefaultDropDownList.Enabled = false;

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
