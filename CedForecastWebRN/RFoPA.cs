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
            return forecast.Lista(out CantidadFilas, IndicePagina, TamañoPagina, OrderBy, SessionID, listaForecast);
        }
        public static List<CedForecastWebEntidades.RFoPA> TotalProyectado(CedForecastWebEntidades.RFoPA Forecast, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.RFoPA forecast = new CedForecastWebDB.RFoPA(Sesion);
            return forecast.TotalProyectado(Forecast);
        }
    }
}
