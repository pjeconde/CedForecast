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

namespace CedForecastWeb.Admin.Cuenta
{
	public partial class Explorador : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				((LinkButton)Master.FindControl("AdministracionLinkButton")).ForeColor = System.Drawing.Color.Gold;
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
							CuentaPagingGridView.PageSize = 15;
							BindPagingGrid();
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
				System.Collections.Generic.List<CedForecastWebEntidades.Cuenta> lista;
				lista = CedForecastWebRN.Cuenta.Lista(CuentaPagingGridView.PageIndex, CuentaPagingGridView.PageSize, CuentaPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
				CuentaPagingGridView.VirtualItemCount = CedForecastWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
				ViewState["lista"] = lista;
				CuentaPagingGridView.DataSource = (System.Collections.Generic.List<CedForecastWebEntidades.Cuenta>)ViewState["lista"];
				CuentaPagingGridView.DataBind();
			}
			catch (System.Threading.ThreadAbortException)
			{
				Trace.Warn("Thread abortado");
			}
		}
		protected void CuentaPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			try
			{
				DesSeleccionarFilas();
				CuentaPagingGridView.PageIndex = e.NewPageIndex;
				System.Collections.Generic.List<CedForecastWebEntidades.Cuenta> lista;
				lista = CedForecastWebRN.Cuenta.Lista(CuentaPagingGridView.PageIndex, CuentaPagingGridView.PageSize, CuentaPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
				CuentaPagingGridView.VirtualItemCount = CedForecastWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
				ViewState["lista"] = lista;
				CuentaPagingGridView.DataSource = lista;
				CuentaPagingGridView.DataBind();
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
		protected void CuentaPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
		{
			try
			{
				DesSeleccionarFilas();
				System.Collections.Generic.List<CedForecastWebEntidades.Cuenta> lista;
				lista = CedForecastWebRN.Cuenta.Lista(CuentaPagingGridView.PageIndex, CuentaPagingGridView.PageSize, CuentaPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
				ViewState["lista"] = lista;
				CuentaPagingGridView.DataSource = (System.Collections.Generic.List<CedForecastWebEntidades.Cuenta>)ViewState["lista"];
				CuentaPagingGridView.DataBind();
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
		protected void CuentaPagingGridView_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				DeshabilitarAcciones();
				System.Collections.Generic.List<CedForecastWebEntidades.Cuenta> lista = (System.Collections.Generic.List<CedForecastWebEntidades.Cuenta>)ViewState["lista"];
				CedForecastWebEntidades.Cuenta cuenta = new CedForecastWebEntidades.Cuenta();
				cuenta = (CedForecastWebEntidades.Cuenta)lista[((CedeiraUIWebForms.PagingGridView)sender).SelectedIndex];
				string auxCache = "Cuenta" + Session.SessionID;
				Cache.Remove(auxCache);
				Cache.Add(auxCache, cuenta, null, DateTime.UtcNow.AddSeconds(300), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.NotRemovable, null);
				HabilitarAcciones(cuenta);
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
		protected void CuentaPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
				e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

				e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.CuentaPagingGridView, "Select$" + e.Row.RowIndex);
			}
		}
		private void DesSeleccionarFilas()
		{
			DeshabilitarAcciones();
			CuentaPagingGridView.SelectedIndex = -1;
		}
		private void HabilitarAcciones(CedForecastWebEntidades.Cuenta Cuenta)
		{
			switch (Cuenta.EstadoCuenta.Id)
			{
				case "Vigente":
					BajaButton.Enabled = true;
					break;
				case "Baja":
					AnularBajaButton.Enabled = true;
					break;
				case "PteConf":
					BajaButton.Enabled = true;
					ReenviarMailButton.Enabled = true;
					break;
				case "Suspend":
                    //ActivarButton.Enabled = true;
					break;
			}
		}
		private void DeshabilitarAcciones()
		{
			BajaButton.Enabled = false;
			AnularBajaButton.Enabled = false;
			ReenviarMailButton.Enabled = false;
            //ActivarButton.Enabled = false;
            //SuspenderPremiumButton.Enabled = false;
            //ActivarPremiumButton.Enabled = false;
            //DesactivarPremiumButton.Enabled = false;
		}
		protected CedForecastWebEntidades.Cuenta CuentaSeleccionada()
		{
			System.Collections.Generic.List<CedForecastWebEntidades.Cuenta> lista = (System.Collections.Generic.List<CedForecastWebEntidades.Cuenta>)ViewState["lista"];
			return (CedForecastWebEntidades.Cuenta)lista[CuentaPagingGridView.SelectedIndex];
		}
		protected void BajaButton_Click(object sender, EventArgs e)
		{
			MsgErrorLabel.Text = String.Empty;
			try
			{
				CedForecastWebRN.Cuenta.DarDeBaja(CuentaSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
				BindPagingGrid();
				DesSeleccionarFilas();
			}
			catch (Exception ex)
			{
				MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
			}
		}
		protected void AnularBajaButton_Click(object sender, EventArgs e)
		{
			MsgErrorLabel.Text = String.Empty;
			try
			{
				CedForecastWebRN.Cuenta.AnularBaja(CuentaSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
				BindPagingGrid();
				DesSeleccionarFilas();
			}
			catch (Exception ex)
			{
				MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
			}
		}
		protected void ReenviarMailButton_Click(object sender, EventArgs e)
		{
			MsgErrorLabel.Text = String.Empty;
			try
			{
				CedForecastWebRN.Cuenta.ReenviarMail(CuentaSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
				BindPagingGrid();
				DesSeleccionarFilas();
			}
			catch (Exception ex)
			{
				MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
			}
		}
		protected void DepurarButton_Click(object sender, EventArgs e)
		{
			MsgErrorLabel.Text = String.Empty;
			try
			{
				CedForecastWebRN.Cuenta.Depurar((CedForecastWebEntidades.Sesion)Session["Sesion"]);
				BindPagingGrid();
				DesSeleccionarFilas();
			}
			catch (Exception ex)
			{
				MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
			}
		}
		protected void SalirButton_Click(object sender, EventArgs e)
		{
			Server.Transfer("~/Admin/Default.aspx");
		}

        protected void CrearButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/CuentaCrear.aspx");
        }

	}
}
