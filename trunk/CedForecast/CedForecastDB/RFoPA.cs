using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB
{
    public class RFoPA: db
    {
        private int cantidadFilas;
        private string icm;
        public RFoPA(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
            cantidadFilas = 0;
        }

        public List<CedForecastEntidades.RFoPA> Lista(CedForecastEntidades.RFoPA Forecast, string TipoReporte, string ListaArticulos, string ListaClientes, string ListaVendedores)
        {
            cantidadFilas = 0;
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select Forecast.IdTipoPlanilla, Forecast.IdCuenta, Forecast.IdCliente, Forecast.IdPeriodo, Forecast.IdArticulo, Forecast.Cantidad, isnull(FamiliaArticulo.IdFamiliaArticulo, '') as IdFamiliaArticulo, isnull(FamiliaArticulo.DescrFamiliaArticulo, '') as DescrFamiliaArticulo ");
            //Articulo.DescrArticulo, Articulo.IdGrupoArticulo, GrupoArticulo.DescrGrupoArticulo, Division.IdDivision, Division.DescrDivision,
            a.Append("from Forecast left outer join FamiliaArticuloXArticulo on Forecast.IdArticulo = FamiliaArticuloXArticulo.IdArticulo ");
            a.Append("left outer join FamiliaArticulo on FamiliaArticuloXArticulo.IdFamiliaArticulo = FamiliaArticulo.IdFamiliaArticulo ");
            //, Articulo, GrupoArticulo, Division ");
            a.Append("where Forecast.IdTipoPlanilla='" + Forecast.IdTipoPlanilla + "' ");
            //Forecast.IdArticulo=Articulo.IdArticulo and Articulo.IdGrupoArticulo=GrupoArticulo.IdGrupoArticulo and GrupoArticulo.IdDivision=Division.IdDivision
            if (ListaArticulos != "")
            {
                a.Append("and Forecast.IdArticulo in (" + ListaArticulos + ") "); 
            }
            if (ListaClientes != "")
            {
                a.Append("and Forecast.IdCliente in (" + ListaClientes + ") ");
            }
            if (ListaVendedores != "")
            {
                a.Append("and Forecast.IdCuenta in (" + ListaVendedores + ") ");
            }
            if (Forecast.IdCliente != null && Forecast.IdCliente != "")
            {
                a.Append("and Forecast.IdCliente='" + Forecast.IdCliente + "' ");
            }
            string periodo = "";
            if (Forecast.IdTipoPlanilla=="Proyectado")
            {
                periodo = Forecast.IdPeriodo + "99";
            }
            else
            {
                periodo = UltimoMesForecast(Forecast.IdPeriodo);
            }
            a.Append("and IdPeriodo >= '" + Forecast.IdPeriodo + "' ");
            a.Append("and IdPeriodo <= '" + periodo + "' ");
            switch (TipoReporte)
            {
                case "FamArtCliVen":
                case "FamArtCli":
                case "FamArt":
                    a.Append("order by IdArticulo asc, IdCliente asc, IdCuenta asc, IdPeriodo asc ");
                    break;
                case "FamArtVen":
                    a.Append("order by IdArticulo asc, IdCuenta asc, IdCliente asc, IdPeriodo asc ");
                    break;
                case "Fam":
                    a.Append("order by IdFamiliaArticulo asc, IdArticulo asc, IdCuenta asc, IdCliente asc, IdPeriodo asc ");
                    break;
            }
            DataTable dt = new DataTable();  
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastEntidades.RFoPA> lista = new List<CedForecastEntidades.RFoPA>();
            if (dt.Rows.Count != 0)
            {
                CedForecastEntidades.RFoPA forecast = new CedForecastEntidades.RFoPA();
                string idClave = "";
                idClave = ObtenerClaveXTipoReporte(dt.Rows[0], TipoReporte);
                CopiarCab(dt.Rows[0], forecast, Forecast.IdPeriodo);
                //Lista de ventas para Rolling Forecast
                List<CedForecastEntidades.Bejerman.Ventas> ventas = new List<CedForecastEntidades.Bejerman.Ventas>();
                List<CedForecastEntidades.RFoPA> totalProyectadoLista = new List<CedForecastEntidades.RFoPA>();
                if (Forecast.IdTipoPlanilla == "RollingForecast")
                {
                    CedForecastDB.Bejerman.Ventas db = new CedForecastDB.Bejerman.Ventas(sesion);
                    ventas = db.LeerParaRF(Forecast.IdPeriodo, TipoReporte);
                    CedForecastEntidades.Bejerman.Ventas venta = new CedForecastEntidades.Bejerman.Ventas();
                    switch (TipoReporte)
                    {
                        case "FamArtCli":
                            venta = ventas.Find((delegate(CedForecastEntidades.Bejerman.Ventas e) { return e.Cve_CodCli == dt.Rows[0]["IdCliente"].ToString() && e.Sdvart_CodGen == dt.Rows[0]["IdArticulo"].ToString(); }));
                            break;
                        //case "FamArt":
                        //    venta = ventas.Find((delegate(CedForecastEntidades.Bejerman.Ventas e) { return e.Sdvart_CodGen == dt.Rows[0]["IdArticulo"].ToString(); }));
                        //    break;
                    }
                    if (venta != null)
                    {
                        forecast.Ventas = venta.Sdv_CantUM1;
                    }
                    //Lista de totales proyectados por articulo
                    totalProyectadoLista = TotalProyectado(Forecast);
                    ////Buscar total proyectado
                    CedForecastEntidades.RFoPA totalProyectado = new CedForecastEntidades.RFoPA();
                    totalProyectado = totalProyectadoLista.Find((delegate(CedForecastEntidades.RFoPA e) { return e.IdCliente == dt.Rows[0]["IdCliente"].ToString() && e.Articulo.Art_CodGen == dt.Rows[0]["IdArticulo"].ToString(); }));
                    if (totalProyectado != null)
                    {
                        forecast.Proyectado = totalProyectado.Proyectado;
                    }
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string periodoInicial = Forecast.IdPeriodo;
                    if (Forecast.IdTipoPlanilla == "Proyectado")
                    {
                        periodoInicial = periodoInicial + "01";
                    }
                    int mes = 0;
                    if (Forecast.IdTipoPlanilla == "Proyectado" && (dt.Rows[i]["IdPeriodo"].ToString().Substring(4, 2) == "13" || dt.Rows[i]["IdPeriodo"].ToString().Substring(4, 2) == "14"))
                    {
                        mes = Convert.ToInt32(dt.Rows[i]["IdPeriodo"].ToString().Substring(4, 2));
                    }
                    else
                    {
                        mes = MesAProcesar(dt.Rows[i]["IdPeriodo"].ToString(), periodoInicial);
                    }
                    //Clave para armado de info según agrupamiento
                    string claveAux = ObtenerClaveXTipoReporte(dt.Rows[i], TipoReporte);
                    if (idClave != claveAux)
                    {
                        idClave = claveAux;
                        lista.Add(forecast);
                        forecast = new CedForecastEntidades.RFoPA();
                        CopiarCab(dt.Rows[i], forecast, Forecast.IdPeriodo);
                        if (Forecast.IdTipoPlanilla == "RollingForecast")
                        {
                            //Buscar ventas reales
                            CedForecastDB.Bejerman.Ventas db = new CedForecastDB.Bejerman.Ventas(sesion);
                            ventas = db.LeerParaRF(Forecast.IdPeriodo, TipoReporte);
                            CedForecastEntidades.Bejerman.Ventas venta = new CedForecastEntidades.Bejerman.Ventas();
                             switch (TipoReporte)
                            {
                                case "FamArtCli":
                                    venta = ventas.Find((delegate(CedForecastEntidades.Bejerman.Ventas e) { return e.Cve_CodCli == dt.Rows[i]["IdCliente"].ToString() && e.Sdvart_CodGen == dt.Rows[i]["IdArticulo"].ToString(); }));
                                    break;
                                //case "FamArt":
                                //    venta = ventas.Find((delegate(CedForecastEntidades.Bejerman.Ventas e) { return e.Sdvart_CodGen == dt.Rows[i]["IdArticulo"].ToString(); }));
                                //    break;
                            }
                            if (venta != null)
                            {
                                forecast.Ventas = venta.Sdv_CantUM1;
                            }
                            //Buscar total proyectado
                            CedForecastEntidades.RFoPA totalProyectado = new CedForecastEntidades.RFoPA();
                            totalProyectado = totalProyectadoLista.Find((delegate(CedForecastEntidades.RFoPA e) { return e.IdCliente == dt.Rows[i]["IdCliente"].ToString() && e.Articulo.Art_CodGen == dt.Rows[i]["IdArticulo"].ToString(); }));
                            if (totalProyectado != null)
                            {
                                forecast.Proyectado = totalProyectado.Proyectado;
                            }
                        }
                    }
                    CopiarDet(dt.Rows[i], forecast, mes);
                 }
                 lista.Add(forecast);
            }
            cantidadFilas = lista.Count;
            return lista;
        }
        private string ObtenerClaveXTipoReporte(DataRow dr, string TipoReporte)
        {
            string idClave = "";
            switch (TipoReporte)
            {
                case "FamArtCliVen":
                    idClave = dr["IdArticulo"].ToString() + dr["IdCliente"].ToString() + dr["IdCuenta"].ToString();
                    break;
                case "FamArtCli":
                    idClave = dr["IdArticulo"].ToString() + dr["IdCliente"].ToString();
                    break;
                case "FamArtVen":
                    idClave = dr["IdArticulo"].ToString() + dr["IdCuenta"].ToString();
                    break;
                case "FamArt":
                    idClave = dr["IdArticulo"].ToString();
                    break;
                case "Fam":
                    idClave = dr["IdFamiliaArticulo"].ToString();
                    break;
            }
            return idClave;
        }
        public List<CedForecastEntidades.RFoPA> TotalProyectado(CedForecastEntidades.RFoPA Forecast)
        { 
            cantidadFilas = 0;
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select Forecast.IdTipoPlanilla, Forecast.IdCuenta, Forecast.IdCliente, Forecast.IdPeriodo, Forecast.IdArticulo, Forecast.Cantidad ");
            a.Append("from Forecast ");
            a.Append("where Forecast.IdTipoPlanilla='Proyectado' and Forecast.IdCuenta='" + Forecast.IdCuenta + "' ");
            if (Forecast.IdCliente != null && Forecast.IdCliente != "")
            {
                a.Append("and Forecast.IdCliente='" + Forecast.IdCliente + "' ");
            }
            a.Append("and IdPeriodo >= '" + Forecast.IdPeriodo.Substring(0,4) + "01' ");
            a.Append("and IdPeriodo <= '" + Forecast.IdPeriodo.Substring(0,4) + "99' ");
            a.Append("order by IdArticulo asc, IdPeriodo asc");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastEntidades.RFoPA> lista = new List<CedForecastEntidades.RFoPA>();
            if (dt.Rows.Count != 0)
            {
                CedForecastEntidades.RFoPA forecast = new CedForecastEntidades.RFoPA();
                string idArticulo = dt.Rows[0]["IdArticulo"].ToString();
                CopiarCab(dt.Rows[0], forecast, Forecast.IdPeriodo);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!(dt.Rows[i]["IdPeriodo"].ToString().Substring(4, 2) == "13" || dt.Rows[i]["IdPeriodo"].ToString().Substring(4, 2) == "14"))
                    {
                        if (idArticulo != dt.Rows[i]["IdArticulo"].ToString())
                        {
                            idArticulo = dt.Rows[i]["IdArticulo"].ToString();
                            lista.Add(forecast);
                            forecast = new CedForecastEntidades.RFoPA();
                            CopiarCab(dt.Rows[i], forecast, Forecast.IdPeriodo);
                        }
                        forecast.Proyectado += Convert.ToDecimal(dt.Rows[i]["Cantidad"]);
                    }
                }
                lista.Add(forecast);
            }
            return lista;
        }
        private void CopiarCab(DataRow Desde, CedForecastEntidades.RFoPA Hasta, string PeriodoInicial)
        {
            Hasta.IdTipoPlanilla = Convert.ToString(Desde["IdTipoPlanilla"]);
            Hasta.Vendedor.Ven_Cod = Convert.ToString(Desde["IdCuenta"]);
            Hasta.Cliente.Cli_Cod = Convert.ToString(Desde["IdCliente"]);
            Hasta.Articulo = new CedForecastEntidades.Bejerman.Articulos();
            Hasta.Articulo.Art_CodGen = Convert.ToString(Desde["IdArticulo"]);
            Hasta.FamiliaArticulo = new CedForecastEntidades.Articulo();
            Hasta.FamiliaArticulo.Id = Convert.ToString(Desde["IdArticulo"]);
            Hasta.FamiliaArticulo.Familia.Id = Convert.ToString(Desde["IdFamiliaArticulo"]);
            Hasta.FamiliaArticulo.Familia.Descr = Convert.ToString(Desde["DescrFamiliaArticulo"]);
            //Hasta.Articulo.GrupoArticulo.IdGrupoArticulo = Convert.ToString(Desde["IdGrupoArticulo"]);
            //Hasta.Articulo.GrupoArticulo.DescrGrupoArticulo = Convert.ToString(Desde["DescrGrupoArticulo"]);
            //Hasta.Articulo.Artda2_cod = Convert.ToString(Desde["IdDivision"]);
            //Hasta.Articulo.GrupoArticulo.Division.Descr = Convert.ToString(Desde["DescrDivision"]);
            Hasta.IdPeriodo = PeriodoInicial;
            if (Hasta.IdTipoPlanilla == "RollingForecast")
            {
                //Hasta.CantidadMesesParaDesvio = 13 - Convert.ToInt32(PeriodoInicial.Substring(4, 2));
            }
        }
        private void CopiarDet(DataRow Desde, CedForecastEntidades.RFoPA Hasta, int Mes)
        {

            switch (Mes)
            {
                case 1:
                    Hasta.Cantidad1 += Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 2:
                    Hasta.Cantidad2 += Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 3:
                    Hasta.Cantidad3 += Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 4:
                    Hasta.Cantidad4 += Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 5:
                    Hasta.Cantidad5 += Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 6:
                    Hasta.Cantidad6 += Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 7:
                    Hasta.Cantidad7 += Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 8:
                    Hasta.Cantidad8 += Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 9:
                    Hasta.Cantidad9 += Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 10:
                    Hasta.Cantidad10 += Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 11:
                    Hasta.Cantidad11 += Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 12:
                    Hasta.Cantidad12 += Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 13:
                    Hasta.Cantidad13 += Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 14:
                    Hasta.Cantidad14 += Convert.ToDecimal(Desde["Cantidad"]);
                    break;
            }
        }
        private string UltimoMesForecast(string Periodo)
        {
            DateTime fechaUltimoMesForecast = new DateTime(Convert.ToInt32(Periodo.Substring(0, 4)), Convert.ToInt32(Periodo.Substring(4, 2)), 1);
            fechaUltimoMesForecast = fechaUltimoMesForecast.AddMonths(11);
            return fechaUltimoMesForecast.ToString("yyyyMM");
        }
        private string PrimerMes(string Periodo)
        {
            DateTime primerMes = new DateTime(Convert.ToInt32(Periodo.Substring(0, 4)), 1, 1);
            return primerMes.ToString("yyyyMM");
        }
        private int MesAProcesar(string PeriodoAProcesar, string PeriodoInicial)
        {
            int i = 0;
            DateTime fechaAux = new DateTime(Convert.ToInt32(PeriodoInicial.Substring(0, 4)), Convert.ToInt32(PeriodoInicial.Substring(4, 2)), 1);
            for (i = 1; i <= 12; i++)
            {
                if (fechaAux.Month == Convert.ToInt32(PeriodoAProcesar.Substring(4, 2)))
                {
                    break;
                }
                fechaAux = fechaAux.AddMonths(1);
            }
            return i;
        }
        private string PeriodoAProcesar(int i, string PeriodoInicial)
        {
            DateTime fechaAux = new DateTime(Convert.ToInt32(PeriodoInicial.Substring(0, 4)), Convert.ToInt32(PeriodoInicial.Substring(4, 2)), 1);
            fechaAux = fechaAux.AddMonths(i);
            return fechaAux.ToString("yyyyMM");
        }
    }
}
