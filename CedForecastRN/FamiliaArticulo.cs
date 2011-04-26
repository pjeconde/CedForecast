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
        public FamiliaArticulo(CedEntidades.Sesion Sesion)
        {
            sesion = Sesion;
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
                CedForecastDB.ArticuloInfoAdicional datosArticulo = new CedForecastDB.ArticuloInfoAdicional(sesion);
                List<CedForecastEntidades.ArticuloInfoAdicional> listaArticulo = datosArticulo.LeerLista();
                contador = 0;
                contadorTope = listaArticulo.Count;
                for (contador = 0; contador < contadorTope; contador++)
                {
                    WS.FamiliaArticuloXArticulo elemento = new WS.FamiliaArticuloXArticulo();
                    elemento.Id = listaArticulo[contador].IdArticulo;
                    elemento.Familia = new WS.FamiliaArticulo();
                    elemento.Familia.Id = listaArticulo[contador].IdFamiliaArticulo;
                    elemento.Familia.Descr = listaArticulo[contador].DescrFamiliaArticulo;
                    ws.EnviarFamiliaArticuloXArticulo(elemento);
                }
            }
            catch (Exception Ex)
            {
                errores.Add(Ex);
            }
        }
        public void Leer(CedForecastEntidades.FamiliaArticulo Familia)
        {
            new CedForecastDB.FamiliaArticulo(sesion).Leer(Familia);
        }
        public void Crear(CedForecastEntidades.FamiliaArticulo Familia)
        {
            Validar(Familia);
            new CedForecastDB.FamiliaArticulo(sesion).Crear(Familia);
        }
        public void Eliminar(CedForecastEntidades.FamiliaArticulo Familia)
        {
            new CedForecastDB.FamiliaArticulo(sesion).Eliminar(Familia);
        }
        public void Modificar(CedForecastEntidades.FamiliaArticulo Familia)
        {
            Validar(Familia);
            new CedForecastDB.FamiliaArticulo(sesion).Modificar(Familia);
        }
        private void Validar(CedForecastEntidades.FamiliaArticulo Familia)
        {
            if (Familia.Id.Equals(String.Empty))
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Id");
            }
            if (Familia.Descr.Equals(String.Empty))
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Descripción");
            }
        }
        public void AgregarArticulo(CedForecastEntidades.FamiliaArticulo Familia, CedForecastEntidades.Articulo Articulo)
        {
            CedForecastEntidades.Articulo articuloEncontrado = Familia.Articulos.Find(delegate(CedForecastEntidades.Articulo c) { return c.Id == Articulo.Id; });
            if (articuloEncontrado != null)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoExistente("Artículo");
            }
            else
            {
                Familia.Articulos.Add(Articulo);
            }
        }
        public void EliminarArticulo(CedForecastEntidades.FamiliaArticulo Familia, CedForecastEntidades.Articulo Articulo)
        {
            Familia.Articulos.Remove(Articulo);
            //La colección, después del remove, queda con problemas para bindearla a una grilla.
            //Para evitarlo, vuelvo a generar de cero la colección.
            List<CedForecastEntidades.Articulo> nuevaLista=new List<CedForecastEntidades.Articulo>();
            for (int i = 0; i < Familia.Articulos.Count; i++)
            {
                nuevaLista.Add(Familia.Articulos[i]);
            }
            Familia.Articulos = nuevaLista;
        }
    }
}
