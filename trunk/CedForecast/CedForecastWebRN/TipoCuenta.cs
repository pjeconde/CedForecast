using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
    public class TipoCuenta
    {
        public TipoCuenta()
        {
        }
        public static List<CedForecastWebEntidades.TipoCuenta> Lista(bool ConTipoCuentaSinInformar, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.TipoCuenta tipoCuenta = new CedForecastWebDB.TipoCuenta(Sesion);
            return tipoCuenta.Lista(ConTipoCuentaSinInformar);
        }
    }
}
