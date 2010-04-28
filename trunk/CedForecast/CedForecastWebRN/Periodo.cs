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
        public static void Leer(CedForecastWebEntidades.Periodo Periodo, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Periodo periodo = new CedForecastWebDB.Periodo(Sesion);
            periodo.Leer(Periodo);
        }
        public static void Modificar(CedForecastWebEntidades.Periodo Periodo, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Periodo periodo = new CedForecastWebDB.Periodo(Sesion);
            periodo.Modificar(Periodo);
        }
    }
}
