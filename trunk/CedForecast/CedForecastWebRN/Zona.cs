using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
    public class Zona
    {
        public Zona()
        {
        }
        public static List<CedForecastWebEntidades.Zona> Lista(CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Zona zona = new CedForecastWebDB.Zona(Sesion);
            return zona.Lista();
        }
    }
}
