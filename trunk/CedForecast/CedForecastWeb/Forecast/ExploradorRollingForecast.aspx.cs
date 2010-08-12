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
using FileHelpers;
using FileHelpers.RunTime;

namespace CedForecastWeb.Forecast
{
    public partial class ExploradorRollingForecast : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				((LinkButton)Master.FindControl("ConsultaLinkButton")).ForeColor = System.Drawing.Color.DarkBlue;
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
							ForecastPagingGridView.PageSize = 10;

                            ClienteDropDownList.DataValueField = "Id";
                            ClienteDropDownList.DataTextField = "DescrCombo";
                            ClienteDropDownList.DataSource = CedForecastWebRN.Cliente.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                            ClienteDropDownList.SelectedIndex = -1;

                            CuentaDropDownList.DataValueField = "Id";
                            CuentaDropDownList.DataTextField = "DescrCombo";
                            CuentaDropDownList.DataSource = CedForecastWebRN.Cuenta.Lista(true, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                            CuentaDropDownList.SelectedValue = ((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;

                            CuentaDropDownList.Enabled = false;
                            if (((CedForecastWebEntidades.Sesion)Session["Sesion"]).Cuenta.IdTipoCuenta == "SupForecast")
                            {
                                CuentaDropDownList.Enabled = true;
                            }

                            DataBind();

                            CedForecastWebEntidades.Periodo periodo = new CedForecastWebEntidades.Periodo();
                            periodo.IdTipoPlanilla = "RollingForecast";
                            CedForecastWebRN.Periodo.Leer(periodo, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                            PeriodoTextBox.Text = periodo.IdPeriodo;

                            ArmarTextoHeader();

                            LeerPeriodoActual();
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
        private void ArmarTextoHeader()
        {
            int colFijas = 4; //Es 0 y 1.
            for (int i = 1; i <= 12; i++)
            {
                ForecastPagingGridView.Columns[i + colFijas].HeaderText = TextoCantidadHeader(i, PeriodoTextBox.Text);
            }
            ForecastPagingGridView.Columns[13 + colFijas].HeaderText = "Total";
        }
		private void BindPagingGrid()
		{
			try
			{
                ArmarTextoHeader();
                System.Collections.Generic.List<CedForecastWebEntidades.RollingForecast> lista;
                CedForecastWebEntidades.RollingForecast Forecast = new CedForecastWebEntidades.RollingForecast();
                Forecast.IdTipoPlanilla = "RollingForecast";
                Forecast.IdCuenta = CuentaDropDownList.SelectedValue.Trim();
                CedForecastWebEntidades.Cliente cliente = new CedForecastWebEntidades.Cliente();
                cliente.Id = ClienteDropDownList.SelectedValue.Trim();
                Forecast.Cliente = cliente;
                CedForecastWebRN.Periodo.ValidarPeriodoYYYYMM(PeriodoTextBox.Text);
                Forecast.IdPeriodo = PeriodoTextBox.Text;
                int CantidadFilas = 0;
                lista = CedForecastWebRN.RollingForecast.Lista(out CantidadFilas, ForecastPagingGridView.PageIndex, ForecastPagingGridView.PageSize, ForecastPagingGridView.OrderBy, Forecast, Session.SessionID, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                ForecastPagingGridView.VirtualItemCount = CantidadFilas;
				ViewState["lista"] = lista;
				ForecastPagingGridView.DataSource = (System.Collections.Generic.List<CedForecastWebEntidades.RollingForecast>)ViewState["lista"];
				ForecastPagingGridView.DataBind();
			}
			catch (System.Threading.ThreadAbortException)
			{
				Trace.Warn("Thread abortado");
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
				System.Collections.Generic.List<CedForecastWebEntidades.RollingForecast> lista;
                
                CedForecastWebEntidades.RollingForecast Forecast = new CedForecastWebEntidades.RollingForecast();
                Forecast.IdTipoPlanilla = "RollingForecast";
                Forecast.IdCuenta = CuentaDropDownList.SelectedValue.Trim();
                CedForecastWebEntidades.Cliente cliente = new CedForecastWebEntidades.Cliente();
                cliente.Id = ClienteDropDownList.SelectedValue.ToString().Trim();
                Forecast.Cliente = cliente;
                Forecast.IdPeriodo = PeriodoTextBox.Text;
                int CantidadFilas = 0;
                lista = CedForecastWebRN.RollingForecast.Lista(out CantidadFilas, ForecastPagingGridView.PageIndex, ForecastPagingGridView.PageSize, ForecastPagingGridView.OrderBy, Forecast, Session.SessionID, (CedEntidades.Sesion)Session["Sesion"]);
                ForecastPagingGridView.VirtualItemCount = CantidadFilas;
				ViewState["lista"] = lista;
				ForecastPagingGridView.DataSource = lista;
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
		protected void ForecastPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
		{
			try
			{
                DesSeleccionarFilas();
                System.Collections.Generic.List<CedForecastWebEntidades.RollingForecast> lista = new System.Collections.Generic.List<CedForecastWebEntidades.RollingForecast>();

                CedForecastWebEntidades.RollingForecast Forecast = new CedForecastWebEntidades.RollingForecast();
                Forecast.IdTipoPlanilla = "RollingForecast";
                Forecast.IdCuenta = CuentaDropDownList.SelectedValue.Trim();
                CedForecastWebEntidades.Cliente cliente = new CedForecastWebEntidades.Cliente();
                cliente.Id = ClienteDropDownList.SelectedValue.ToString().Trim();
                Forecast.Cliente = cliente;
                Forecast.IdPeriodo = PeriodoTextBox.Text;
                int CantidadFilas = 0;
                lista = CedForecastWebRN.RollingForecast.Lista(out CantidadFilas, ForecastPagingGridView.PageIndex, ForecastPagingGridView.PageSize, ForecastPagingGridView.OrderBy, Forecast, Session.SessionID, (CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                ForecastPagingGridView.DataSource = (System.Collections.Generic.List<CedForecastWebEntidades.RollingForecast>)ViewState["lista"];
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
		protected CedForecastWebEntidades.RollingForecast ForecastSeleccionado()
		{
			System.Collections.Generic.List<CedForecastWebEntidades.RollingForecast> lista = (System.Collections.Generic.List<CedForecastWebEntidades.RollingForecast>)ViewState["lista"];
			return (CedForecastWebEntidades.RollingForecast)lista[ForecastPagingGridView.SelectedIndex];
		}
		protected void SalirButton_Click(object sender, EventArgs e)
		{
			Server.Transfer("~/Forecast/Consulta.aspx");
		}
        protected void LeerButton_Click(object sender, EventArgs e)
        {
            BindPagingGrid();
        }
        private void LeerPeriodoActual()
        {
            try
            {
                CedForecastWebEntidades.Periodo periodo = new CedForecastWebEntidades.Periodo();
                CedForecastWebRN.Periodo.ValidarPeriodoYYYYMM(PeriodoTextBox.Text);
                periodo.IdTipoPlanilla = "RollingForecast";
                CedForecastWebRN.Periodo.Leer(periodo, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
                PeriodoTextBox.Text = periodo.IdPeriodo;
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

        protected void ExportarButton_Click(object sender, EventArgs e)
        {
            System.Collections.Generic.List<CedForecastWebEntidades.RollingForecast> lista;
            CedForecastWebEntidades.RollingForecast Forecast = new CedForecastWebEntidades.RollingForecast();
            Forecast.IdTipoPlanilla = "RollingForecast";
            Forecast.IdCuenta = CuentaDropDownList.SelectedValue.Trim();
            CedForecastWebEntidades.Cliente cliente = new CedForecastWebEntidades.Cliente();
            cliente.Id = ClienteDropDownList.SelectedValue.ToString().Trim();
            Forecast.Cliente = cliente;
            CedForecastWebRN.Periodo.ValidarPeriodoYYYYMM(PeriodoTextBox.Text);
            Forecast.IdPeriodo = PeriodoTextBox.Text;
            lista = CedForecastWebRN.RollingForecast.Lista(Forecast, (CedForecastWebEntidades.Sesion)Session["Sesion"]);
            string archivo = "Id.Vendedor; Id.Cliente; Nombre Cliente; Id.Artículo; Nombre Artículo; Proyectado; Ventas; Desvío; ";
            int colFijas = 4;
            for (int i = 1; i <= 12; i++)
            {
                archivo += TextoCantidadHeader(i, PeriodoTextBox.Text) + "; ";
            }
            archivo += "\r\n";
            FileHelperEngine fhe = new FileHelperEngine(typeof(CedForecastWebEntidades.RollingForecast));
            archivo += fhe.WriteString(lista);
            byte[] a = System.Text.Encoding.GetEncoding("iso-8859-1").GetBytes(archivo);
            System.IO.MemoryStream m = new System.IO.MemoryStream(a);
            Byte[] byteArray = m.ToArray();
            m.Flush();
            m.Close();
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=RollingForecast.csv");
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(byteArray);
            Response.End();
        }
	}
}
