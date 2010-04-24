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
        public static List<CedForecastWebEntidades.Division> Lista(CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Division division = new CedForecastWebDB.Division(Sesion);
            return division.Lista();
        }
    }
}
