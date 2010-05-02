using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastRN
{
    public class Zona : Proceso
    {
        private CedEntidades.Sesion sesion;
        private string cedForecastWSRUL;

        public Zona(CedEntidades.Sesion Sesion, string CedForecastWSRUL)
        {
            sesion = Sesion;
            cedForecastWSRUL = CedForecastWSRUL;
        }
        public void EnviarNovedades()
        {
            WS.Sincronizacion ws = new WS.Sincronizacion();
            ws.Url = cedForecastWSRUL;
            DateTime fechaUltimaSincronizacion = ws.FechaUltimaSincronizacionZonas();
            CedForecastDB.Bejerman.Zona datos = new CedForecastDB.Bejerman.Zona(sesion);
            List<CedForecastEntidades.Bejerman.Zona> lista = datos.LeerNovedades(fechaUltimaSincronizacion);
            contador = 0;
            contadorTope = lista.Count;
            for (contador = 0; contador < contadorTope; contador++)
            {
                WS.Zona elemento = new WS.Zona();
                elemento.IdZona = lista[contador].Zon_Cod;
                elemento.DescrZona = lista[contador].Zon_Desc;
                elemento.Habilitada = true;
                elemento.FechaUltModif = lista[contador].Zon_FecMod;
                ws.EnviarZona(elemento);
            }
        }
    }
}
