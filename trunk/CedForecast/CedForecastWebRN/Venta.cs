using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
    public class Venta
    {
        public Venta()
        {
        }
        public static List<CedForecastWebEntidades.Venta> ConsultarTotales(string PeriodoDsd, string PeriodoHst, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Venta venta = new CedForecastWebDB.Venta(Sesion);
            return venta.ConsultarTotales(PeriodoDsd, PeriodoHst);
        }
    }
}
