using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastWebDB
{
    public class FamiliaArticuloXArticulo: db
    {
        public FamiliaArticuloXArticulo(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public List<CedForecastWebEntidades.FamiliaArticuloXArticulo> Lista()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select Articulo.IdArticulo, FamiliaArticulo.IdFamiliaArticulo, FamiliaArticulo.DescrFamiliaArticulo from Articulo, FamiliaArticulo where Articulo.IdFamiliaArticulo=FamiliaArticulo.IdFamiliaArticulo order by Articulo.IdArticulo ");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.FamiliaArticuloXArticulo> lista = new List<CedForecastWebEntidades.FamiliaArticuloXArticulo>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastWebEntidades.FamiliaArticuloXArticulo elemento = new CedForecastWebEntidades.FamiliaArticuloXArticulo();
                    Copiar(dt.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastWebEntidades.FamiliaArticuloXArticulo Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdArticulo"]);
            Hasta.Familia.Id = Convert.ToString(Desde["IdFamiliaArticulo"]);
            Hasta.Familia.Descr = Convert.ToString(Desde["DescrFamiliaArticulo"]);
        }
        public void EliminarTodas()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("delete FamiliaArticuloXArticulo ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Actualizar(CedForecastWebEntidades.FamiliaArticuloXArticulo Elemento)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("insert FamiliaArticuloXArticulo values ( ");
            a.Append("'" + Elemento.Id + "', ");
            a.Append("'" + Elemento.Familia.Id + "' ");
            a.Append(") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}