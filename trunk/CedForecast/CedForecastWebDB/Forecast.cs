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
            a.Append("select Forecast.IdCuenta, Forecast.IdDivision, Forecast.IdCliente, Forecast.Fecha, Forecast.IdArticulo, Articulo.DescrArticulo, Forecast.Cantidad ");
            a.Append("from Forecast, Articulo ");
            a.Append("where Forecast.IdArticulo=Articulo.IdArticulo and IdCuenta='" + Forecast.IdCuenta + "' and IdDivision='" + Forecast.IdDivision + "' and IdCliente='" + Forecast.IdCliente + "' ");
            DateTime fecha = UltimoMesForecast(Forecast.Fecha);
            a.Append("and Fecha >= '" + Forecast.Fecha.ToString("yyyyMM01") + "' ");
            a.Append("and Fecha < '" + fecha.ToString("yyyyMMdd") + "' ");
            a.Append("order by IdArticulo asc, Fecha asc");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.Forecast> lista = new List<CedForecastWebEntidades.Forecast>();
            CedForecastWebEntidades.Forecast forecast = new CedForecastWebEntidades.Forecast();
            if (dt.Rows.Count != 0)
            {
                string idArticulo = dt.Rows[0]["IdArticulo"].ToString();
                CopiarCab(dt.Rows[0], forecast, Forecast.Fecha);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int mes = MesAProcesar(Convert.ToDateTime(dt.Rows[i]["Fecha"]), Forecast.Fecha);
                    if (idArticulo != dt.Rows[i]["IdArticulo"].ToString())
                    {
                        idArticulo = dt.Rows[i]["IdArticulo"].ToString();
                        lista.Add(forecast);
                        forecast = new CedForecastWebEntidades.Forecast();
                        CopiarCab(dt.Rows[i], forecast, Forecast.Fecha);
                    }
                    CopiarDet(dt.Rows[i], forecast, mes);
                 }
            }
            lista.Add(forecast);
            return lista;
        }
        private void CopiarCab(DataRow Desde, CedForecastWebEntidades.Forecast Hasta, DateTime FechaInicial)
        {
            Hasta.IdCuenta = Convert.ToString(Desde["IdCuenta"]);
            Hasta.IdDivision = Convert.ToString(Desde["IdDivision"]);
            Hasta.IdCliente = Convert.ToString(Desde["IdCliente"]);
            Hasta.Articulo = new CedForecastWebEntidades.Articulo();
            Hasta.Articulo.IdArticulo = Convert.ToString(Desde["IdArticulo"]);
            Hasta.Articulo.DescrArticulo = Convert.ToString(Desde["DescrArticulo"]);
            Hasta.Fecha = Convert.ToDateTime(FechaInicial.ToString("01/MM/yyyy"));
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
            }
        }
        private DateTime UltimoMesForecast(DateTime Fecha)
        {
            DateTime fechaUltimoMesForecast = Fecha.AddMonths(11);
            fechaUltimoMesForecast = fechaUltimoMesForecast.AddDays(1);
            return fechaUltimoMesForecast;
        }
        private int MesAProcesar(DateTime FechaAProcesar, DateTime FechaInicial)
        {
            int i = 0;
            DateTime fechaAux = FechaInicial;
            for (i = 1; i <= 12; i++)
            {
                if (fechaAux.Month == FechaAProcesar.Month)
                {
                    break;
                }
                fechaAux = fechaAux.AddMonths(1);
            }
            return i;
        }
        private DateTime FechaAProcesar(int i, DateTime FechaInicial)
        {
            return FechaInicial.AddMonths(i);
        }
        public void Guardar(List<CedForecastWebEntidades.Forecast> ForecastLista, string IdCuenta, string IdDivision, string IdCliente, DateTime Fecha)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("delete Forecast where IdCuenta = '" + IdCuenta + "' and IdDivision = '" + IdDivision + "' and IdCliente = '" + IdCliente + "' ");
            a.Append("and Fecha >= '" + Fecha.ToString("yyyyMM01") + "' and Fecha < '" + UltimoMesForecast(Fecha).ToString("yyyyMMdd") + "' ");
            foreach (CedForecastWebEntidades.Forecast Forecast in ForecastLista)
            {
                if (Forecast.Articulo.IdArticulo != null)
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
                        a.Append("Insert Forecast values ('" + Forecast.IdCuenta + "', '" + Forecast.IdDivision + "', '" + Forecast.IdCliente + "', '");
                        a.Append(Forecast.Articulo.IdArticulo + "', '" + FechaAProcesar(i - 1, Forecast.Fecha).ToString("yyyyMMdd") + "', " + cantidad + ") ");
                    }
                }
            }
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}
