using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastRN
{
    public static class Tabla
    {
        public static List<CedForecastEntidades.Codigo> Leer(string Tabla, CedEntidades.Sesion Sesion)
        {
            return new CedForecastDB.Tabla(Sesion).Leer(Tabla);
        }
    }
}
