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
    }
}
