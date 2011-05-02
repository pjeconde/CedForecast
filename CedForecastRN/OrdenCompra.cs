using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastRN
{
    public static class OrdenCompra
    {
        public static List<CedForecastEntidades.OrdenCompra> LeerLista(DateTime FechaDsd, DateTime FechaHst, string Estados, CedEntidades.Sesion Sesion)
        {
            return new CedForecastDB.OrdenCompra(Sesion).LeerLista(FechaDsd, FechaHst, Estados);
        }
    }
}