using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastRN
{
    public class ProyeccionAnual : Proceso
    {
        private CedEntidades.Sesion sesion;
        private string cedForecastWSRUL;
        private string a�o;

        public ProyeccionAnual(CedEntidades.Sesion Sesion, string CedForecastWSRUL, string A�o)
        {
            sesion = Sesion;
            cedForecastWSRUL = CedForecastWSRUL;
            a�o = A�o;
        }
        public void RecibirNovedades()
        {
            WS.Sincronizacion ws = new WS.Sincronizacion();
            ws.Url = cedForecastWSRUL;
            WS.Forecast[] lista = ws.RecibirProyeccionAnual(a�o);
            contador = 0;
            contadorTope = lista.Length;
            CedForecastDB.Forecast db = new CedForecastDB.Forecast(sesion);
            db.EliminarProyectadoAnual(a�o);
            for (contador = 0; contador < contadorTope; contador++)
            {
                CedForecastEntidades.Forecast elemento = new CedForecastEntidades.Forecast();
                elemento.IdTipoPlanilla = lista[contador].IdTipoPlanilla;
                elemento.IdCuenta = lista[contador].IdCuenta;
                elemento.IdCliente = lista[contador].Cliente.Id;
                elemento.IdArticulo = lista[contador].Articulo.Id;
                elemento.IdPeriodo = lista[contador].IdPeriodo;
                elemento.Cantidad = lista[contador].Cantidad;
                db.Crear(elemento);
            }
        }
    }
}