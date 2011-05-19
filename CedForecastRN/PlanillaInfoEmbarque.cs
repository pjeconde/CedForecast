using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastRN
{
    public static class PlanillaInfoEmbarque
    {
        public static string LeerDirectorio(CedEntidades.Sesion Sesion)
        {
            return new CedForecastDB.PlanillaInfoEmbarque(Sesion).Leer();
        }
        public static void GuardarDirectorio(string Directorio, CedEntidades.Sesion Sesion)
        {
        }
    }
}
