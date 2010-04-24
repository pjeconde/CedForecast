using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
    public class Periodo
    {
        public Periodo()
        {
        }
        public static List<CedForecastWebEntidades.Periodo> Leer(CedForecastWebEntidades.Periodo Periodo, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Periodo periodo = new CedForecastWebDB.Periodo(Sesion);
            return periodo.Leer(Periodo);
        }
    }
}
