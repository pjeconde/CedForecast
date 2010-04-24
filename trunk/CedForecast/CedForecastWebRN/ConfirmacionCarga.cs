using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
    public class ConfirmacionCarga
    {
        public ConfirmacionCarga()
        {
        }
        public static List<CedForecastWebEntidades.ConfirmacionCarga> Lista(CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCarga, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.ConfirmacionCarga confirmacionCarga = new CedForecastWebDB.ConfirmacionCarga(Sesion);
            return confirmacionCarga.Leer(ConfirmacionCarga);
        }
    }
}
