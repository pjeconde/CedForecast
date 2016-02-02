using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
    public class RFoPA
    {
        public RFoPA()
        {
        }
        public static List<CedForecastWebEntidades.RFoPA> Lista(CedForecastWebEntidades.RFoPA Forecast, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.RFoPA forecast = new CedForecastWebDB.RFoPA(Sesion);
            return forecast.Lista(Forecast);
        }
        public static void Guardar(List<CedForecastWebEntidades.RFoPA> Forecast, string IdTipoPlanilla, string IdCuenta, string IdCliente, string IdFamiliaArticulo, string Periodo, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.RFoPA forecast = new CedForecastWebDB.RFoPA(Sesion);
            forecast.Guardar(Forecast, IdTipoPlanilla, IdCuenta, IdCliente, IdFamiliaArticulo, Periodo);
        }
        public static List<CedForecastWebEntidades.RFoPA> Lista(out int CantidadFilas, int IndicePagina, int TamañoPagina, string OrderBy, CedForecastWebEntidades.RFoPA Forecast, string SessionID, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.RFoPA forecast = new CedForecastWebDB.RFoPA(Sesion);
            List<CedForecastWebEntidades.RFoPA> listaForecast = new List<CedForecastWebEntidades.RFoPA>();
            listaForecast = forecast.Lista(Forecast);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "IdPeriodo desc";
            }
            //Buscar primer mes de ejercicio economico.
            string ProyectadoMesInicio = System.Configuration.ConfigurationManager.AppSettings["ProyectadoMesInicio"];
            DateTime FechaInicio = DateTime.Today;
            if (Convert.ToInt32(Forecast.IdPeriodo.Substring(4, 2)) < Convert.ToInt32(ProyectadoMesInicio))
            {
                FechaInicio = Convert.ToDateTime("01/" + ProyectadoMesInicio + "/" + Convert.ToDateTime("01/" + Forecast.IdPeriodo.Substring(4, 2) + "/" + Forecast.IdPeriodo.Substring(0, 4)).AddYears(-1).Year);
            }
            else
            {
                FechaInicio = Convert.ToDateTime("01/" + ProyectadoMesInicio + "/" + Forecast.IdPeriodo.Substring(0, 4));
            }
            //Diferencia entre el año-mes del ejercicio económico y año-mes inicial del Rolling
            int cantidadMesesParaDevio = MesAProcesar(Forecast.IdPeriodo, FechaInicio.ToString("yyyyMM"));
            cantidadMesesParaDevio = cantidadMesesParaDevio - 1;
            return forecast.Lista(out CantidadFilas, IndicePagina, TamañoPagina, OrderBy, SessionID, listaForecast, cantidadMesesParaDevio);
        }
        public static List<CedForecastWebEntidades.RFoPA> TotalProyectado(CedForecastWebEntidades.RFoPA Forecast, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.RFoPA forecast = new CedForecastWebDB.RFoPA(Sesion);
            return forecast.TotalProyectado(Forecast);
        }
        private static int MesAProcesar(string PeriodoAProcesar, string PeriodoInicial)
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
    }
}
