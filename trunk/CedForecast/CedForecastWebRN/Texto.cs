using System;
using System.Collections.Generic;
using System.Text;
namespace CedForecastWebRN
{
    public static class Texto
    {
        public static void Leer(CedForecastWebEntidades.Texto Texto, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Texto texto = new CedForecastWebDB.Texto(Sesion);
            texto.Leer(Texto);
        }
    }
}