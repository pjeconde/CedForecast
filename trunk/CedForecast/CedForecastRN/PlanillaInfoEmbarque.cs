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
            new CedForecastDB.PlanillaInfoEmbarque(Sesion).Guardar(Directorio);
        }
        public static void Procesar(string Directorio, CedEntidades.Sesion Sesion)
        {
            new CedForecastDB.PlanillaInfoEmbarque(Sesion).Guardar(Directorio);
        }
    }
}
