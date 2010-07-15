using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastWebDB
{
    public class FamiliaArticulo: db
    {
        public FamiliaArticulo(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public List<CedForecastWebEntidades.FamiliaArticulo> Lista()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select FamiliaArticulo.IdFamiliaArticulo, FamiliaArticulo.DescrFamiliaArticulo from FamiliaArticulo ");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.FamiliaArticulo> lista = new List<CedForecastWebEntidades.FamiliaArticulo>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastWebEntidades.FamiliaArticulo elemento = new CedForecastWebEntidades.FamiliaArticulo();
                    Copiar(dt.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastWebEntidades.FamiliaArticulo Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdFamiliaArticulo"]);
            Hasta.Descr = Convert.ToString(Desde["DescrFamiliaArticulo"]);
        }
        public void EliminarTodas()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("delete FamiliaArticulo ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Actualizar(CedForecastWebEntidades.FamiliaArticulo Elemento)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("insert FamiliaArticulo values ( ");
            a.Append("'" + Elemento.Id + "', ");
            a.Append("'" + Elemento.Descr + "' ");
            a.Append(") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}
