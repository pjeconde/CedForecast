using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
    public class Articulo
    {
        public Articulo()
        {
        }
        public static List<CedForecastWebEntidades.Articulo> Lista(CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Articulo articulo = new CedForecastWebDB.Articulo(Sesion);
            return articulo.Lista();
        }
    }
}
