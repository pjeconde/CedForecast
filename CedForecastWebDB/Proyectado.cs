using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastWebDB
{
    public class Proyectado: db
    {
        private int cantidadFilas;
        public Proyectado(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
            cantidadFilas = 0;
        }

        public List<CedForecastWebEntidades.Proyectado> Lista(CedForecastWebEntidades.Proyectado Proyectado)
        {
            cantidadFilas = 0;
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select Forecast.IdTipoPlanilla, Forecast.IdCuenta, Forecast.IdCliente, Forecast.IdPeriodo, Forecast.IdArticulo, Articulo.DescrArticulo, Articulo.IdGrupoArticulo, Cliente.DescrCliente, GrupoArticulo.DescrGrupoArticulo, Division.IdDivision, Division.DescrDivision, FamiliaArticulo.IdFamiliaArticulo, FamiliaArticulo.DescrFamiliaArticulo, Forecast.Cantidad ");
            a.Append("from Forecast inner join Articulo on Forecast.IdArticulo=Articulo.IdArticulo ");
            a.Append("inner join Cliente on Forecast.IdCliente=Cliente.IdCliente ");
            a.Append("inner join GrupoArticulo on Articulo.IdGrupoArticulo=GrupoArticulo.IdGrupoArticulo ");
            a.Append("inner join Division on GrupoArticulo.IdDivision=Division.IdDivision ");
            a.Append("left outer join FamiliaArticuloXArticulo on Forecast.IdArticulo=FamiliaArticuloXArticulo.IdArticulo ");
            a.Append("left outer join FamiliaArticulo on FamiliaArticuloXArticulo.IdFamiliaArticulo=FamiliaArticulo.IdFamiliaArticulo ");
            a.Append("where Forecast.IdTipoPlanilla='" + Proyectado.IdTipoPlanilla + "' ");
            if (Proyectado.IdCuenta != null && Proyectado.IdCuenta != "")
            {
                a.Append("and Forecast.IdCuenta='" + Proyectado.IdCuenta + "' ");
            }
            if (Proyectado.IdCliente != null && Proyectado.IdCliente != "")
            {
                a.Append("and Forecast.IdCliente='" + Proyectado.IdCliente + "' ");
            }
            if (Proyectado.Articulo.FamiliaArticulo.Id != null && Proyectado.Articulo.FamiliaArticulo.Id != "")
            {
                a.Append("and FamiliaArticulo.IdFamiliaArticulo='" + Proyectado.Articulo.FamiliaArticulo.Id + "' ");
            }
            string periodo = "";
            periodo = UltimoMesForecast(Proyectado.IdPeriodo);
            if (Proyectado.IdTipoPlanilla == "Proyectado" && Proyectado.IdPeriodo.Substring(0, 4) == periodo.Substring(0, 4))
            {
                periodo = Proyectado.IdPeriodo.Substring(0, 4) + "99";
            }
            a.Append("and IdPeriodo >= '" + Proyectado.IdPeriodo + "' ");
            a.Append("and IdPeriodo <= '" + periodo + "' ");
            a.Append("order by IdArticulo asc, IdCliente asc, IdPeriodo asc");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.Proyectado> lista = new List<CedForecastWebEntidades.Proyectado>();
            if (dt.Rows.Count != 0)
            {
                CedForecastWebEntidades.Proyectado proyectado = new CedForecastWebEntidades.Proyectado();
                string idArticulo = dt.Rows[0]["IdArticulo"].ToString() + dt.Rows[0]["IdCliente"].ToString();
                CopiarCab(dt.Rows[0], proyectado, Proyectado.IdPeriodo);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string periodoInicial = proyectado.IdPeriodo;
                    int mes = 0;
                    mes = MesAProcesar(dt.Rows[i]["IdPeriodo"].ToString(), periodoInicial);
                    if (idArticulo != dt.Rows[i]["IdArticulo"].ToString() + dt.Rows[i]["IdCliente"].ToString())
                    {
                        idArticulo = dt.Rows[i]["IdArticulo"].ToString() + dt.Rows[i]["IdCliente"].ToString();
                        lista.Add(proyectado);
                        proyectado = new CedForecastWebEntidades.Proyectado();
                        CopiarCab(dt.Rows[i], proyectado, Proyectado.IdPeriodo);
                    }
                    CopiarDet(dt.Rows[i], proyectado, mes);
                    CalcularCantidadTotal(proyectado);
                 }
                 lista.Add(proyectado);
            }
            cantidadFilas = lista.Count;
            return lista;
        }
        private void CalcularCantidadTotal(CedForecastWebEntidades.Proyectado Proyectado)
        {
            //Esta llamada a la consulta de Desvio, completa el atributo desvio para el FileHelper.
            decimal d = Proyectado.CantidadTotal;
        }
        private void CopiarCab(DataRow Desde, CedForecastWebEntidades.Proyectado Hasta, string PeriodoInicial)
        {
            Hasta.IdTipoPlanilla = Convert.ToString(Desde["IdTipoPlanilla"]);
            Hasta.IdCuenta = Convert.ToString(Desde["IdCuenta"]);
            CedForecastWebEntidades.Cliente cliente = new CedForecastWebEntidades.Cliente();
            cliente.Id = Convert.ToString(Desde["IdCliente"]);
            cliente.Descr = Convert.ToString(Desde["DescrCliente"]);
            Hasta.Cliente = cliente;
            CedForecastWebEntidades.Articulo articulo = new CedForecastWebEntidades.Articulo();
            articulo.Id = Convert.ToString(Desde["IdArticulo"]);
            articulo.Descr = Convert.ToString(Desde["DescrArticulo"]);
            Hasta.Articulo = articulo;
            CedForecastWebEntidades.GrupoArticulo grupoArticulo = new CedForecastWebEntidades.GrupoArticulo();
            grupoArticulo.IdGrupoArticulo = Convert.ToString(Desde["IdGrupoArticulo"]);
            grupoArticulo.DescrGrupoArticulo = Convert.ToString(Desde["DescrGrupoArticulo"]);
            Hasta.Articulo.GrupoArticulo = grupoArticulo;
            CedForecastWebEntidades.Division division = new CedForecastWebEntidades.Division();
            division.Id = Convert.ToString(Desde["IdDivision"]);
            division.Descr = Convert.ToString(Desde["DescrDivision"]);
            Hasta.Articulo.GrupoArticulo.Division = division;
            CedForecastWebEntidades.FamiliaArticulo familiaArticulo = new CedForecastWebEntidades.FamiliaArticulo();
            familiaArticulo.Id = Convert.ToString(Desde["IdFamiliaArticulo"]);
            familiaArticulo.Descr = Convert.ToString(Desde["DescrFamiliaArticulo"]);
            Hasta.Articulo.FamiliaArticulo = familiaArticulo;
            Hasta.IdPeriodo = PeriodoInicial;
        }
        private void CopiarDet(DataRow Desde, CedForecastWebEntidades.Proyectado Hasta, int Mes)
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
        public static string UltimoMesForecast(string Periodo)
        {
            DateTime fechaUltimoMesForecast = new DateTime(Convert.ToInt32(Periodo.Substring(0, 4)), Convert.ToInt32(Periodo.Substring(4, 2)), 1);
            fechaUltimoMesForecast = fechaUltimoMesForecast.AddMonths(11);
            return fechaUltimoMesForecast.ToString("yyyyMM");
        }
        private string PrimerMes(string Periodo)
        {
            DateTime primerMes = new DateTime(Convert.ToInt32(Periodo.Substring(0, 4)), Convert.ToInt32(Periodo.Substring(4, 2)), 1);
            return primerMes.ToString("yyyyMM");
        }
        private int MesAProcesar(string PeriodoAProcesar, string PeriodoInicial)
        {
            int i = 0;
            for (i = 1; i <= 14; i++)
            {
                if (Convert.ToInt32(PeriodoInicial.Substring(0, 4)) + i == Convert.ToInt32(PeriodoAProcesar.Substring(0, 4)) + Convert.ToInt32(PeriodoAProcesar.Substring(4, 2)))
                {
                    break;
                }
            }
            return i;
        }
        public static string PeriodoAProcesar(int i, string PeriodoInicial)
        {
            DateTime fechaAux = new DateTime(Convert.ToInt32(PeriodoInicial.Substring(0, 4)), Convert.ToInt32(PeriodoInicial.Substring(4, 2)), 1);
            fechaAux = fechaAux.AddMonths(i);
            return fechaAux.ToString("yyyyMM");
        }
        public void Guardar(List<CedForecastWebEntidades.Proyectado> ProyectadoLista, string IdTipoPlanilla, string IdCuenta, string IdCliente, string IdFamiliaArticulo, string Periodo)
        {
            System.Text.StringBuilder a = new StringBuilder();
            if (IdFamiliaArticulo == null || IdFamiliaArticulo == "")
            {
                a.Append("delete Forecast where IdCuenta = '" + IdCuenta + "' and IdCliente = '" + IdCliente + "' and IdTipoPlanilla = '" + IdTipoPlanilla + "' ");
            }
            else
            {
                a.Append("delete Forecast from Forecast, FamiliaArticuloXArticulo, FamiliaArticulo where Forecast.IdArticulo = FamiliaArticuloXArticulo.IdArticulo and FamiliaArticuloXArticulo.IdFamiliaArticulo = FamiliaArticulo.IdFamiliaArticulo and FamiliaArticuloXArticulo.IdFamiliaArticulo = '" + IdFamiliaArticulo + "' and IdCuenta = '" + IdCuenta + "' and IdCliente = '" + IdCliente + "' and IdTipoPlanilla = '" + IdTipoPlanilla + "' ");
            }
            string periodo = "";
            periodo = UltimoMesForecast(Periodo);
            if (IdTipoPlanilla == "Proyectado" && Periodo.Substring(0, 4) == periodo.Substring(0, 4))
            {
                periodo = Periodo.Substring(0, 4) + "99";
            }
            a.Append("and IdPeriodo >= '" + Periodo + "' and IdPeriodo <= '" + periodo + "' ");
            foreach (CedForecastWebEntidades.Proyectado Proyectado in ProyectadoLista)
            {
                if (Proyectado.Articulo.Id != null)
                {
                    for (int i = 1; i <= 14; i++)
                    {
                        decimal cantidad = 0;
                        switch (i)
                        {
                            case 1:
                                cantidad = Proyectado.Cantidad1;
                                break;
                            case 2:
                                cantidad = Proyectado.Cantidad2;
                                break;
                            case 3:
                                cantidad = Proyectado.Cantidad3;
                                break;
                            case 4:
                                cantidad = Proyectado.Cantidad4;
                                break;
                            case 5:
                                cantidad = Proyectado.Cantidad5;
                                break;
                            case 6:
                                cantidad = Proyectado.Cantidad6;
                                break;
                            case 7:
                                cantidad = Proyectado.Cantidad7;
                                break;
                            case 8:
                                cantidad = Proyectado.Cantidad8;
                                break;
                            case 9:
                                cantidad = Proyectado.Cantidad9;
                                break;
                            case 10:
                                cantidad = Proyectado.Cantidad10;
                                break;
                            case 11:
                                cantidad = Proyectado.Cantidad11;
                                break;
                            case 12:
                                cantidad = Proyectado.Cantidad12;
                                break;
                            case 13:
                                cantidad = Proyectado.Cantidad13;
                                break;
                            case 14:
                                cantidad = Proyectado.Cantidad14;
                                break;
                        }
                        if (cantidad > 0)
                        {
                            a.Append("Insert Forecast values ('" + Proyectado.IdTipoPlanilla + "', '" + Proyectado.IdCuenta + "', '" + Proyectado.IdCliente + "', '");
                            a.Append(Proyectado.Articulo.Id + "', '" + PeriodoAProcesar(i - 1, Proyectado.IdPeriodo) + "', " + cantidad + ") ");
                        }
                    }
                }
            }
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public List<CedForecastWebEntidades.Proyectado> Lista(out int CantidadFilas, int IndicePagina, int TamañoPagina, string OrderBy, string SessionID, List<CedForecastWebEntidades.Proyectado> ProyectadoLista)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("CREATE TABLE #Forecast" + SessionID +"( ");
            a.Append("[IdTipoPlanilla] [varchar](15) collate database_default NOT NULL, ");
            a.Append("[IdCuenta] [varchar](50) collate database_default NOT NULL, ");
            a.Append("[IdCliente] [varchar](6) collate database_default NOT NULL, ");
            a.Append("[IdArticulo] [varchar](20) collate database_default NOT NULL, ");
            a.Append("[IdPeriodo] [varchar](6) collate database_default NOT NULL, ");
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
            foreach (CedForecastWebEntidades.Proyectado Proyectado in ProyectadoLista)
            {
                a.Append("Insert #Forecast" + SessionID + " values ('" + Proyectado.IdTipoPlanilla + "', '");
                a.Append(Proyectado.IdCuenta + "', '");
                a.Append(Proyectado.Cliente.Id + "', '");
                a.Append(Proyectado.Articulo.Id + "', '");
                a.Append(Proyectado.IdPeriodo + "', ");
                a.Append(Proyectado.Cantidad1 + ", ");
                a.Append(Proyectado.Cantidad2 + ", ");
                a.Append(Proyectado.Cantidad3 + ", ");
                a.Append(Proyectado.Cantidad4 + ", ");
                a.Append(Proyectado.Cantidad5 + ", ");
                a.Append(Proyectado.Cantidad6 + ", ");
                a.Append(Proyectado.Cantidad7 + ", ");
                a.Append(Proyectado.Cantidad8 + ", ");
                a.Append(Proyectado.Cantidad9 + ", ");
                a.Append(Proyectado.Cantidad10 + ", ");
                a.Append(Proyectado.Cantidad11 + ", ");
                a.Append(Proyectado.Cantidad12 + ", ");
                a.Append(Proyectado.Cantidad13 + ", ");
                a.Append(Proyectado.Cantidad14 + ") ");
            }
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("IdTipoPlanilla, IdCuenta, #Forecast"+SessionID+".IdCliente, DescrCliente, IdPeriodo, #Forecast" + SessionID + ".IdArticulo, Articulo.DescrArticulo, Articulo.IdGrupoArticulo, GrupoArticulo.DescrGrupoArticulo, Division.IdDivision, Division.DescrDivision, ");
            a.Append("Cantidad1, Cantidad2, Cantidad3, Cantidad4, Cantidad5, Cantidad6, Cantidad7, Cantidad8, Cantidad9, Cantidad10, Cantidad11, Cantidad12, Cantidad13, Cantidad14 ");
            a.Append("from #Forecast"+SessionID+" inner join Articulo on #Forecast"+SessionID+".IdArticulo=Articulo.IdArticulo ");
            a.Append("inner join Cliente on #Forecast"+SessionID+".IdCliente=Cliente.IdCliente ");
            a.Append("inner join GrupoArticulo on Articulo.IdGrupoArticulo=GrupoArticulo.IdGrupoArticulo ");
            a.Append("inner join Division on GrupoArticulo.IdDivision=Division.IdDivision ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            a.Append("DROP TABLE #Forecast" + SessionID);
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * TamañoPagina), OrderBy, (IndicePagina * TamañoPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.Proyectado> lista = new List<CedForecastWebEntidades.Proyectado>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastWebEntidades.Proyectado proyectado = new CedForecastWebEntidades.Proyectado();
                    proyectado.IdTipoPlanilla = dt.Rows[i]["IdTipoPlanilla"].ToString();
                    proyectado.IdPeriodo = dt.Rows[i]["IdPeriodo"].ToString();
                    proyectado.IdCuenta = dt.Rows[i]["IdCuenta"].ToString();
                    CedForecastWebEntidades.Cliente cliente = new CedForecastWebEntidades.Cliente();
                    cliente.Id = dt.Rows[i]["IdCliente"].ToString();
                    cliente.Descr = dt.Rows[i]["DescrCliente"].ToString();
                    proyectado.Cliente = cliente;
                    CedForecastWebEntidades.Articulo articulo = new CedForecastWebEntidades.Articulo();
                    articulo.Id = dt.Rows[i]["IdArticulo"].ToString();
                    articulo.Descr = dt.Rows[i]["DescrArticulo"].ToString();
                    proyectado.Articulo = articulo;
                    proyectado.Cantidad1 = Convert.ToDecimal(dt.Rows[i]["Cantidad1"].ToString());
                    proyectado.Cantidad2 = Convert.ToDecimal(dt.Rows[i]["Cantidad2"].ToString());
                    proyectado.Cantidad3 = Convert.ToDecimal(dt.Rows[i]["Cantidad3"].ToString());
                    proyectado.Cantidad4 = Convert.ToDecimal(dt.Rows[i]["Cantidad4"].ToString());
                    proyectado.Cantidad5 = Convert.ToDecimal(dt.Rows[i]["Cantidad5"].ToString());
                    proyectado.Cantidad6 = Convert.ToDecimal(dt.Rows[i]["Cantidad6"].ToString());
                    proyectado.Cantidad7 = Convert.ToDecimal(dt.Rows[i]["Cantidad7"].ToString());
                    proyectado.Cantidad8 = Convert.ToDecimal(dt.Rows[i]["Cantidad8"].ToString());
                    proyectado.Cantidad9 = Convert.ToDecimal(dt.Rows[i]["Cantidad9"].ToString());
                    proyectado.Cantidad10 = Convert.ToDecimal(dt.Rows[i]["Cantidad10"].ToString());
                    proyectado.Cantidad11 = Convert.ToDecimal(dt.Rows[i]["Cantidad11"].ToString());
                    proyectado.Cantidad12 = Convert.ToDecimal(dt.Rows[i]["Cantidad12"].ToString());
                    proyectado.Cantidad13 = Convert.ToDecimal(dt.Rows[i]["Cantidad13"].ToString());
                    proyectado.Cantidad14 = Convert.ToDecimal(dt.Rows[i]["Cantidad14"].ToString());
                    CalcularCantidadTotal(proyectado);
                    lista.Add(proyectado);
                }
            }
            CantidadFilas = cantidadFilas;
            return lista;
        }
    }
}
