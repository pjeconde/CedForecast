using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB
{
    public class FamiliaArticulo: db
    {
        public FamiliaArticulo(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public List<CedForecastEntidades.FamiliaArticulo> LeerLista()
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select IdFamiliaArticulo, DescrFamiliaArticulo from FamiliaArticulo order by IdFamiliaArticulo");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastEntidades.FamiliaArticulo> lista = new List<CedForecastEntidades.FamiliaArticulo>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastEntidades.FamiliaArticulo elemento = new CedForecastEntidades.FamiliaArticulo();
                    Copiar(dt.Rows[i], elemento);
                    LeerArticulos(elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        public void Leer(CedForecastEntidades.FamiliaArticulo FamiliaArticulo)
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select IdFamiliaArticulo, DescrFamiliaArticulo from FamiliaArticulo where IdFamiliaArticulo='" + FamiliaArticulo.Id + "' ");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                Copiar(dt.Rows[0], FamiliaArticulo);
            }
        }
        private void Copiar(DataRow Desde, CedForecastEntidades.FamiliaArticulo Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdFamiliaArticulo"]);
            Hasta.Descr = Convert.ToString(Desde["DescrFamiliaArticulo"]);
        }
        private void LeerArticulos(CedForecastEntidades.FamiliaArticulo FamiliaArticulo)
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select IdArticulo from ArticuloInfoAdicional where IdFamiliaArticulo='" + FamiliaArticulo.Id + "' order by IdArticulo");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            FamiliaArticulo.Articulos.Clear();
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
                    elemento.Familia = FamiliaArticulo;
                    FamiliaArticulo.Articulos.Add(elemento);
                }
            }
        }
        public void Crear(CedForecastEntidades.FamiliaArticulo Familia)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("insert FamiliaArticulo values ('" + Familia.Id + "', '" + Familia.Descr + "') ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Eliminar(CedForecastEntidades.FamiliaArticulo Familia)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("delete FamiliaArticulo where IdFamiliaArticulo='" + Familia.Id + "'");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Modificar(CedForecastEntidades.FamiliaArticulo Familia)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("update FamiliaArticulo set DescrFamiliaArticulo='" + Familia.Descr + "' where IdFamiliaArticulo='" + Familia.Id + "'");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}