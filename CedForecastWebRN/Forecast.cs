using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
    public class Forecast
    {
        public Forecast()
        {
        }
        public static List<CedForecastWebEntidades.Forecast> Lista(CedForecastWebEntidades.Forecast Forecast, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Forecast forecast = new CedForecastWebDB.Forecast(Sesion);
            return forecast.Lista(Forecast);
        }
        public static void Guardar(List<CedForecastWebEntidades.Forecast> Forecast, string IdCuenta, string IdCliente, DateTime Fecha, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Forecast forecast = new CedForecastWebDB.Forecast(Sesion);
            forecast.Guardar(Forecast, IdCuenta, IdCliente, Fecha);
        }
    }
}
