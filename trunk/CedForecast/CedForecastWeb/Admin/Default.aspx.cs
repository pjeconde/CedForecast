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
using System.Collections.Generic;

namespace CedForecastWeb.Admin
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
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
						ModoDepuracionCheckBox.Checked = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Flag.ModoDepuracion;
						RecibeAvisoAltaCuentaCheckBox.Checked = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.RecibeAvisoAltaCuenta;

						UltimasAltasPagingGridView.PageSize = 6;
						System.Collections.Generic.List<CedForecastWebEntidades.Cuenta> listaUltimasAltas;
						listaUltimasAltas = CedForecastWebRN.Cuenta.Lista(UltimasAltasPagingGridView.PageIndex, UltimasAltasPagingGridView.PageSize, "FechaAlta DESC", (CedEntidades.Sesion)Session["Sesion"]);
						UltimasAltasPagingGridView.VirtualItemCount = CedForecastWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
						UltimasAltasPagingGridView.DataSource = listaUltimasAltas;
						UltimasAltasPagingGridView.DataBind();

						try
						{
							//Borro los gráficos anteriores
							if (((TimeSpan)DateTime.Now.Subtract(LastOldFileRemoveDate)).Days > 0)
							{
								DeleteOldTempFiles("~/Temp", 1);
							}
						}
						catch
						{

						}
					}
				}
			}
			VisitantesLabel.Text = Convert.ToInt32(Application["Visitantes"]).ToString("0000");
			RegistradosLabel.Text = Convert.ToInt32(Application["Registrados"]).ToString("0000");
		}
		protected void Page_Disposed(object sender, EventArgs e)
		{
            //string archivoTemporario = Server.MapPath(MedioImageMap.ImageUrl.Replace("~/", String.Empty).Replace("/", "\\"));
            //if (System.IO.File.Exists(archivoTemporario))
            //{
            //    System.IO.File.Delete(archivoTemporario);
            //}
            //archivoTemporario = Server.MapPath(ProvinciaImageMap.ImageUrl.Replace("~/", String.Empty).Replace("/", "\\"));
            //if (System.IO.File.Exists(archivoTemporario))
            //{
            //    System.IO.File.Delete(archivoTemporario);
            //}
		}
		protected void RecibeAvisoAltaCuentaCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.RecibeAvisoAltaCuenta = RecibeAvisoAltaCuentaCheckBox.Checked;
			CedForecastWebRN.Cuenta.SetearRecibeAvisoAltaCuenta(((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
		}
		protected void ModoDepuracionCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			((CedForecastWebEntidades.Sesion)Session["Sesion"]).Flag.ModoDepuracion = ModoDepuracionCheckBox.Checked;
			CedForecastWebRN.Flag.SetearModoDepuracion((CedForecastWebEntidades.Flag)((CedForecastWebEntidades.Sesion)Session["Sesion"]).Flag, (CedEntidades.Sesion)Session["Sesion"]);
		}
		protected void UltimasAltasPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			try
			{
				UltimasAltasPagingGridView.PageIndex = e.NewPageIndex;
				System.Collections.Generic.List<CedForecastWebEntidades.Cuenta> lista;
				lista = CedForecastWebRN.Cuenta.Lista(UltimasAltasPagingGridView.PageIndex, UltimasAltasPagingGridView.PageSize, UltimasAltasPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
				UltimasAltasPagingGridView.VirtualItemCount = CedForecastWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
				UltimasAltasPagingGridView.DataSource = lista;
				UltimasAltasPagingGridView.DataBind();
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
		protected void UltimasAltasPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<CedForecastWebEntidades.Cuenta> lista;
				lista = CedForecastWebRN.Cuenta.Lista(UltimasAltasPagingGridView.PageIndex, UltimasAltasPagingGridView.PageSize, UltimasAltasPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
				UltimasAltasPagingGridView.DataSource = lista;
				UltimasAltasPagingGridView.DataBind();
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
		protected void UltimosComprobantesPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
            //try
            //{
            //    UltimosComprobantesPagingGridView.PageIndex = e.NewPageIndex;
            //    System.Collections.Generic.List<CedForecastWebEntidades.Cuenta> lista;
            //    lista = CedForecastWebRN.Cuenta.Lista(UltimosComprobantesPagingGridView.PageIndex, UltimosComprobantesPagingGridView.PageSize, UltimosComprobantesPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
            //    UltimosComprobantesPagingGridView.VirtualItemCount = CedForecastWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
            //    UltimosComprobantesPagingGridView.DataSource = lista;
            //    UltimosComprobantesPagingGridView.DataBind();
            //}
            //catch (System.Threading.ThreadAbortException)
            //{
            //    Trace.Warn("Thread abortado");
            //}
            //catch (Exception ex)
            //{
            //    CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Excepcion.aspx");
            //}
		}
		protected void UltimosComprobantesPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
		{
            //try
            //{
            //    System.Collections.Generic.List<CedForecastWebEntidades.Cuenta> lista;
            //    lista = CedForecastWebRN.Cuenta.Lista(UltimosComprobantesPagingGridView.PageIndex, UltimosComprobantesPagingGridView.PageSize, UltimosComprobantesPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
            //    UltimosComprobantesPagingGridView.DataSource = lista;
            //    UltimosComprobantesPagingGridView.DataBind();
            //}
            //catch (System.Threading.ThreadAbortException)
            //{
            //    Trace.Warn("Thread abortado");
            //}
            //catch (Exception ex)
            //{
            //    CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Excepcion.aspx");
            //}
		}
		public static DateTime LastOldFileRemoveDate
		{
			get
			{
				if (HttpContext.Current.Application["LastOldFileRemoveDate"] == null)
				{
					HttpContext.Current.Application["LastOldFileRemoveDate"] = DateTime.MinValue;
				}
				return (DateTime)HttpContext.Current.Application["LastOldFileRemoveDate"];
			}
			set
			{
				HttpContext.Current.Application["LastOldFileRemoveDate"] = value;
			}
		}
		public static void DeleteOldTempFiles(string TempDirectory, int OlderThanDays)
		{
			LastOldFileRemoveDate = DateTime.Now;
			string[] Files = System.IO.Directory.GetFiles(HttpContext.Current.Server.MapPath(TempDirectory));
			System.IO.FileInfo fileInfo = null;
			foreach (string s in Files)
			{
				fileInfo = new System.IO.FileInfo(s);
				if (fileInfo.CreationTime < DateTime.Now.AddDays(-(OlderThanDays)) && fileInfo.Extension.Equals(".bmp"))
				{
					try
					{
						fileInfo.Delete();
					}
					catch
					{
					}
				}
			}
		}

	}
}
