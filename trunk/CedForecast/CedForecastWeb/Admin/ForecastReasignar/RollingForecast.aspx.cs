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

namespace CedForecastWeb.Admin.ForecastReasignar
{
	public partial class RollingForecast : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
                ((LinkButton)Master.FindControl("AdministracionLinkButton")).ForeColor = System.Drawing.Color.DarkBlue;
                if (!IsPostBack)
                {
                    if (CedForecastWebRN.Fun.NoHayNadieLogueado((CedForecastWebEntidades.Sesion)Session["Sesion"]))
                    {
                        CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosAdministradores.aspx");
                    }
                    else
                    {
                        if (CedForecastWebRN.Fun.NoEstaLogueadoUnAdministrador((CedForecastWebEntidades.Sesion)Session["Sesion"]))
                        {
                            CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosAdministradores.aspx");
                        }
                        else
  						{
							ForecastPagingGridView.PageSize = 10;

                            ClienteDropDownList.DataValueField = "Id";
                            ClienteDropDownList.DataTextField = "DescrCombo";
                            ClienteDropDownList.DataSource = CedForecastWebRN.Cliente.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                            ClienteDropDownList.SelectedIndex = -1;

                            CuentaDropDownList.DataValueField = "Id";
                            CuentaDropDownList.DataTextField = "DescrCombo";
                            CuentaDropDownList.DataSource = CedForecastWebRN.Cuenta.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                            CuentaDropDownList.SelectedIndex = -1;

                            CuentaAReasignarDropDownList.DataValueField = "Id";
                            CuentaAReasignarDropDownList.DataTextField = "DescrCombo";
                            CuentaAReasignarDropDownList.DataSource = CedForecastWebRN.Cuenta.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                            CuentaAReasignarDropDownList.SelectedIndex = -1;

                            ClienteAReasignarDropDownList.DataValueField = "Id";
                            ClienteAReasignarDropDownList.DataTextField = "DescrCombo";
                            ClienteAReasignarDropDownList.DataSource = CedForecastWebRN.Cliente.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                            ClienteAReasignarDropDownList.SelectedIndex = -1;

                            CancelarButton.Attributes.Add("onclick", "return confirm('Confirma la cancelación de los datos a reasignar ?');");
                            AceptarButton.Attributes.Add("onclick", "return confirm('Confirma la aceptación de los datos a reasignar ?');");

                            DataBind();

                            PeriodoTextBox.Text = "";
                            MsgErrorLabel.Text = "";
                            AceptarButton.Enabled = false;
                            CancelarButton.Enabled = false;
                            CuentaAReasignarDropDownList.Enabled = false;
                            ClienteAReasignarDropDownList.Enabled = false;
						}
					}
				}
			}
			catch (System.Threading.ThreadAbortException)
			{
				Trace.Warn("Thread abortado");
			}
			catch (Exception ex)
			{
				MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
			}
		}
		private void BindPagingGrid()
		{
			try
			{
                MsgErrorLabel.Text = "";
				System.Collections.Generic.List<CedForecastWebEntidades.RFoPA> lista;
                CedForecastWebEntidades.RFoPA Forecast = new CedForecastWebEntidades.RFoPA();
                Forecast.IdTipoPlanilla = "RollingForecast";
                Forecast.IdCuenta = CuentaDropDownList.SelectedValue;
                if (Forecast.IdCuenta.Trim() == "")
                {
                     throw new Exception("Seleccione el vendedor.");
                }
                if (PeriodoTextBox.Text.Trim() == "")
                {
                    throw new Exception("Seleccione un período.");
                }
                CedForecastWebRN.Periodo.ValidarPeriodoYYYYMM(PeriodoTextBox.Text);
                Forecast.IdPeriodo = PeriodoTextBox.Text;
                Forecast.Cliente.Id = ClienteDropDownList.SelectedValue;
                if (Forecast.IdCliente.Trim() == "")
                {
                    throw new Exception("Seleccione el cliente.");
                }
                int CantidadFilas = 0;
                lista = CedForecastWebRN.RFoPA.Lista(out CantidadFilas, ForecastPagingGridView.PageIndex, ForecastPagingGridView.PageSize, ForecastPagingGridView.OrderBy, Forecast, Session.SessionID, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                int colFijas = 6; //Es 0 y 1.
                for (int i = 1; i <= 12; i++)
                {
                    ForecastPagingGridView.Columns[i + colFijas].HeaderText = TextoCantidadHeader(i, PeriodoTextBox.Text);
                }
                ForecastPagingGridView.Columns[13 + colFijas].HeaderText = "Total";
                ForecastPagingGridView.VirtualItemCount = CantidadFilas;
				ViewState["lista"] = lista;
				ForecastPagingGridView.DataSource = (System.Collections.Generic.List<CedForecastWebEntidades.RFoPA>)ViewState["lista"];
				ForecastPagingGridView.DataBind();
                AceptarButton.Enabled = true;
                CancelarButton.Enabled = true;
                PanelSeleccion.Enabled = false;
                LeerButton.Enabled = false;
                CuentaAReasignarDropDownList.Enabled = true;
                ClienteAReasignarDropDownList.Enabled = true;
                CuentaAReasignarDropDownList.SelectedIndex = -1;
                ClienteAReasignarDropDownList.SelectedIndex = -1;
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
        private string TextoCantidadHeader(int ColCantidad, string PeriodoInicial)
        {
            DateTime fechaAux = Convert.ToDateTime("01/" + PeriodoInicial.Substring(4, 2) + "/" + PeriodoInicial.Substring(0, 4));
            fechaAux = fechaAux.AddMonths(ColCantidad - 1);
            return fechaAux.ToString("MM-yyyy");
        }
		protected void ForecastPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			try
			{
				DesSeleccionarFilas();
				ForecastPagingGridView.PageIndex = e.NewPageIndex;
				System.Collections.Generic.List<CedForecastWebEntidades.RFoPA> lista;
                CedForecastWebEntidades.RFoPA Forecast = new CedForecastWebEntidades.RFoPA();
                Forecast.IdTipoPlanilla = "RollingForecast";
                Forecast.IdCuenta = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
                Forecast.IdPeriodo = PeriodoTextBox.Text;
                int CantidadFilas = 0;
                lista = CedForecastWebRN.RFoPA.Lista(out CantidadFilas, ForecastPagingGridView.PageIndex, ForecastPagingGridView.PageSize, ForecastPagingGridView.OrderBy, Forecast, Session.SessionID, (CedEntidades.Sesion)Session["Sesion"]);
                ForecastPagingGridView.VirtualItemCount = CantidadFilas;
				ViewState["lista"] = lista;
				ForecastPagingGridView.DataSource = lista;
				ForecastPagingGridView.DataBind();
			}
			catch (System.Threading.ThreadAbortException)
			{
				Trace.Warn("Thread abortado.");
			}
			catch (Exception ex)
			{
				CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Excepcion.aspx");
			}
		}
		protected void ForecastPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
		{
			try
			{
                DesSeleccionarFilas();
                System.Collections.Generic.List<CedForecastWebEntidades.RFoPA> lista = new System.Collections.Generic.List<CedForecastWebEntidades.RFoPA>();
                CedForecastWebEntidades.RFoPA Forecast = new CedForecastWebEntidades.RFoPA();
                Forecast.IdTipoPlanilla = "RollingForecast";
                Forecast.IdCuenta = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
                Forecast.IdPeriodo = PeriodoTextBox.Text;
                int CantidadFilas = 0;
                lista = CedForecastWebRN.RFoPA.Lista(out CantidadFilas, ForecastPagingGridView.PageIndex, ForecastPagingGridView.PageSize, ForecastPagingGridView.OrderBy, Forecast, Session.SessionID, (CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                ForecastPagingGridView.DataSource = (System.Collections.Generic.List<CedForecastWebEntidades.RFoPA>)ViewState["lista"];
                ForecastPagingGridView.DataBind();
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
		protected void ForecastPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
				e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
				e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.ForecastPagingGridView, "Select$" + e.Row.RowIndex);
			}
		}
		private void DesSeleccionarFilas()
		{
			ForecastPagingGridView.SelectedIndex = -1;
		}
		protected CedForecastWebEntidades.RFoPA ForecastSeleccionado()
		{
			System.Collections.Generic.List<CedForecastWebEntidades.RFoPA> lista = (System.Collections.Generic.List<CedForecastWebEntidades.RFoPA>)ViewState["lista"];
			return (CedForecastWebEntidades.RFoPA)lista[ForecastPagingGridView.SelectedIndex];
		}
		protected void CancelarButton_Click(object sender, EventArgs e)
		{
            AceptarButton.Enabled = false;
            CancelarButton.Enabled = false;
            CuentaAReasignarDropDownList.Enabled = false;
            ClienteAReasignarDropDownList.Enabled = false;
            PanelSeleccion.Enabled = true;
            LeerButton.Enabled = true;
		}
        protected void LeerButton_Click(object sender, EventArgs e)
        {
            BindPagingGrid();
        }

        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Collections.Generic.List<CedForecastWebEntidades.RFoPA> lista;
                CedForecastWebEntidades.RFoPA Forecast = new CedForecastWebEntidades.RFoPA();
                Forecast.IdTipoPlanilla = "RollingForecast";
                Forecast.IdCuenta = CuentaDropDownList.SelectedValue;
                CedForecastWebRN.Periodo.ValidarPeriodoYYYYMM(PeriodoTextBox.Text);
                Forecast.IdPeriodo = PeriodoTextBox.Text;
                Forecast.Cliente.Id = ClienteDropDownList.SelectedValue;
                if (CuentaAReasignarDropDownList.SelectedValue.Trim() != "" && ClienteAReasignarDropDownList.SelectedValue.Trim() != "")
                {
                    throw new Exception("Seleccione un vendedor o un cliente, no ambos.");
                }
                if (CuentaAReasignarDropDownList.SelectedValue.Trim() == "" && ClienteAReasignarDropDownList.SelectedValue.Trim() == "")
                {
                    throw new Exception("Seleccione un vendedor o un cliente, al cual asignar los datos.");
                }
                lista = CedForecastWebRN.RFoPA.Lista(Forecast, (CedEntidades.Sesion)Session["Sesion"]);
                if (lista.Count == 0)
                {
                    throw new Exception("No hay datos a reasignar, para la selección realizada.");
                }
                else
                {
                    if (CuentaAReasignarDropDownList.SelectedValue != "")
                    {
                        CedForecastWebRN.ForecastReasignar.Modificar(lista, "Cuenta", CuentaAReasignarDropDownList.SelectedValue.Trim(), PeriodoTextBox.Text, (CedEntidades.Sesion)Session["Sesion"]);
                    }
                    else
                    {
                        CedForecastWebRN.ForecastReasignar.Modificar(lista, "Cliente", ClienteAReasignarDropDownList.SelectedValue.Trim(), PeriodoTextBox.Text, (CedEntidades.Sesion)Session["Sesion"]);
                    }
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
            finally
            {
                AceptarButton.Enabled = false;
                CancelarButton.Enabled = false;
                CuentaAReasignarDropDownList.Enabled = false;
                ClienteAReasignarDropDownList.Enabled = false;
                PanelSeleccion.Enabled = true;
                LeerButton.Enabled = true;
                MsgErrorLabel.Text = "El cambio se ha realizado correctamente.";
            }
        }
	}
}
