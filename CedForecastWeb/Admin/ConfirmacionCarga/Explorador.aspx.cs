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

namespace CedForecastWeb.Admin.ConfirmacionCarga
{
	public partial class Explorador : System.Web.UI.Page
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
							ConfirmacionCargaPagingGridView.PageSize = 15;
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
				System.Collections.Generic.List<CedForecastWebEntidades.ConfirmacionCarga> lista;
                CedForecastWebEntidades.ConfirmacionCarga confirmacionCarga = new CedForecastWebEntidades.ConfirmacionCarga();
                lista = CedForecastWebRN.ConfirmacionCarga.Lista(ConfirmacionCargaPagingGridView.PageIndex, ConfirmacionCargaPagingGridView.PageSize, ConfirmacionCargaPagingGridView.OrderBy, confirmacionCarga, (CedEntidades.Sesion)Session["Sesion"]);
				ConfirmacionCargaPagingGridView.VirtualItemCount = CedForecastWebRN.ConfirmacionCarga.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
				ViewState["lista"] = lista;
				ConfirmacionCargaPagingGridView.DataSource = (System.Collections.Generic.List<CedForecastWebEntidades.ConfirmacionCarga>)ViewState["lista"];
				ConfirmacionCargaPagingGridView.DataBind();
			}
			catch (System.Threading.ThreadAbortException)
			{
				Trace.Warn("Thread abortado");
			}
		}
		protected void ConfirmacionCargaPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			try
			{
				DesSeleccionarFilas();
				ConfirmacionCargaPagingGridView.PageIndex = e.NewPageIndex;
				System.Collections.Generic.List<CedForecastWebEntidades.ConfirmacionCarga> lista;
                CedForecastWebEntidades.ConfirmacionCarga confirmacionCarga = new CedForecastWebEntidades.ConfirmacionCarga();
				lista = CedForecastWebRN.ConfirmacionCarga.Lista(ConfirmacionCargaPagingGridView.PageIndex, ConfirmacionCargaPagingGridView.PageSize, ConfirmacionCargaPagingGridView.OrderBy, confirmacionCarga, (CedEntidades.Sesion)Session["Sesion"]);
				ConfirmacionCargaPagingGridView.VirtualItemCount = CedForecastWebRN.ConfirmacionCarga.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
				ViewState["lista"] = lista;
				ConfirmacionCargaPagingGridView.DataSource = lista;
				ConfirmacionCargaPagingGridView.DataBind();
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
		protected void ConfirmacionCargaPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
		{
			try
			{
				DesSeleccionarFilas();
				System.Collections.Generic.List<CedForecastWebEntidades.ConfirmacionCarga> lista;
                CedForecastWebEntidades.ConfirmacionCarga confirmacionCarga = new CedForecastWebEntidades.ConfirmacionCarga();
				lista = CedForecastWebRN.ConfirmacionCarga.Lista(ConfirmacionCargaPagingGridView.PageIndex, ConfirmacionCargaPagingGridView.PageSize, ConfirmacionCargaPagingGridView.OrderBy, confirmacionCarga, (CedEntidades.Sesion)Session["Sesion"]);
				ViewState["lista"] = lista;
				ConfirmacionCargaPagingGridView.DataSource = (System.Collections.Generic.List<CedForecastWebEntidades.ConfirmacionCarga>)ViewState["lista"];
				ConfirmacionCargaPagingGridView.DataBind();
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
		protected void ConfirmacionCargaPagingGridView_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				DeshabilitarAcciones();
				System.Collections.Generic.List<CedForecastWebEntidades.ConfirmacionCarga> lista = (System.Collections.Generic.List<CedForecastWebEntidades.ConfirmacionCarga>)ViewState["lista"];
				CedForecastWebEntidades.ConfirmacionCarga confirmacionCarga = new CedForecastWebEntidades.ConfirmacionCarga();
				confirmacionCarga = (CedForecastWebEntidades.ConfirmacionCarga)lista[((CedeiraUIWebForms.PagingGridView)sender).SelectedIndex];
				string auxCache = "confirmacionCarga" + Session.SessionID;
				Cache.Remove(auxCache);
				Cache.Add(auxCache, confirmacionCarga, null, DateTime.UtcNow.AddSeconds(300), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                HabilitarAcciones(confirmacionCarga);
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
		protected void ConfirmacionCargaPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
				e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
				e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.ConfirmacionCargaPagingGridView, "Select$" + e.Row.RowIndex);
			}
		}
		private void DesSeleccionarFilas()
		{
			DeshabilitarAcciones();
			ConfirmacionCargaPagingGridView.SelectedIndex = -1;
            ComentarioTextBox.Text = "";
		}
        private void HabilitarAcciones(CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCarga)
		{
            CedForecastWebEntidades.ConfirmacionCarga cc = new CedForecastWebEntidades.ConfirmacionCarga();
            cc.IdTipoPlanilla = ConfirmacionCarga.IdTipoPlanilla;
            cc.IdPeriodo = ConfirmacionCarga.IdPeriodo;
            cc.Cuenta.Id = ConfirmacionCarga.IdCuenta;
            CedForecastWebRN.ConfirmacionCarga.UltimoRegistro(cc, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
            AceptarButton.Enabled = false;
            RechazarButton.Enabled = false;
            if (cc.FechaConfirmacionCarga == ConfirmacionCarga.FechaConfirmacionCarga)
            {
                switch (ConfirmacionCarga.IdEstadoConfirmacionCarga)
                {
                    case "Vigente":
                        AceptarButton.Enabled = true;
                        RechazarButton.Enabled = true;
                        break;
                    case "Aceptada":
                        AceptarButton.Enabled = false;
                        RechazarButton.Enabled = true;
                        break;
                    case "Rechazada":
                        AceptarButton.Enabled = true;
                        RechazarButton.Enabled = false;
                        break;
                }
            }
		}
		private void DeshabilitarAcciones()
		{
			AceptarButton.Enabled = false;
			RechazarButton.Enabled = false;
		}
        protected CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCargaSeleccionada()
		{
			System.Collections.Generic.List<CedForecastWebEntidades.ConfirmacionCarga> lista = (System.Collections.Generic.List<CedForecastWebEntidades.ConfirmacionCarga>)ViewState["lista"];
			return (CedForecastWebEntidades.ConfirmacionCarga)lista[ConfirmacionCargaPagingGridView.SelectedIndex];
		}
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
            try
            {
                CedForecastWebEntidades.ConfirmacionCarga confirmacionCarga = new CedForecastWebEntidades.ConfirmacionCarga();
                confirmacionCarga = ConfirmacionCargaSeleccionada();
                string EstadoActual = confirmacionCarga.IdEstadoConfirmacionCarga;
                confirmacionCarga.IdEstadoConfirmacionCarga = "Aceptada";
                confirmacionCarga.Comentario = ComentarioTextBox.Text;
                CedForecastWebRN.ConfirmacionCarga.RegistrarAceptacionORechazo(confirmacionCarga, EstadoActual, (CedEntidades.Sesion)Session["Sesion"]);
                BindPagingGrid();
                DesSeleccionarFilas();
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
		protected void RechazarButton_Click(object sender, EventArgs e)
		{
			MsgErrorLabel.Text = String.Empty;
			try
			{
                CedForecastWebEntidades.ConfirmacionCarga confirmacionCarga = new CedForecastWebEntidades.ConfirmacionCarga();
                confirmacionCarga = ConfirmacionCargaSeleccionada();
                string EstadoActual = confirmacionCarga.IdEstadoConfirmacionCarga;
                confirmacionCarga.IdEstadoConfirmacionCarga = "Rechazada";
                confirmacionCarga.Comentario = ComentarioTextBox.Text;
                CedForecastWebRN.ConfirmacionCarga.RegistrarAceptacionORechazo(confirmacionCarga, EstadoActual, (CedEntidades.Sesion)Session["Sesion"]);
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
	}
}
