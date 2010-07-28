using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
    public class ForecastReasignar
    {
        public static void Modificar(List<CedForecastWebEntidades.RFoPA> RFoPA, string TipoDatoAReasignar, string ValorAReasignar, string Periodo, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.ForecastReasignar forecastReasignar = new CedForecastWebDB.ForecastReasignar(Sesion);
            forecastReasignar.Modificar(RFoPA, TipoDatoAReasignar, ValorAReasignar, Periodo);
        }
    }
}
