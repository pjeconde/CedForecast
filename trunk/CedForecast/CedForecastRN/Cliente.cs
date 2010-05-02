using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastRN
{
    public class Cliente : Proceso
    {
        private CedEntidades.Sesion sesion;
        private string cedForecastWSRUL;

        public Cliente(CedEntidades.Sesion Sesion, string CedForecastWSRUL) : base()
        {
            sesion = Sesion;
            cedForecastWSRUL = CedForecastWSRUL;
        }
        public void EnviarNovedades()
        {
            WS.Sincronizacion ws = new WS.Sincronizacion();
            ws.Url = cedForecastWSRUL;
            DateTime fechaUltimaSincronizacion = ws.FechaUltimaSincronizacionClientes();
            CedForecastDB.Bejerman.Clientes datos = new CedForecastDB.Bejerman.Clientes(sesion);
            List<CedForecastEntidades.Bejerman.Clientes> lista = datos.LeerNovedades(fechaUltimaSincronizacion);
            contador = 0;
            contadorTope = lista.Count;
            for (contador = 0; contador < contadorTope; contador++)
            {
                WS.Cliente elemento = new WS.Cliente();
                elemento.IdCliente = lista[contador].Cli_Cod;
                elemento.DescrCliente = lista[contador].Cli_RazSoc;
                elemento.Zona = new CedForecastRN.WS.Zona();
                elemento.Zona.IdZona = lista[contador].Clizon_Cod;
                elemento.Habilitado = lista[contador].Cli_Habilitado;
                elemento.FechaUltModif = lista[contador].Cli_FecMod;
                ws.EnviarCliente(elemento);
            }
        }
    }
}
