using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
    public class RollingForecast
    {
        public RollingForecast()
        {
        }
        public static List<CedForecastWebEntidades.RollingForecast> Lista(CedForecastWebEntidades.RollingForecast Forecast, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.RollingForecast forecast = new CedForecastWebDB.RollingForecast(Sesion);
            return forecast.Lista(Forecast);
        }
        public static void Guardar(List<CedForecastWebEntidades.RollingForecast> Forecast, string IdTipoPlanilla, string IdCuenta, string IdCliente, string IdFamiliaArticulo, string Periodo, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.RollingForecast forecast = new CedForecastWebDB.RollingForecast(Sesion);
            forecast.Guardar(Forecast, IdTipoPlanilla, IdCuenta, IdCliente, IdFamiliaArticulo, Periodo);
        }
        public static List<CedForecastWebEntidades.RollingForecast> Lista(out int CantidadFilas, int IndicePagina, int TamañoPagina, string OrderBy, CedForecastWebEntidades.RollingForecast Forecast, string SessionID, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.RollingForecast forecast = new CedForecastWebDB.RollingForecast(Sesion);
            List<CedForecastWebEntidades.RollingForecast> listaForecast = new List<CedForecastWebEntidades.RollingForecast>();
            listaForecast = forecast.Lista(Forecast);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "IdPeriodo desc";
            }
            return forecast.Lista(out CantidadFilas, IndicePagina, TamañoPagina, OrderBy, SessionID, listaForecast);
        }
        public static List<CedForecastWebEntidades.RollingForecast> TotalProyectado(CedForecastWebEntidades.RollingForecast Forecast, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.RollingForecast forecast = new CedForecastWebDB.RollingForecast(Sesion);
            return forecast.TotalProyectado(Forecast);
        }
    }
}
