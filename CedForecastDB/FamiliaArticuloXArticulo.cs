using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB
{
    public class FamiliaArticuloXArticulo : db
    {
        public FamiliaArticuloXArticulo(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public List<CedForecastEntidades.Articulo> LeerLista(string ListaFamilias)
        {
            List<CedForecastEntidades.Articulo> lista = new List<CedForecastEntidades.Articulo>();
            if (ListaFamilias != String.Empty)
            {
                DataTable dt = new DataTable();
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ArticuloInfoAdicional.IdArticulo, ArticuloInfoAdicional.IdFamiliaArticulo, FamiliaArticulo.DescrFamiliaArticulo ");
                a.Append("from ArticuloInfoAdicional, FamiliaArticulo ");
                a.Append("where ArticuloInfoAdicional.IdFamiliaArticulo=FamiliaArticulo.IdFamiliaArticulo ");
                a.Append("and ArticuloInfoAdicional.IdFamiliaArticulo in (" + ListaFamilias.ToString() + ") ");
                a.Append("order by FamiliaArticulo.DescrFamiliaArticulo, ArticuloInfoAdicional.IdArticulo ");
                dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    List<CedForecastEntidades.Bejerman.Articulos> articulos = new CedForecastDB.Bejerman.Articulos(sesion).LeerLista();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CedForecastEntidades.Articulo elemento = new CedForecastEntidades.Articulo();
                        elemento.Id = Convert.ToString(dt.Rows[i]["IdArticulo"]);
                        CedForecastEntidades.Bejerman.Articulos articulo = articulos.Find(delegate(CedForecastEntidades.Bejerman.Articulos c) { return c.Art_CodGen == Convert.ToString(dt.Rows[i]["IdArticulo"]); });
                        if (articulo == null)
                        {
                            elemento.Descr = "<<<Desconocido>>>";
                        }
                        else
                        {
                            elemento.Descr = articulo.Art_DescGen;
                        }
                        elemento.Familia = new CedForecastEntidades.FamiliaArticulo();
                        elemento.Familia.Id = Convert.ToString(dt.Rows[i]["IdFamiliaArticulo"]);
                        elemento.Familia.Descr = Convert.ToString(dt.Rows[i]["DescrFamiliaArticulo"]);
                        lista.Add(elemento);
                    }
                }
            }
            return lista;
        }
    }
}