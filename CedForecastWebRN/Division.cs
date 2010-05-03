using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
    public class Division
    {
        public Division()
        {
        }
        public static List<CedForecastWebEntidades.Division> Lista(bool ConDivisionSinInformar, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Division division = new CedForecastWebDB.Division(Sesion);
            return division.Lista(ConDivisionSinInformar);
        }
    }
}
