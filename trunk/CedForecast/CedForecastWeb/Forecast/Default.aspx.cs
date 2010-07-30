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
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ((LinkButton)Master.FindControl("ForecastLinkButton")).ForeColor = System.Drawing.Color.DarkBlue;
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
                        ClienteDropDownList.DataValueField = "Id";
                        ClienteDropDownList.DataTextField = "DescrCombo";
                        ClienteDropDownList.DataSource = CedForecastWebRN.Cliente.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                        ClienteDropDownList.SelectedIndex = -1;

                        DivisionDropDownList.DataValueField = "Id";
                        DivisionDropDownList.DataTextField = "Descr";
                        DivisionDropDownList.DataSource = CedForecastWebRN.Division.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                        DivisionDropDownList.SelectedValue = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Division.Id;

                        FamiliaArticuloDropDownList.DataValueField = "Id";
                        FamiliaArticuloDropDownList.DataTextField = "Descr";
                        FamiliaArticuloDropDownList.DataSource = CedForecastWebRN.FamiliaArticulo.ListaConFamiliaArticuloSinInformar((CedForecastWebEntidades.Sesion)Session["Sesion"]);
                        FamiliaArticuloDropDownList.SelectedIndex = -1;

                        CedForecastWebEntidades.Periodo periodo = new CedForecastWebEntidades.Periodo();
                        periodo.IdTipoPlanilla = "RollingForecast";
                        CedForecastWebRN.Periodo.Leer(periodo, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                        PeriodoTextBox.Text = periodo.IdPeriodo;
                        PeriodoTextBox.ReadOnly = true;
                                               
                        DivisionDropDownList.SelectedValue = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Division.Id;
                        
                        FechaVtoConfimacionCargaLabel.Text = "Carga habilitada hasta el día: " + periodo.FechaInhabilitacionCarga.ToString("dd/MM/yyyy") + " inclusive.";
                        int colFijas = 5;
                        for (int i = 1; i <= 12; i++)
                        {
                            detalleGridView.Columns[i+colFijas].HeaderText = TextoCantidadHeader(i, PeriodoTextBox.Text);
                        }
                        detalleGridView.Columns[13 + colFijas].HeaderText = "Total";

                        DataBind();
                        
                        List<CedForecastWebEntidades.RFoPA> forecast = new List<CedForecastWebEntidades.RFoPA>();
                        BindearGrillayDropDownLists(forecast, "");

                        CancelarButton.Attributes.Add("onclick", "return confirm('Confirmar la cancelación de los datos ?');");
                        CancelarButton.Attributes.Add("title", "Cancela los datos ingresados en la grilla.");
                        AceptarButton.Attributes.Add("onclick", "return confirm('Confirmar la aceptación de los datos ?');");

                        CedForecastWebEntidades.ConfirmacionCarga confirmacionCarga = new CedForecastWebEntidades.ConfirmacionCarga();
                        confirmacionCarga.IdTipoPlanilla = "RollingForecast";
                        confirmacionCarga.IdPeriodo = periodo.IdPeriodo;
                        confirmacionCarga.Cuenta.Id = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
                        CedForecastWebRN.ConfirmacionCarga.Leer(confirmacionCarga, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                        LeerButton.Enabled = false;
                        ClienteDropDownList.Enabled = false;
                        ClienteLabel.Enabled = false;
                        PanelSeleccion.Enabled = true;
                        if ((!periodo.CargaHabilitada) || periodo.FechaInhabilitacionCarga < DateTime.Today)
                        {
                            ClienteDropDownList.Enabled = false;
                            MsgLabel.Text = " (Carga inhabilitada).";
                        }
                        else
                        {
                            switch (confirmacionCarga.IdEstadoConfirmacionCarga)
                            {
                                case "Baja":
                                case null:
                                    LeerButton.Enabled = true;
                                    ClienteDropDownList.Enabled = true;
                                    ClienteLabel.Enabled = true;
                                    break;
                                default:
                                    MsgLabel.Text = " (No es posible modificar los datos en el estado actual).";
                                    break;
                            }
                        }
                        detalleGridView.Enabled = false;
                        CancelarButton.Enabled = false;
                        AceptarButton.Enabled = false;
                    }
                }
            }
        }
        private void BindearGrillayDropDownLists(List<CedForecastWebEntidades.RFoPA> Forecast, string IdArticuloEnModificacion)
        {
            if (Forecast.Count > 0)
            {
                detalleGridView.DataSource = Forecast;
                detalleGridView.DataBind();
                ViewState["lineas"] = Forecast;
            }
            else
            {
                CedForecastWebEntidades.RFoPA vacio = new CedForecastWebEntidades.RFoPA();
                Forecast.Add(vacio);
                detalleGridView.DataSource = Forecast;
                detalleGridView.DataBind();
                ViewState["lineas"] = Forecast;

                int cantidadColumnas = detalleGridView.Rows[0].Cells.Count;
                detalleGridView.Rows[0].Cells.Clear();
                detalleGridView.Rows[0].Cells.Add(new TableCell());
                detalleGridView.Rows[0].Cells[0].ColumnSpan = cantidadColumnas;
                detalleGridView.Rows[0].Cells[0].Text = "No hay registros";
            }
            BindearDropDownLists(IdArticuloEnModificacion);
        }
        private void BindearDropDownLists(string IdArticuloEnModificacion)
        {
            string listaArticulosADescartar = ListaArticulosADescartar(IdArticuloEnModificacion);
            ((DropDownList)detalleGridView.FooterRow.FindControl("ddlIdArticulo")).DataValueField = "Id";
            ((DropDownList)detalleGridView.FooterRow.FindControl("ddlIdArticulo")).DataTextField = "DescrCombo";
            ((DropDownList)detalleGridView.FooterRow.FindControl("ddlIdArticulo")).DataSource = CedForecastWebRN.Articulo.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"], FamiliaArticuloDropDownList.SelectedValue, listaArticulosADescartar);
            ((DropDownList)detalleGridView.FooterRow.FindControl("ddlIdArticulo")).DataBind();
        }
        private string ListaArticulosADescartar(string IdArticuloEnModificacion)
        {
            string listaArticulosADescartar = "";
            for (int i = 0; i < ((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"]).Count; i++)
            {
                if (((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"])[i].Articulo.Id != null && IdArticuloEnModificacion != ((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"])[i].Articulo.Id.Trim())
                {
                    listaArticulosADescartar += "'" + ((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"])[i].Articulo.Id + "', ";
                }
            }
            if (listaArticulosADescartar != "")
            {
                listaArticulosADescartar = listaArticulosADescartar.Substring(0, listaArticulosADescartar.Length - 2);
            }
            return listaArticulosADescartar;
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

                //Modificación de articulo existente. ( El articulo ya existe en el ViewState y en un index distinto al que estoy modificando )
                if (e.RowIndex < ((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"]).Count)
                {
                    int indexArticulo =((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"]).FindIndex((delegate(CedForecastWebEntidades.RFoPA e1) { return e1.Articulo.Id == auxIdArticulo; }));
                    if (indexArticulo >= 0 && e.RowIndex != indexArticulo)
                    {
                        throw new Exception("Articulo ya ingresado.");
                    }
                }
                //Articulo nuevo. ( El e.RowIndex es mayor al ultimo del ViewState )
                else
                {
                    CedForecastWebEntidades.RFoPA forecast = ((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"]).Find((delegate(CedForecastWebEntidades.RFoPA e1) { return e1.Articulo.Id == auxIdArticulo; }));
                    if (forecast != null && forecast.Articulo.Id == auxIdArticulo)
                    {
                        throw new Exception("Articulo ya ingresado.");
                    }
                }
                List<CedForecastWebEntidades.RFoPA> lineas = ((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"]);

                CedForecastWebEntidades.RFoPA l = lineas[e.RowIndex];
               
                int sumaCantidades = 0;
                for (int i = 1; i < 13; i++)
                {
                    sumaCantidades += Convert.ToInt32(((TextBox)((GridView)sender).Rows[e.RowIndex].FindControl("txtCantidad" + i.ToString() + "Edit")).Text);
                }
                if (sumaCantidades == 0)
                {
                    throw new Exception("Debe informar por lo menos un dato para el articulo seleccionado.");
                }

                string auxDescrArticulo = ((DropDownList)detalleGridView.Rows[e.RowIndex].FindControl("ddlIdArticuloEdit")).SelectedItem.Text;
                if (auxIdArticulo.Equals(string.Empty))
                {
                    throw new Exception("Detalle no actualizado porque la descripción del artículo no puede estar vacía");
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

                detalleGridView.EditIndex = -1;
                detalleGridView.DataSource = ViewState["lineas"];
                detalleGridView.DataBind();
                BindearGrillayDropDownLists(((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"]), "");
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
                    CedForecastWebEntidades.RFoPA forecast = ((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"]).Find((delegate(CedForecastWebEntidades.RFoPA e1) { return e1.Articulo.Id == auxIdArticulo; }));
                    if (forecast != null && forecast.Articulo.Id == auxIdArticulo)
                    {
                        throw new Exception("Articulo ya ingresado.");
                    }

                    CedForecastWebEntidades.RFoPA l = new CedForecastWebEntidades.RFoPA();
                    l.IdCuenta = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
                    l.Articulo.GrupoArticulo.Division.Id = DivisionDropDownList.SelectedValue;
                    l.Cliente.Id = ClienteDropDownList.SelectedValue;
                    l.IdPeriodo = PeriodoTextBox.Text;
                    l.IdTipoPlanilla = "RollingForecast";
                    
                    if (!auxIdArticulo.Equals(string.Empty))
                    {
                        l.Articulo = new CedForecastWebEntidades.Articulo();
                        l.Articulo.Id = auxIdArticulo;
                        List<CedForecastWebEntidades.Articulo> ArticuloLista = new List<CedForecastWebEntidades.Articulo>();
                        string listaArticulosADescartar = ListaArticulosADescartar("");
                        ArticuloLista = CedForecastWebRN.Articulo.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"], FamiliaArticuloDropDownList.SelectedValue, listaArticulosADescartar);
                        CedForecastWebEntidades.Articulo articulo = new CedForecastWebEntidades.Articulo();
                        articulo = ArticuloLista.Find((delegate(CedForecastWebEntidades.Articulo e1) { return e1.Id == auxIdArticulo; }));
                        l.Articulo.Descr = articulo.Descr;
                    }
                    else
                    {
                        throw new Exception("Seleccione un artículo");
                    }
                    
                    List<CedForecastWebEntidades.Venta> ventaLista = new List<CedForecastWebEntidades.Venta>();
                    ventaLista = CedForecastWebRN.Venta.ConsultarTotales(PrimerMes(l.IdPeriodo), l.IdPeriodo, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                    CedForecastWebEntidades.Venta venta = new CedForecastWebEntidades.Venta();
                    venta = ventaLista.Find((delegate(CedForecastWebEntidades.Venta e1) { return e1.IdCliente == l.IdCliente && e1.IdArticulo == l.Articulo.Id; }));
                    if (venta != null)
                    {
                        l.Ventas = venta.Cantidad;
                    }

                    List<CedForecastWebEntidades.RFoPA> totalProyectadoLista = new List<CedForecastWebEntidades.RFoPA>();
                    totalProyectadoLista = CedForecastWebRN.RFoPA.TotalProyectado(l, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                    CedForecastWebEntidades.RFoPA totalProyectado = new CedForecastWebEntidades.RFoPA();
                    totalProyectado = totalProyectadoLista.Find((delegate(CedForecastWebEntidades.RFoPA e1) { return e1.IdCliente == l.IdCliente && e1.Articulo.Id == l.Articulo.Id; }));
                    if (totalProyectado != null)
                    {
                        l.Proyectado = totalProyectado.Proyectado;
                    }
                    
                    int sumaCantidades = 0;
                    for (int i = 1; i < 13; i++)
                    {
                        sumaCantidades += Convert.ToInt32(((TextBox)detalleGridView.FooterRow.FindControl("txtCantidad" + i.ToString())).Text);
                    }
                    if (sumaCantidades == 0)
                    {
                        throw new Exception("Debe informar por lo menos un dato para el articulo seleccionado.");
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

                    //Agrego la nueva linea
                    ((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"]).Add(l);

                    //Me fijo si elimino la fila automática
                    List<CedForecastWebEntidades.RFoPA> lineas = ((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"]);
                    CedForecastWebEntidades.RFoPA lineaInicial = lineas[0];
                    if (lineaInicial.IdCuenta == null)
                    {
                        ((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"]).Remove(lineaInicial);
                    }
                    detalleGridView.DataSource = ViewState["lineas"];
                    detalleGridView.DataBind();

                    BindearGrillayDropDownLists(((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"]), "");
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
                }
            }
        }
        private string PrimerMes(string Periodo)
        {
            DateTime primerMes = new DateTime(Convert.ToInt32(Periodo.Substring(0, 4)), Convert.ToInt32("01"), Convert.ToInt32("01"));
            return primerMes.ToString("yyyyMM");
        }
        private string TextoCantidadHeader(int ColCantidad, string PeriodoInicial)
        {
            DateTime fechaAux = new DateTime(Convert.ToInt32(PeriodoInicial.Substring(0, 4)), Convert.ToInt32(PeriodoInicial.Substring(4, 2)), Convert.ToInt32("01"));
            fechaAux = fechaAux.AddMonths(ColCantidad - 1);
            return fechaAux.ToString("MM-yyyy");
        }
        protected void detalleGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            detalleGridView.EditIndex = -1;
            detalleGridView.DataSource = ViewState["lineas"];
            detalleGridView.DataBind();
            BindearGrillayDropDownLists(((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"]), "");
        }
        protected void detalleGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            detalleGridView.EditIndex = e.NewEditIndex;
            detalleGridView.DataSource = ViewState["lineas"];
            detalleGridView.DataBind();
            string idArticuloAModficar = ((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"])[e.NewEditIndex].Articulo.Id.ToString();
            BindearGrillayDropDownLists(((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"]), idArticuloAModficar);
            string listaArticulosADescartar = ListaArticulosADescartar(idArticuloAModficar);
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlIdArticuloEdit")).DataValueField = "Id";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlIdArticuloEdit")).DataTextField = "DescrCombo";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlIdArticuloEdit")).DataSource = CedForecastWebRN.Articulo.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"], FamiliaArticuloDropDownList.SelectedValue, listaArticulosADescartar);
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlIdArticuloEdit")).DataBind();
            try
            {
                ListItem liUnidad = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlIdArticuloEdit")).Items.FindByValue(((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"])[e.NewEditIndex].Articulo.Id.ToString());
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
                List<CedForecastWebEntidades.RFoPA> lineas = ((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"]);
                CedForecastWebEntidades.RFoPA l = lineas[e.RowIndex];
                lineas.Remove(l);

                if (lineas.Count.Equals(0))
                {
                    CedForecastWebEntidades.RFoPA nueva = new CedForecastWebEntidades.RFoPA();
                    lineas.Add(nueva);
                }

                detalleGridView.EditIndex = -1;

                detalleGridView.DataSource = ViewState["lineas"];
                detalleGridView.DataBind();
                BindearGrillayDropDownLists(((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"]), "");
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
                CedForecastWebEntidades.RFoPA forecast = new CedForecastWebEntidades.RFoPA();
                forecast.IdCuenta = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
                forecast.IdPeriodo = PeriodoTextBox.Text;
                forecast.IdTipoPlanilla = "RollingForecast";
                if (!ClienteDropDownList.SelectedValue.Equals(string.Empty))
                {
                    forecast.Cliente.Id = ClienteDropDownList.SelectedValue;
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
                    throw new Exception("División no seleccionada");
                }
                if (!FamiliaArticuloDropDownList.SelectedValue.Equals(string.Empty))
                {
                    forecast.Articulo.FamiliaArticulo.Id = FamiliaArticuloDropDownList.SelectedValue;
                }
                List<CedForecastWebEntidades.RFoPA> forecastLista = CedForecastWebRN.RFoPA.Lista(forecast, (CedEntidades.Sesion)Session["Sesion"]);
                //Si no hay datos ingresados para el forecast, buscar información inicial del proyectado
                //if (forecastLista == null)

                BindearGrillayDropDownLists(forecastLista, "");
               
                LeerButton.Enabled = false;
                PanelSeleccion.Enabled = false;
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
            CedForecastWebRN.RFoPA.Guardar((List<CedForecastWebEntidades.RFoPA>)ViewState["lineas"], "RollingForecast", ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id, ClienteDropDownList.SelectedValue.ToString(), FamiliaArticuloDropDownList.SelectedValue.ToString().Trim(), PeriodoTextBox.Text, (CedEntidades.Sesion)Session["Sesion"]);
            List<CedForecastWebEntidades.RFoPA> forecast = new List<CedForecastWebEntidades.RFoPA>();
            ViewState["lineas"] = forecast;
            BindearGrillayDropDownLists(forecast, "");
            LeerButton.Enabled = true;
            PanelSeleccion.Enabled = true;
            detalleGridView.Enabled = false;
            CancelarButton.Enabled = false;
            AceptarButton.Enabled = false;
            //ClienteDropDownList.SelectedIndex = -1;
            //FamiliaArticuloDropDownList.SelectedIndex = -1;
        }

        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            List<CedForecastWebEntidades.RFoPA> forecast = new List<CedForecastWebEntidades.RFoPA>();
            ViewState["lineas"] = forecast;
            BindearGrillayDropDownLists(forecast, "");
            LeerButton.Enabled = true;
            PanelSeleccion.Enabled = true;
            detalleGridView.Enabled = false;
            CancelarButton.Enabled = false;
            AceptarButton.Enabled = false;
            //ClienteDropDownList.SelectedIndex = -1;
            //FamiliaArticuloDropDownList.SelectedIndex = -1;
        }

        protected void DivisionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void detalleGridView_PreRender(object sender, EventArgs e)
        {
            int ultimaColumna = detalleGridView.Columns.Count - 1;
            TableCell cell1 = detalleGridView.FooterRow.Cells[1];
            TableCell cell0 = detalleGridView.FooterRow.Cells[0];
            detalleGridView.FooterRow.Cells.RemoveAt(1);
            detalleGridView.FooterRow.Cells.RemoveAt(0);
            detalleGridView.FooterRow.Cells.AddAt(0, cell1);
            detalleGridView.FooterRow.Cells.AddAt(1, cell0);
        }
    }
}
