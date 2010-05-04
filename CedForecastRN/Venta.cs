using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastRN
{
    public class Venta : Proceso
    {
        private CedEntidades.Sesion sesion;
        private string cedForecastWSRUL;
        private string periodo;

        public Venta(string Periodo, CedEntidades.Sesion Sesion, string CedForecastWSRUL)
            : base()
        {
            periodo = Periodo;
            sesion = Sesion;
            cedForecastWSRUL = CedForecastWSRUL;
        }
        public void EnviarNovedades()
        {
            CedForecastDB.Bejerman.Ventas datos = new CedForecastDB.Bejerman.Ventas(sesion);
            List<CedForecastEntidades.Bejerman.Ventas> lista = datos.LeerNovedades(periodo);
            WS.Sincronizacion ws = new WS.Sincronizacion();
            ws.Url = cedForecastWSRUL;
            contador = 0;
            contadorTope = lista.Count;
            ws.IniciarEnvioVenta();
            for (contador = 0; contador < contadorTope; contador++)
            {
                WS.Venta elemento = new WS.Venta();
                elemento.IdPeriodo = periodo;
                elemento.IdArticulo = lista[contador].Sdvart_CodGen;
                elemento.IdCliente = lista[contador].Cve_CodCli;
                elemento.Cantidad = lista[contador].Sdv_CantUM1;
                ws.EnviarVenta(elemento);
            }
            ws.TerminarEnvioVenta();
        }
    }
}