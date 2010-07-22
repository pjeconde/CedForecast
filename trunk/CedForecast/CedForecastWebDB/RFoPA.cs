using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastWebDB
{
    public class RFoPA: db
    {
        private int cantidadFilas;
        public RFoPA(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
            cantidadFilas = 0;
        }

        public List<CedForecastWebEntidades.RFoPA> Lista(CedForecastWebEntidades.RFoPA Forecast)
        {
            cantidadFilas = 0;
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select Forecast.IdTipoPlanilla, Forecast.IdCuenta, Forecast.IdCliente, Forecast.IdPeriodo, Forecast.IdArticulo, Articulo.DescrArticulo, Articulo.IdGrupoArticulo, GrupoArticulo.DescrGrupoArticulo, Division.IdDivision, Division.DescrDivision, FamiliaArticulo.IdFamiliaArticulo, FamiliaArticulo.DescrFamiliaArticulo, Forecast.Cantidad ");
            a.Append("from Forecast, Articulo, GrupoArticulo, Division, FamiliaArticulo, FamiliaArticuloXArticulo ");
            a.Append("where Forecast.IdArticulo=Articulo.IdArticulo and Articulo.IdGrupoArticulo=GrupoArticulo.IdGrupoArticulo and GrupoArticulo.IdDivision=Division.IdDivision ");
            a.Append("and Forecast.IdArticulo=FamiliaArticuloXArticulo.IdArticulo and FamiliaArticuloXArticulo.IdFamiliaArticulo=FamiliaArticulo.IdFamiliaArticulo ");
            a.Append("and Forecast.IdTipoPlanilla='" + Forecast.IdTipoPlanilla + "' and Forecast.IdCuenta='" + Forecast.IdCuenta + "' ");
            if (Forecast.IdCliente != null && Forecast.IdCliente != "")
            {
                a.Append("and Forecast.IdCliente='" + Forecast.IdCliente + "' ");
            }
            if (Forecast.Articulo.FamiliaArticulo.Id != null && Forecast.Articulo.FamiliaArticulo.Id != "")
            {
                a.Append("and FamiliaArticulo.IdFamiliaArticulo='" + Forecast.Articulo.FamiliaArticulo.Id + "' ");
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
            a.Append("order by IdArticulo asc, IdPeriodo asc");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.RFoPA> lista = new List<CedForecastWebEntidades.RFoPA>();
            if (dt.Rows.Count != 0)
            {
                CedForecastWebEntidades.RFoPA forecast = new CedForecastWebEntidades.RFoPA();
                string idArticulo = dt.Rows[0]["IdArticulo"].ToString();
                CopiarCab(dt.Rows[0], forecast, Forecast.IdPeriodo);
                //Lista de ventas para Rolling Forecast
                List<CedForecastWebEntidades.Venta> ventaLista = new List<CedForecastWebEntidades.Venta>();
                List<CedForecastWebEntidades.RFoPA> totalProyectadoLista = new List<CedForecastWebEntidades.RFoPA>();
                if (Forecast.IdTipoPlanilla == "RollingForecast")
                {
                    Venta ventaRN = new Venta(sesion);
                    ventaLista = ventaRN.ConsultarTotales(PrimerMes(Forecast.IdPeriodo), Forecast.IdPeriodo);
                    CedForecastWebEntidades.Venta venta = new CedForecastWebEntidades.Venta();
                    venta = ventaLista.Find((delegate(CedForecastWebEntidades.Venta e) { return e.IdCliente == dt.Rows[0]["IdCliente"].ToString() && e.IdArticulo == dt.Rows[0]["IdArticulo"].ToString(); }));
                    if (venta != null)
                    {
                        forecast.Ventas = venta.Cantidad;
                    }
                    //Lista de totales proyectados por articulo
                    totalProyectadoLista = TotalProyectado(Forecast);
                    //Buscar total proyectado
                    CedForecastWebEntidades.RFoPA totalProyectado = new CedForecastWebEntidades.RFoPA();
                    totalProyectado = totalProyectadoLista.Find((delegate(CedForecastWebEntidades.RFoPA e) { return e.IdCliente == dt.Rows[0]["IdCliente"].ToString() && e.Articulo.Id == dt.Rows[0]["IdArticulo"].ToString(); }));
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
                    if (idArticulo != dt.Rows[i]["IdArticulo"].ToString())
                    {
                        idArticulo = dt.Rows[i]["IdArticulo"].ToString();
                        lista.Add(forecast);
                        forecast = new CedForecastWebEntidades.RFoPA();
                        CopiarCab(dt.Rows[i], forecast, Forecast.IdPeriodo);
                        if (Forecast.IdTipoPlanilla == "RollingForecast")
                        {
                            //Buscar ventas reales
                            CedForecastWebEntidades.Venta venta = new CedForecastWebEntidades.Venta();
                            venta = ventaLista.Find((delegate(CedForecastWebEntidades.Venta e) { return e.IdCliente == dt.Rows[i]["IdCliente"].ToString() && e.IdArticulo == dt.Rows[i]["IdArticulo"].ToString(); }));
                            if (venta != null)
                            {
                                forecast.Ventas = venta.Cantidad;
                            }
                            //Buscar total proyectado
                            CedForecastWebEntidades.RFoPA totalProyectado = new CedForecastWebEntidades.RFoPA();
                            totalProyectado = totalProyectadoLista.Find((delegate(CedForecastWebEntidades.RFoPA e) { return e.IdCliente == dt.Rows[i]["IdCliente"].ToString() && e.Articulo.Id == dt.Rows[i]["IdArticulo"].ToString(); }));
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
        public List<CedForecastWebEntidades.RFoPA> TotalProyectado(CedForecastWebEntidades.RFoPA Forecast)
        { 
            cantidadFilas = 0;
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select Forecast.IdTipoPlanilla, Forecast.IdCuenta, Forecast.IdCliente, Forecast.IdPeriodo, Forecast.IdArticulo, Articulo.DescrArticulo, Articulo.IdGrupoArticulo, GrupoArticulo.DescrGrupoArticulo, Division.IdDivision, Division.DescrDivision, Forecast.Cantidad ");
            a.Append("from Forecast, Articulo, GrupoArticulo, Division ");
            a.Append("where Forecast.IdArticulo=Articulo.IdArticulo and Articulo.IdGrupoArticulo=GrupoArticulo.IdGrupoArticulo and GrupoArticulo.IdDivision=Division.IdDivision and Forecast.IdTipoPlanilla='Proyectado' and Forecast.IdCuenta='" + Forecast.IdCuenta + "' ");
            if (Forecast.IdCliente != null && Forecast.IdCliente != "")
            {
                a.Append("and Forecast.IdCliente='" + Forecast.IdCliente + "' ");
            }
            a.Append("and IdPeriodo >= '" + Forecast.IdPeriodo.Substring(0,4) + "01' ");
            a.Append("and IdPeriodo <= '" + Forecast.IdPeriodo.Substring(0,4) + "99' ");
            a.Append("order by IdArticulo asc, IdPeriodo asc");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.RFoPA> lista = new List<CedForecastWebEntidades.RFoPA>();
            if (dt.Rows.Count != 0)
            {
                CedForecastWebEntidades.RFoPA forecast = new CedForecastWebEntidades.RFoPA();
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
                            forecast = new CedForecastWebEntidades.RFoPA();
                            CopiarCab(dt.Rows[i], forecast, Forecast.IdPeriodo);
                        }
                        forecast.Proyectado += Convert.ToDecimal(dt.Rows[i]["Cantidad"]);
                    }
                }
                lista.Add(forecast);
            }
            return lista;
        }
        private void CopiarCab(DataRow Desde, CedForecastWebEntidades.RFoPA Hasta, string PeriodoInicial)
        {
            Hasta.IdTipoPlanilla = Convert.ToString(Desde["IdTipoPlanilla"]);
            Hasta.IdCuenta = Convert.ToString(Desde["IdCuenta"]);
            Hasta.Cliente.Id = Convert.ToString(Desde["IdCliente"]);
            Hasta.Articulo = new CedForecastWebEntidades.Articulo();
            Hasta.Articulo.Id = Convert.ToString(Desde["IdArticulo"]);
            Hasta.Articulo.Descr = Convert.ToString(Desde["DescrArticulo"]);
            Hasta.Articulo.GrupoArticulo.IdGrupoArticulo = Convert.ToString(Desde["IdGrupoArticulo"]);
            Hasta.Articulo.GrupoArticulo.DescrGrupoArticulo = Convert.ToString(Desde["DescrGrupoArticulo"]);
            Hasta.Articulo.GrupoArticulo.Division.Id = Convert.ToString(Desde["IdDivision"]);
            Hasta.Articulo.GrupoArticulo.Division.Descr = Convert.ToString(Desde["DescrDivision"]);
            Hasta.Articulo.FamiliaArticulo.Id = Convert.ToString(Desde["IdFamiliaArticulo"]);
            Hasta.Articulo.FamiliaArticulo.Descr = Convert.ToString(Desde["DescrFamiliaArticulo"]);
            Hasta.IdPeriodo = PeriodoInicial;
            if (Hasta.IdTipoPlanilla == "RollingForecast")
            {
                //Hasta.CantidadMesesParaDesvio = 13 - Convert.ToInt32(PeriodoInicial.Substring(4, 2));
            }
        }
        private void CopiarDet(DataRow Desde, CedForecastWebEntidades.RFoPA Hasta, int Mes)
        {

            switch (Mes)
            {
                case 1:
                    Hasta.Cantidad1 = Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 2:
                    Hasta.Cantidad2 = Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 3:
                    Hasta.Cantidad3 = Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 4:
                    Hasta.Cantidad4 = Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 5:
                    Hasta.Cantidad5 = Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 6:
                    Hasta.Cantidad6 = Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 7:
                    Hasta.Cantidad7 = Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 8:
                    Hasta.Cantidad8 = Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 9:
                    Hasta.Cantidad9 = Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 10:
                    Hasta.Cantidad10 = Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 11:
                    Hasta.Cantidad11 = Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 12:
                    Hasta.Cantidad12 = Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 13:
                    Hasta.Cantidad13 = Convert.ToDecimal(Desde["Cantidad"]);
                    break;
                case 14:
                    Hasta.Cantidad14 = Convert.ToDecimal(Desde["Cantidad"]);
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
        public void Guardar(List<CedForecastWebEntidades.RFoPA> ForecastLista, string IdTipoPlanilla, string IdCuenta, string IdCliente, string Periodo)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("delete Forecast where IdCuenta = '" + IdCuenta + "' and IdCliente = '" + IdCliente + "' and IdTipoPlanilla = '" + IdTipoPlanilla + "' ");
            string periodo = "";
            if (IdTipoPlanilla == "Proyectado")
            {
                periodo = Periodo + "99";
            }
            else
            {
                periodo = UltimoMesForecast(Periodo);
            }
            a.Append("and IdPeriodo >= '" + Periodo + "' and IdPeriodo <= '" + periodo + "' ");
            foreach (CedForecastWebEntidades.RFoPA Forecast in ForecastLista)
            {
                if (Forecast.Articulo.Id != null)
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        decimal cantidad = 0;
                        switch (i)
                        {
                            case 1:
                                cantidad = Forecast.Cantidad1;
                                break;
                            case 2:
                                cantidad = Forecast.Cantidad2;
                                break;
                            case 3:
                                cantidad = Forecast.Cantidad3;
                                break;
                            case 4:
                                cantidad = Forecast.Cantidad4;
                                break;
                            case 5:
                                cantidad = Forecast.Cantidad5;
                                break;
                            case 6:
                                cantidad = Forecast.Cantidad6;
                                break;
                            case 7:
                                cantidad = Forecast.Cantidad7;
                                break;
                            case 8:
                                cantidad = Forecast.Cantidad8;
                                break;
                            case 9:
                                cantidad = Forecast.Cantidad9;
                                break;
                            case 10:
                                cantidad = Forecast.Cantidad10;
                                break;
                            case 11:
                                cantidad = Forecast.Cantidad11;
                                break;
                            case 12:
                                cantidad = Forecast.Cantidad12;
                                break;
                        }
                        if (cantidad > 0)
                        {
                            a.Append("Insert Forecast values ('" + Forecast.IdTipoPlanilla + "', '" + Forecast.IdCuenta + "', '" + Forecast.IdCliente + "', '");
                            if (Forecast.IdTipoPlanilla == "Proyectado")
                            {
                                a.Append(Forecast.Articulo.Id + "', '" + PeriodoAProcesar(i - 1, Forecast.IdPeriodo + "01") + "', " + cantidad + ") ");
                            }
                            else 
                            { 
                                a.Append(Forecast.Articulo.Id + "', '" + PeriodoAProcesar(i - 1, Forecast.IdPeriodo) + "', " + cantidad + ") ");
                            }
                        }
                    }
                    if (Forecast.IdTipoPlanilla == "Proyectado")
                    {
                        if (Forecast.Cantidad13 > 0)
                        {
                            a.Append("Insert Forecast values ('" + Forecast.IdTipoPlanilla + "', '" + Forecast.IdCuenta + "', '" + Forecast.IdCliente + "', '");
                            a.Append(Forecast.Articulo.Id + "', '" + Forecast.IdPeriodo + "13', " + Forecast.Cantidad13 + ") ");
                        }
                        if (Forecast.Cantidad14 > 0)
                        {
                            a.Append("Insert Forecast values ('" + Forecast.IdTipoPlanilla + "', '" + Forecast.IdCuenta + "', '" + Forecast.IdCliente + "', '");
                            a.Append(Forecast.Articulo.Id + "', '" + Forecast.IdPeriodo + "14', " + Forecast.Cantidad14 + ") ");
                        }
                    }
                }
            }
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public List<CedForecastWebEntidades.RFoPA> Lista(out int CantidadFilas, int IndicePagina, int TamañoPagina, string OrderBy, string SessionID, List<CedForecastWebEntidades.RFoPA> ForecastLista)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("CREATE TABLE #Forecast" + SessionID +"( ");
            a.Append("[IdTipoPlanilla] [varchar](15) NOT NULL, ");
            a.Append("[IdCuenta] [varchar](50) NOT NULL, ");
            a.Append("[IdCliente] [varchar](6) NOT NULL, ");
            a.Append("[IdArticulo] [varchar](20) NOT NULL, ");
            a.Append("[IdPeriodo] [varchar](6) NOT NULL, ");
            a.Append("[Proyectado] [decimal](18, 0) NOT NULL, ");
            a.Append("[Ventas] [decimal](18, 0) NOT NULL, ");
            a.Append("[Cantidad1] [decimal](18, 0) NOT NULL, ");
            a.Append("[Cantidad2] [decimal](18, 0) NOT NULL, ");
            a.Append("[Cantidad3] [decimal](18, 0) NOT NULL, ");
            a.Append("[Cantidad4] [decimal](18, 0) NOT NULL, ");
            a.Append("[Cantidad5] [decimal](18, 0) NOT NULL, ");
            a.Append("[Cantidad6] [decimal](18, 0) NOT NULL, ");
            a.Append("[Cantidad7] [decimal](18, 0) NOT NULL, ");
            a.Append("[Cantidad8] [decimal](18, 0) NOT NULL, ");
            a.Append("[Cantidad9] [decimal](18, 0) NOT NULL, ");
            a.Append("[Cantidad10] [decimal](18, 0) NOT NULL, ");
            a.Append("[Cantidad11] [decimal](18, 0) NOT NULL, ");
            a.Append("[Cantidad12] [decimal](18, 0) NOT NULL, ");
            a.Append("[Cantidad13] [decimal](18, 0) NOT NULL, ");
            a.Append("[Cantidad14] [decimal](18, 0) NOT NULL, ");
            a.Append("CONSTRAINT [PK_Forecast"+ SessionID +"] PRIMARY KEY CLUSTERED ");
            a.Append("( ");
            a.Append("[IdTipoPlanilla] ASC, ");
            a.Append("[IdCuenta] ASC, ");
            a.Append("[IdCliente] ASC, ");
            a.Append("[IdArticulo] ASC, ");
            a.Append("[IdPeriodo] ASC ");
            a.Append(")WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ");
            a.Append(") ON [PRIMARY] ");
            foreach (CedForecastWebEntidades.RFoPA Forecast in ForecastLista)
            {
                a.Append("Insert #Forecast" + SessionID + " values ('" + Forecast.IdTipoPlanilla + "', '");
                a.Append(Forecast.IdCuenta + "', '");
                a.Append(Forecast.Cliente.Id + "', '");
                a.Append(Forecast.Articulo.Id + "', '");
                a.Append(Forecast.IdPeriodo + "', ");
                a.Append(Forecast.Proyectado + ", ");
                a.Append(Forecast.Ventas + ", ");
                a.Append(Forecast.Cantidad1 + ", ");
                a.Append(Forecast.Cantidad2 + ", ");
                a.Append(Forecast.Cantidad3 + ", ");
                a.Append(Forecast.Cantidad4 + ", ");
                a.Append(Forecast.Cantidad5 + ", ");
                a.Append(Forecast.Cantidad6 + ", ");
                a.Append(Forecast.Cantidad7 + ", ");
                a.Append(Forecast.Cantidad8 + ", ");
                a.Append(Forecast.Cantidad9 + ", ");
                a.Append(Forecast.Cantidad10 + ", ");
                a.Append(Forecast.Cantidad11 + ", ");
                a.Append(Forecast.Cantidad12 + ", ");
                a.Append(Forecast.Cantidad13 + ", ");
                a.Append(Forecast.Cantidad14 + ") ");
            }
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("IdTipoPlanilla, IdCuenta, #Forecast"+SessionID+".IdCliente, DescrCliente, IdPeriodo, #Forecast" + SessionID + ".IdArticulo, Articulo.DescrArticulo, Articulo.IdGrupoArticulo, GrupoArticulo.DescrGrupoArticulo, Division.IdDivision, Division.DescrDivision, ");
            a.Append("Proyectado, Ventas, Cantidad1, Cantidad2, Cantidad3, Cantidad4, Cantidad5, Cantidad6, Cantidad7, Cantidad8, Cantidad9, Cantidad10, Cantidad11, Cantidad12, Cantidad13, Cantidad14 ");
            a.Append("from #Forecast"+SessionID+" inner join Articulo on #Forecast"+SessionID+".IdArticulo=Articulo.IdArticulo ");
            a.Append("inner join Cliente on #Forecast"+SessionID+".IdCliente=Cliente.IdCliente ");
            a.Append("inner join GrupoArticulo on Articulo.IdGrupoArticulo=GrupoArticulo.IdGrupoArticulo ");
            a.Append("inner join Division on GrupoArticulo.IdDivision=Division.IdDivision ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            a.Append("DROP TABLE #Forecast" + SessionID);
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * TamañoPagina), OrderBy, (IndicePagina * TamañoPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.RFoPA> lista = new List<CedForecastWebEntidades.RFoPA>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastWebEntidades.RFoPA forecast = new CedForecastWebEntidades.RFoPA();
                    forecast.IdTipoPlanilla = dt.Rows[i]["IdTipoPlanilla"].ToString();
                    forecast.IdPeriodo = dt.Rows[i]["IdPeriodo"].ToString();
                    forecast.IdCuenta = dt.Rows[i]["IdCuenta"].ToString();
                    forecast.Cliente.Id = dt.Rows[i]["IdCliente"].ToString();
                    forecast.Cliente.Descr = dt.Rows[i]["DescrCliente"].ToString();
                    forecast.Articulo.Id = dt.Rows[i]["IdArticulo"].ToString();
                    forecast.Articulo.Descr = dt.Rows[i]["DescrArticulo"].ToString();
                    forecast.Proyectado = Convert.ToDecimal(dt.Rows[i]["Proyectado"].ToString());
                    forecast.Ventas = Convert.ToDecimal(dt.Rows[i]["Ventas"].ToString());
                    forecast.Cantidad1 = Convert.ToDecimal(dt.Rows[i]["Cantidad1"].ToString());
                    forecast.Cantidad2 = Convert.ToDecimal(dt.Rows[i]["Cantidad2"].ToString());
                    forecast.Cantidad3 = Convert.ToDecimal(dt.Rows[i]["Cantidad3"].ToString());
                    forecast.Cantidad4 = Convert.ToDecimal(dt.Rows[i]["Cantidad4"].ToString());
                    forecast.Cantidad5 = Convert.ToDecimal(dt.Rows[i]["Cantidad5"].ToString());
                    forecast.Cantidad6 = Convert.ToDecimal(dt.Rows[i]["Cantidad6"].ToString());
                    forecast.Cantidad7 = Convert.ToDecimal(dt.Rows[i]["Cantidad7"].ToString());
                    forecast.Cantidad8 = Convert.ToDecimal(dt.Rows[i]["Cantidad8"].ToString());
                    forecast.Cantidad9 = Convert.ToDecimal(dt.Rows[i]["Cantidad9"].ToString());
                    forecast.Cantidad10 = Convert.ToDecimal(dt.Rows[i]["Cantidad10"].ToString());
                    forecast.Cantidad11 = Convert.ToDecimal(dt.Rows[i]["Cantidad11"].ToString());
                    forecast.Cantidad12 = Convert.ToDecimal(dt.Rows[i]["Cantidad12"].ToString());
                    forecast.Cantidad13 = Convert.ToDecimal(dt.Rows[i]["Cantidad13"].ToString());
                    forecast.Cantidad14 = Convert.ToDecimal(dt.Rows[i]["Cantidad14"].ToString());
                    lista.Add(forecast);
                }
            }
            CantidadFilas = cantidadFilas;
            return lista;
        }
    }
}
