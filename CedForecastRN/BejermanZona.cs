using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastRN
{
    public static class Zona
    {
        public static void EnviarNovedades(CedEntidades.Sesion Sesion)
        {
            WS.Sincronizacion ws = new WS.Sincronizacion();
            ws.Url = "http://localhost:3000/Sincronizacion.asmx";
            DateTime fechaUltimaSincronizacion = ws.FechaUltimaSincronizacionZonas();
            CedForecastDB.Bejerman.Zona datos = new CedForecastDB.Bejerman.Zona(Sesion);
            List<CedForecastEntidades.Bejerman.Zona> lista = datos.LeerNovedades(fechaUltimaSincronizacion);
            for (int i = 0; i < lista.Count; i++)
            {
                WS.Zona elemento = new WS.Zona();
                elemento.IdZona = lista[i].Zon_Cod;
                elemento.DescrZona = lista[i].Zon_Desc;
                elemento.Habilitada = true;
                elemento.FechaUltModif = lista[i].Zon_FecMod;
                ws.EnviarZona(elemento);
            }
        }
    }
}
