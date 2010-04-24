using System;
using System.Collections.Generic;
using System.Text;
namespace CedForecastWebRN
{
    public static class Flag
    {
        public static void Leer(CedForecastWebEntidades.Flag Flag, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Flag flag = new CedForecastWebDB.Flag(Sesion);
            flag.Leer(Flag);
        }
        public static void SetearModoDepuracion(CedForecastWebEntidades.Flag Flag, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Flag flag = new CedForecastWebDB.Flag(Sesion);
            flag.SetearModoDepuracion(Flag);
        }
        public static void SetearPremiumSinCostoEnAltaCuenta(CedForecastWebEntidades.Flag Flag, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Flag flag = new CedForecastWebDB.Flag(Sesion);
            flag.SetearPremiumSinCostoEnAltaCuenta(Flag);
        }
        public static void SetearCreacionCuentaHabilitada(CedForecastWebEntidades.Flag Flag, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Flag flag = new CedForecastWebDB.Flag(Sesion);
            flag.SetearCreacionCuentaHabilitada(Flag);
        }
    }
}