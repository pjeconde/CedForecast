using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastRN
{
    public class Cotizacion
    {
        public Cotizacion()
        {
        }
        public static List<CedForecastEntidades.Bejerman.Cotizacion> Lista(CedEntidades.Sesion Sesion)
        {
            CedForecastDB.Bejerman.Cotizacion db = new CedForecastDB.Bejerman.Cotizacion(Sesion);
            return db.LeerLista();
        }
    }
        
}
