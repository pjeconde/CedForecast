using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastRN
{
    public class FamiliaArticulo : Proceso
    {
        private CedEntidades.Sesion sesion;
        private string cedForecastWSRUL;

        public FamiliaArticulo(CedEntidades.Sesion Sesion, string CedForecastWSRUL)
        {
            sesion = Sesion;
            cedForecastWSRUL = CedForecastWSRUL;
        }
        public void Enviar()
        {
            try
            {
                WS.Sincronizacion ws = new WS.Sincronizacion();
                ws.Url = cedForecastWSRUL;
                ws.EliminarFamiliasArticuloXArticulo();
                ws.EliminarFamiliasArticulo();
                //FamiliaArticulo
                CedForecastDB.FamiliaArticulo datos = new CedForecastDB.FamiliaArticulo(sesion);
                List<CedForecastEntidades.FamiliaArticulo> lista = datos.LeerLista();
                contador = 0;
                contadorTope = lista.Count;
                for (contador = 0; contador < contadorTope; contador++)
                {
                    WS.FamiliaArticulo elemento = new WS.FamiliaArticulo();
                    elemento.Id = lista[contador].Id;
                    elemento.Descr = lista[contador].Descr;
                    ws.EnviarFamiliaArticulo(elemento);
                }
                //FamiliaArticuloXArticulo
                CedForecastDB.Articulo datosArticulo = new CedForecastDB.Articulo(sesion);
                List<CedForecastEntidades.Articulo> listaArticulo = datosArticulo.LeerLista();
                contador = 0;
                contadorTope = listaArticulo.Count;
                for (contador = 0; contador < contadorTope; contador++)
                {
                    WS.FamiliaArticuloXArticulo elemento = new WS.FamiliaArticuloXArticulo();
                    elemento.Id = listaArticulo[contador].Id;
                    elemento.Familia = new WS.FamiliaArticulo();
                    elemento.Familia.Id = listaArticulo[contador].Familia.Id;
                    elemento.Familia.Descr = listaArticulo[contador].Familia.Descr;
                    ws.EnviarFamiliaArticuloXArticulo(elemento);
                }
            }
            catch (Exception Ex)
            {
                errores.Add(Ex);
            }
        }
    }
}
