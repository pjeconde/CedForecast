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
    public partial class Proyectado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((LinkButton)Master.FindControl("ProyectadoLinkButton")).ForeColor = System.Drawing.Color.Gold;
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
                        ClienteDropDownList.DataValueField = "IdCliente";
                        ClienteDropDownList.DataTextField = "DescrCliente";
                        ClienteDropDownList.DataSource = CedForecastWebRN.Cliente.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                        ClienteDropDownList.SelectedIndex = -1;

                        DivisionDropDownList.DataValueField = "IdDivision";
                        DivisionDropDownList.DataTextField = "DescrDivision";
                        DivisionDropDownList.DataSource = CedForecastWebRN.Division.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                        DivisionDropDownList.SelectedValue = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Division.Id;

                        CedForecastWebEntidades.Periodo periodo = new CedForecastWebEntidades.Periodo();
                        periodo.IdTipoPlanilla = "Proyectado";
                        CedForecastWebRN.Periodo.Leer(periodo, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                        PeriodoTextBox.Text = periodo.IdPeriodo;
                        PeriodoTextBox.ReadOnly = true;
                        
                        DivisionDropDownList.SelectedValue = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Division.Id;
                        
                        FechaVtoConfimacionCargaLabel.Text = "Carga habilitada hasta el d�a: " + periodo.FechaInhabilitacionCarga.ToString("dd/MM/yyyy") + " inclusive.";
                        detalleGridView.Columns[1].HeaderText = "Total " + periodo.IdPeriodo;
                        for (int i = 1; i <= 12; i++)
                        {
                            detalleGridView.Columns[i+1].HeaderText = TextoCantidadHeader(i, PeriodoTextBox.Text);
                        }
                        detalleGridView.Columns[13 + 1].HeaderText = "Total " + Convert.ToDateTime("01/01/" + PeriodoTextBox.Text).AddYears(1).Year.ToString();
                        detalleGridView.Columns[14 + 1].HeaderText = "Total " + Convert.ToDateTime("01/01/" + PeriodoTextBox.Text).AddYears(2).Year.ToString();

                        DataBind();
                        LimpiarGrilla();
                        
                        BindearDropDownLists();

                        CancelarButton.Attributes.Add("onclick", "return confirm('Confirmar la cancelaci�n de los datos ?');");
                        CancelarButton.Attributes.Add("title", "Cancela los datos ingresados en la grilla.");;
                        AceptarButton.Attributes.Add("onclick", "return confirm('Confirmar la aceptaci�n de los datos ?');");

                        CedForecastWebEntidades.ConfirmacionCarga confirmacionCarga = new CedForecastWebEntidades.ConfirmacionCarga();
                        confirmacionCarga.IdPeriodo = periodo.IdPeriodo;
                        confirmacionCarga.Cuenta.Id = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
                        CedForecastWebRN.ConfirmacionCarga.Leer(confirmacionCarga, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                        LeerButton.Enabled = false;
                        ClienteDropDownList.Enabled = false;
                        ClienteLabel.Enabled = false;
                        switch (confirmacionCarga.IdEstadoConfirmacionCarga)
                        {
                            case "Baja":
                            case null:
                                LeerButton.Enabled = true;
                                ClienteDropDownList.Enabled = true;
                                ClienteLabel.Enabled = true;
                                break;
                            default:
                                MsgLabel.Text = "(No es posible modifcar los datos en el estado actual)";
                                break;
                        }
                        detalleGridView.Enabled = false;
                        CancelarButton.Enabled = false;
                        AceptarButton.Enabled = false;
                    }
                }
            }
        }
        private void LimpiarGrilla()
        {
            CedForecastWebEntidades.Forecast forecast = new CedForecastWebEntidades.Forecast();
            List<CedForecastWebEntidades.Forecast> forecastLista = new List<CedForecastWebEntidades.Forecast>();
            forecastLista.Add(forecast);
            detalleGridView.DataSource = forecastLista;
            detalleGridView.DataBind();
            ViewState["lineas"] = forecastLista;
            ClienteDropDownList.SelectedIndex = -1;
        }
        private void BindearDropDownLists()
        {
            ((DropDownList)detalleGridView.FooterRow.FindControl("ddlIdArticulo")).DataValueField = "IdArticulo";
            ((DropDownList)detalleGridView.FooterRow.FindControl("ddlIdArticulo")).DataTextField = "DescrArticulo";
            ((DropDownList)detalleGridView.FooterRow.FindControl("ddlIdArticulo")).DataSource = CedForecastWebRN.Articulo.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
            ((DropDownList)detalleGridView.FooterRow.FindControl("ddlIdArticulo")).DataBind();
        }

        protected void detalleGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ClienteDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void detalleGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                if (ClienteDropDownList.SelectedItem.Value.Equals(string.Empty))
                {
                    throw new Exception("Debe seleccionar un cliente antes de editar un detalle");
                }

                CultureInfo cedeiraCultura = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"]);

                string auxIdArticulo = ((DropDownList)detalleGridView.Rows[e.RowIndex].FindControl("ddlIdArticuloEdit")).SelectedValue;

                //Modificaci�n de articulo existente. ( El articulo ya existe en el ViewState y en un index distinto al que estoy modificando )
                if (e.RowIndex < ((List<CedForecastWebEntidades.Forecast>)ViewState["lineas"]).Count)
                {
                    int indexArticulo =((List<CedForecastWebEntidades.Forecast>)ViewState["lineas"]).FindIndex((delegate(CedForecastWebEntidades.Forecast e1) { return e1.Articulo.Id == auxIdArticulo; }));
                    if (indexArticulo >= 0 && e.RowIndex != indexArticulo)
                    {
                        throw new Exception("Articulo ya ingresado.");
                    }
                }
                //Articulo nuevo. ( El e.RowIndex es mayor al ultimo del ViewState )
                else
                {
                    CedForecastWebEntidades.Forecast forecast = ((List<CedForecastWebEntidades.Forecast>)ViewState["lineas"]).Find((delegate(CedForecastWebEntidades.Forecast e1) { return e1.Articulo.Id == auxIdArticulo; }));
                    if (forecast != null && forecast.Articulo.Id == auxIdArticulo)
                    {
                        throw new Exception("Articulo ya ingresado.");
                    }
                }
                List<CedForecastWebEntidades.Forecast> lineas = ((List<CedForecastWebEntidades.Forecast>)ViewState["lineas"]);

                CedForecastWebEntidades.Forecast l = lineas[e.RowIndex];
                
                string auxDescrArticulo = ((DropDownList)detalleGridView.Rows[e.RowIndex].FindControl("ddlIdArticuloEdit")).SelectedItem.Text;
                if (!auxIdArticulo.Equals(string.Empty))
                {
                    l.Articulo.Id = auxIdArticulo;
                    l.Articulo.Descr = auxDescrArticulo;
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque la descripci�n del art�culo no puede estar vac�a");
                }
                string auxCantidad1 = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtCantidad1Edit")).Text;
                if (!auxCantidad1.Contains(","))
                {
                    l.Cantidad1 = Convert.ToDecimal(auxCantidad1, cedeiraCultura);
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                }
                string auxCantidad2 = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtCantidad2Edit")).Text;
                if (!auxCantidad2.Contains(","))
                {
                    l.Cantidad2 = Convert.ToDecimal(auxCantidad2, cedeiraCultura);
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                }
                string auxCantidad3 = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtCantidad3Edit")).Text;
                if (!auxCantidad3.Contains(","))
                {
                    l.Cantidad3 = Convert.ToDecimal(auxCantidad3, cedeiraCultura);
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                }
                string auxCantidad4 = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtCantidad4Edit")).Text;
                if (!auxCantidad4.Contains(","))
                {
                    l.Cantidad4 = Convert.ToDecimal(auxCantidad4, cedeiraCultura);
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                }
                string auxCantidad5 = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtCantidad5Edit")).Text;
                if (!auxCantidad5.Contains(","))
                {
                    l.Cantidad5 = Convert.ToDecimal(auxCantidad5, cedeiraCultura);
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                }
                string auxCantidad6 = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtCantidad6Edit")).Text;
                if (!auxCantidad6.Contains(","))
                {
                    l.Cantidad6 = Convert.ToDecimal(auxCantidad6, cedeiraCultura);
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                }
                string auxCantidad7 = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtCantidad7Edit")).Text;
                if (!auxCantidad7.Contains(","))
                {
                    l.Cantidad7 = Convert.ToDecimal(auxCantidad7, cedeiraCultura);
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                }
                string auxCantidad8 = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtCantidad8Edit")).Text;
                if (!auxCantidad8.Contains(","))
                {
                    l.Cantidad8 = Convert.ToDecimal(auxCantidad8, cedeiraCultura);
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                }
                string auxCantidad9 = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtCantidad9Edit")).Text;
                if (!auxCantidad9.Contains(","))
                {
                    l.Cantidad9 = Convert.ToDecimal(auxCantidad9, cedeiraCultura);
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                }
                string auxCantidad10 = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtCantidad10Edit")).Text;
                if (!auxCantidad10.Contains(","))
                {
                    l.Cantidad10 = Convert.ToDecimal(auxCantidad10, cedeiraCultura);
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                }
                string auxCantidad11 = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtCantidad11Edit")).Text;
                if (!auxCantidad11.Contains(","))
                {
                    l.Cantidad11 = Convert.ToDecimal(auxCantidad11, cedeiraCultura);
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                }
                string auxCantidad12 = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtCantidad12Edit")).Text;
                if (!auxCantidad12.Contains(","))
                {
                    l.Cantidad12 = Convert.ToDecimal(auxCantidad12, cedeiraCultura);
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                }
                string auxCantidad13 = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtCantidad13Edit")).Text;
                if (!auxCantidad13.Contains(","))
                {
                    l.Cantidad13 = Convert.ToDecimal(auxCantidad13, cedeiraCultura);
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                }
                string auxCantidad14 = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtCantidad14Edit")).Text;
                if (!auxCantidad14.Contains(","))
                {
                    l.Cantidad14 = Convert.ToDecimal(auxCantidad14, cedeiraCultura);
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                }
                detalleGridView.EditIndex = -1;
                detalleGridView.DataSource = ViewState["lineas"];
                detalleGridView.DataBind();
                BindearDropDownLists();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
            }
        }
        protected void detalleGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.Exception != null)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
                e.ExceptionHandled = true;
            }
        }
        protected void detalleGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddDetalle"))
            {
                try
                {
                    if (ClienteDropDownList.SelectedItem.Value.Equals(string.Empty))
                    {
                        throw new Exception("Debe seleccionar un cliente antes de ingresar un detalle");
                    }
                    
                    CultureInfo cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"]);
                    
                    string auxIdArticulo = ((DropDownList)detalleGridView.FooterRow.FindControl("ddlIdArticulo")).SelectedValue;
                    CedForecastWebEntidades.Forecast forecast = ((List<CedForecastWebEntidades.Forecast>)ViewState["lineas"]).Find((delegate(CedForecastWebEntidades.Forecast e1) { return e1.Articulo.Id == auxIdArticulo; }));
                    if (forecast != null && forecast.Articulo.Id == auxIdArticulo)
                    {
                        throw new Exception("Articulo ya ingresado.");
                    }

                    CedForecastWebEntidades.Forecast l = new CedForecastWebEntidades.Forecast();
                    l.IdCuenta = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
                    l.Articulo.GrupoArticulo.Division.Id = DivisionDropDownList.SelectedValue;
                    l.IdCliente = ClienteDropDownList.SelectedValue;
                    l.IdPeriodo = PeriodoTextBox.Text;
                    
                    string auxDescrArticulo = ((DropDownList)detalleGridView.FooterRow.FindControl("ddlIdArticulo")).SelectedItem.Text;
                    if (!auxIdArticulo.Equals(string.Empty))
                    {
                        l.Articulo = new CedForecastWebEntidades.Articulo();
                        l.Articulo.Id = auxIdArticulo;
                        l.Articulo.Descr = auxDescrArticulo;
                    }
                    else
                    {
                        throw new Exception("Detalle no agregado porque la descripci�n del art�culo no puede estar vac�a");
                    }

                    string auxCantidad1 = ((TextBox)detalleGridView.FooterRow.FindControl("txtCantidad1")).Text;
                    if (!auxCantidad1.Contains(","))
                    {
                        l.Cantidad1 = Convert.ToDecimal(auxCantidad1, cedeiraCultura);
                    }
                    else
                    {
                        throw new Exception("Detalle no agregado porque el separador de decimales debe ser el punto");
                    }
                    string auxCantidad2 = ((TextBox)detalleGridView.FooterRow.FindControl("txtCantidad2")).Text;
                    if (!auxCantidad2.Contains(","))
                    {
                        l.Cantidad2 = Convert.ToDecimal(auxCantidad2, cedeiraCultura);
                    }
                    else
                    {
                        throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                    }
                    string auxCantidad3 = ((TextBox)detalleGridView.FooterRow.FindControl("txtCantidad3")).Text;
                    if (!auxCantidad3.Contains(","))
                    {
                        l.Cantidad3 = Convert.ToDecimal(auxCantidad3, cedeiraCultura);
                    }
                    else
                    {
                        throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                    }
                    string auxCantidad4 = ((TextBox)detalleGridView.FooterRow.FindControl("txtCantidad4")).Text;
                    if (!auxCantidad4.Contains(","))
                    {
                        l.Cantidad4 = Convert.ToDecimal(auxCantidad4, cedeiraCultura);
                    }
                    else
                    {
                        throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                    }
                    string auxCantidad5 = ((TextBox)detalleGridView.FooterRow.FindControl("txtCantidad5")).Text;
                    if (!auxCantidad5.Contains(","))
                    {
                        l.Cantidad5 = Convert.ToDecimal(auxCantidad5, cedeiraCultura);
                    }
                    else
                    {
                        throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                    }
                    string auxCantidad6 = ((TextBox)detalleGridView.FooterRow.FindControl("txtCantidad6")).Text;
                    if (!auxCantidad6.Contains(","))
                    {
                        l.Cantidad6 = Convert.ToDecimal(auxCantidad6, cedeiraCultura);
                    }
                    else
                    {
                        throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                    }
                    string auxCantidad7 = ((TextBox)detalleGridView.FooterRow.FindControl("txtCantidad7")).Text;
                    if (!auxCantidad7.Contains(","))
                    {
                        l.Cantidad7 = Convert.ToDecimal(auxCantidad7, cedeiraCultura);
                    }
                    else
                    {
                        throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                    }
                    string auxCantidad8 = ((TextBox)detalleGridView.FooterRow.FindControl("txtCantidad8")).Text;
                    if (!auxCantidad8.Contains(","))
                    {
                        l.Cantidad8 = Convert.ToDecimal(auxCantidad8, cedeiraCultura);
                    }
                    else
                    {
                        throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                    }
                    string auxCantidad9 = ((TextBox)detalleGridView.FooterRow.FindControl("txtCantidad9")).Text;
                    if (!auxCantidad9.Contains(","))
                    {
                        l.Cantidad9 = Convert.ToDecimal(auxCantidad9, cedeiraCultura);
                    }
                    else
                    {
                        throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                    }
                    string auxCantidad10 = ((TextBox)detalleGridView.FooterRow.FindControl("txtCantidad10")).Text;
                    if (!auxCantidad10.Contains(","))
                    {
                        l.Cantidad10 = Convert.ToDecimal(auxCantidad10, cedeiraCultura);
                    }
                    else
                    {
                        throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                    }
                    string auxCantidad11 = ((TextBox)detalleGridView.FooterRow.FindControl("txtCantidad11")).Text;
                    if (!auxCantidad11.Contains(","))
                    {
                        l.Cantidad11 = Convert.ToDecimal(auxCantidad11, cedeiraCultura);
                    }
                    else
                    {
                        throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                    }
                    string auxCantidad12 = ((TextBox)detalleGridView.FooterRow.FindControl("txtCantidad12")).Text;
                    if (!auxCantidad12.Contains(","))
                    {
                        l.Cantidad12 = Convert.ToDecimal(auxCantidad12, cedeiraCultura);
                    }
                    else
                    {
                        throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                    }
                    string auxCantidad13 = ((TextBox)detalleGridView.FooterRow.FindControl("txtCantidad13")).Text;
                    if (!auxCantidad13.Contains(","))
                    {
                        l.Cantidad13 = Convert.ToDecimal(auxCantidad13, cedeiraCultura);
                    }
                    else
                    {
                        throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                    }
                    string auxCantidad14 = ((TextBox)detalleGridView.FooterRow.FindControl("txtCantidad14")).Text;
                    if (!auxCantidad14.Contains(","))
                    {
                        l.Cantidad14 = Convert.ToDecimal(auxCantidad14, cedeiraCultura);
                    }
                    else
                    {
                        throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                    }

                    //Agrego la nueva linea
                    ((List<CedForecastWebEntidades.Forecast>)ViewState["lineas"]).Add(l);

                    //Me fijo si elimino la fila autom�tica
                    List<CedForecastWebEntidades.Forecast> lineas = ((List<CedForecastWebEntidades.Forecast>)ViewState["lineas"]);
                    CedForecastWebEntidades.Forecast lineaInicial = lineas[0];
                    if (lineaInicial.IdCuenta == null)
                    {
                        ((List<CedForecastWebEntidades.Forecast>)ViewState["lineas"]).Remove(lineaInicial);
                    }
                    detalleGridView.DataSource = ViewState["lineas"];
                    detalleGridView.DataBind();

                    BindearDropDownLists();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
                }
            }
        }
        private string TextoCantidadHeader(int ColCantidad, string PeriodoInicial)
        {
            DateTime fechaAux = Convert.ToDateTime("01/01/" + PeriodoInicial.Substring(0, 4));
            fechaAux = fechaAux.AddMonths(ColCantidad - 1);
            return fechaAux.ToString("MM-yyyy");
        }
        protected void detalleGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            detalleGridView.EditIndex = -1;
            detalleGridView.DataSource = ViewState["lineas"];
            detalleGridView.DataBind();
            BindearDropDownLists();
        }
        protected void detalleGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            detalleGridView.EditIndex = e.NewEditIndex;
            detalleGridView.DataSource = ViewState["lineas"];
            detalleGridView.DataBind();
            BindearDropDownLists();

            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlIdArticuloEdit")).DataValueField = "IdArticulo";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlIdArticuloEdit")).DataTextField = "DescrArticulo";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlIdArticuloEdit")).DataSource = CedForecastWebRN.Articulo.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlIdArticuloEdit")).DataBind();
            try
            {
                ListItem liUnidad = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlIdArticuloEdit")).Items.FindByValue(((List<CedForecastWebEntidades.Forecast>)ViewState["lineas"])[e.NewEditIndex].Articulo.Id.ToString());
                liUnidad.Selected = true;
            }
            catch
            {
            }
        }
        protected void detalleGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                List<CedForecastWebEntidades.Forecast> lineas = ((List<CedForecastWebEntidades.Forecast>)ViewState["lineas"]);
                CedForecastWebEntidades.Forecast l = lineas[e.RowIndex];
                lineas.Remove(l);

                if (lineas.Count.Equals(0))
                {
                    CedForecastWebEntidades.Forecast nueva = new CedForecastWebEntidades.Forecast();
                    lineas.Add(nueva);
                }

                detalleGridView.EditIndex = -1;

                detalleGridView.DataSource = ViewState["lineas"];
                detalleGridView.DataBind();
                BindearDropDownLists();
            }
            catch { }

        }
        protected void detalleGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
                e.ExceptionHandled = true;
            }
        }

        protected void LeerButton_Click(object sender, EventArgs e)
        {
            try
            {
                CedForecastWebEntidades.Forecast forecast = new CedForecastWebEntidades.Forecast();
                forecast.IdCuenta = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
                forecast.IdPeriodo = PeriodoTextBox.Text;
                forecast.IdTipoPlanilla = "Proyectado";
                if (!ClienteDropDownList.SelectedValue.Equals(string.Empty))
                {
                    forecast.IdCliente = ClienteDropDownList.SelectedValue;
                }
                else
                {
                    throw new Exception("Cliente no seleccionado");
                }
                if (!DivisionDropDownList.SelectedValue.Equals(string.Empty))
                {
                    forecast.Articulo.GrupoArticulo.Division.Id = DivisionDropDownList.SelectedValue;
                }
                else
                {
                    throw new Exception("Divisi�n no seleccionada");
                }
                List<CedForecastWebEntidades.Forecast> forecastLista = CedForecastWebRN.Forecast.Lista(forecast, (CedEntidades.Sesion)Session["Sesion"]);
               
                detalleGridView.DataSource = forecastLista;
                detalleGridView.DataBind();
                ViewState["lineas"] = forecastLista;

                BindearDropDownLists();
                
                LeerButton.Enabled = false;
                SeleccionPanel.Enabled = false;
                detalleGridView.Enabled = true;
                CancelarButton.Enabled = true;
                AceptarButton.Enabled = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
            }
        }

        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            CedForecastWebEntidades.Forecast forecast = new CedForecastWebEntidades.Forecast();
            CedForecastWebRN.Forecast.Guardar((List<CedForecastWebEntidades.Forecast>)ViewState["lineas"], "Proyectado", ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id, ClienteDropDownList.SelectedValue.ToString(), PeriodoTextBox.Text, (CedEntidades.Sesion)Session["Sesion"]);
            LimpiarGrilla();
            LeerButton.Enabled = true;
            SeleccionPanel.Enabled = true;
            detalleGridView.Enabled = false;
            CancelarButton.Enabled = false;
            AceptarButton.Enabled = false;
        }

        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            LimpiarGrilla();
            LeerButton.Enabled = true;
            SeleccionPanel.Enabled = true;
            detalleGridView.Enabled = false;
            CancelarButton.Enabled = false;
            AceptarButton.Enabled = false;
        }

        protected void DivisionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
