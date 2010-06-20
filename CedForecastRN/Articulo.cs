using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastRN
{
    public class Articulo : Proceso
    {
        private CedEntidades.Sesion sesion;
        private string cedForecastWSRUL;

        public Articulo(CedEntidades.Sesion Sesion, string CedForecastWSRUL)
            : base()
        {
            sesion = Sesion;
            cedForecastWSRUL = CedForecastWSRUL;
        }
        public void EnviarNovedades()
        {
            try
            {
                WS.Sincronizacion ws = new WS.Sincronizacion();
                ws.Url = cedForecastWSRUL;
                DateTime fechaUltimaSincronizacion = ws.FechaUltimaSincronizacionArticulos();
                CedForecastDB.Bejerman.Articulos datos = new CedForecastDB.Bejerman.Articulos(sesion);
                List<CedForecastEntidades.Bejerman.Articulos> lista = datos.LeerNovedades(fechaUltimaSincronizacion);
                contador = 0;
                contadorTope = lista.Count;
                for (contador = 0; contador < contadorTope; contador++)
                {
                    WS.Articulo elemento = new WS.Articulo();
                    elemento.Id = lista[contador].Art_CodGen;
                    elemento.Descr = lista[contador].Art_DescGen;
                    elemento.PesoBruto = lista[contador].Art_PesoBruto;
                    elemento.UnidadMedida = lista[contador].Artcla_Cod;
                    elemento.GrupoArticulo = new CedForecastRN.WS.GrupoArticulo();
                    elemento.GrupoArticulo.IdGrupoArticulo = lista[contador].Artda2_cod;
                    elemento.Habilitado = true;
                    elemento.FechaUltModif = lista[contador].Art_FecMod;
                    ws.EnviarArticulo(elemento);
                }
            }
            catch (Exception Ex)
            {
                errores.Add(Ex);
            }
        }
    }
}