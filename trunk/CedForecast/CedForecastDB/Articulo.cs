using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB
{
    public class Articulo: db
    {
        public Articulo(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public List<CedForecastEntidades.Articulo> LeerLista()
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select FamiliaArticuloXArticulo.IdArticulo, FamiliaArticulo.IdFamiliaArticulo, FamiliaArticulo.DescrFamiliaArticulo from FamiliaArticuloXArticulo, FamiliaArticulo where FamiliaArticuloXArticulo.IdFamiliaArticulo=FamiliaArticulo.IdFamiliaArticulo order by FamiliaArticuloXArticulo.IdArticulo ");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastEntidades.Articulo> lista = new List<CedForecastEntidades.Articulo>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastEntidades.Articulo elemento = new CedForecastEntidades.Articulo();
                    Copiar(dt.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastEntidades.Articulo Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdArticulo"]);
            Hasta.Familia.Id = Convert.ToString(Desde["IdFamiliaArticulo"]);
            Hasta.Familia.Descr = Convert.ToString(Desde["DescrFamiliaArticulo"]);
        }
    }
}