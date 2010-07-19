using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
    public class FamiliaArticulo
    {
        public FamiliaArticulo()
        {
        }
        public static List<CedForecastWebEntidades.FamiliaArticulo> ListaConFamiliaArticuloSinInformar(CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.FamiliaArticulo familiaArticulo = new CedForecastWebDB.FamiliaArticulo(Sesion);
            return familiaArticulo.ListaConFamiliaArticuloSinInformar();
        }
    }
}
