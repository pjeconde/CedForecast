using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastWebDB
{
    public class Forecast: db
    {
        public Forecast(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public List<CedForecastWebEntidades.Forecast> Lista(CedForecastWebEntidades.Forecast Forecast)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select Forecast.IdTipoPlanilla, Forecast.IdCuenta, Forecast.IdCliente, Forecast.IdPeriodo, Forecast.IdArticulo, Articulo.DescrArticulo, Articulo.IdGrupoArticulo, GrupoArticulo.DescrGrupoArticulo, Division.IdDivision, Division.DescrDivision, Forecast.Cantidad ");
            a.Append("from Forecast, Articulo, GrupoArticulo, Division ");
            a.Append("where Forecast.IdArticulo=Articulo.IdArticulo and Articulo.IdGrupoArticulo=GrupoArticulo.IdGrupoArticulo and GrupoArticulo.IdDivision=Division.IdDivision and IdTipoPlanilla='" + Forecast.IdTipoPlanilla + "' and IdCuenta='" + Forecast.IdCuenta + "' and GrupoArticulo.IdDivision='" + Forecast.IdDivision + "' and IdCliente='" + Forecast.IdCliente + "' ");
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
            List<CedForecastWebEntidades.Forecast> lista = new List<CedForecastWebEntidades.Forecast>();
            if (dt.Rows.Count != 0)
            {
                CedForecastWebEntidades.Forecast forecast = new CedForecastWebEntidades.Forecast();
                string idArticulo = dt.Rows[0]["IdArticulo"].ToString();
                CopiarCab(dt.Rows[0], forecast, Forecast.IdPeriodo);
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
                        forecast = new CedForecastWebEntidades.Forecast();
                        CopiarCab(dt.Rows[i], forecast, Forecast.IdPeriodo);
                    }
                    CopiarDet(dt.Rows[i], forecast, mes);
                 }
                 lista.Add(forecast);
            }
            return lista;
        }
        private void CopiarCab(DataRow Desde, CedForecastWebEntidades.Forecast Hasta, string PeriodoInicial)
        {
            Hasta.IdTipoPlanilla = Convert.ToString(Desde["IdTipoPlanilla"]);
            Hasta.IdCuenta = Convert.ToString(Desde["IdCuenta"]);
            Hasta.IdCliente = Convert.ToString(Desde["IdCliente"]);
            Hasta.Articulo = new CedForecastWebEntidades.Articulo();
            Hasta.Articulo.Id = Convert.ToString(Desde["IdArticulo"]);
            Hasta.Articulo.Descr = Convert.ToString(Desde["DescrArticulo"]);
            Hasta.Articulo.GrupoArticulo.IdGrupoArticulo = Convert.ToString(Desde["IdGrupoArticulo"]);
            Hasta.Articulo.GrupoArticulo.DescrGrupoArticulo = Convert.ToString(Desde["DescrGrupoArticulo"]);
            Hasta.Articulo.GrupoArticulo.Division.Id = Convert.ToString(Desde["IdDivision"]);
            Hasta.Articulo.GrupoArticulo.Division.Descr = Convert.ToString(Desde["DescrDivision"]);
            Hasta.IdPeriodo = PeriodoInicial;
        }
        private void CopiarDet(DataRow Desde, CedForecastWebEntidades.Forecast Hasta, int Mes)
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
            DateTime fechaUltimoMesForecast = Convert.ToDateTime("01/" + Periodo.Substring(4, 2) + "/" + Periodo.Substring(0, 4));
            fechaUltimoMesForecast = fechaUltimoMesForecast.AddMonths(11);
            return fechaUltimoMesForecast.ToString("yyyyMM");
        }
        private int MesAProcesar(string PeriodoAProcesar, string PeriodoInicial)
        {
            int i = 0;
            DateTime fechaAux = Convert.ToDateTime("01/" + PeriodoInicial.Substring(4, 2) + "/" + PeriodoInicial.Substring(0, 4));
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
            DateTime fechaAux = Convert.ToDateTime("01/" + PeriodoInicial.Substring(4, 2) + "/" + PeriodoInicial.Substring(0, 4));
            fechaAux = fechaAux.AddMonths(i);
            return fechaAux.ToString("yyyyMM");
        }
        public void Guardar(List<CedForecastWebEntidades.Forecast> ForecastLista, string IdTipoPlanilla, string IdCuenta, string IdCliente, string Periodo)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("delete Forecast where IdCuenta = '" + IdCuenta + "' and IdCliente = '" + IdCliente + "' ");
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
            foreach (CedForecastWebEntidades.Forecast Forecast in ForecastLista)
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
    }
}
