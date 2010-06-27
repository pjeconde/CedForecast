using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB.Bejerman
{
    public class Articulos: db
    {
        public Articulos(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }
        public List<CedForecastEntidades.Bejerman.Articulos> LeerNovedades(DateTime FechaUltimaSincronizacion)
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ltrim(rtrim(art_CodGen)) as art_CodGen, art_DescGen, art_PesoBruto, artcla_Cod, art_FecMod, artda2_cod from Articulos where art_FecMod>'" + FechaUltimaSincronizacion.ToString("yyyyMMdd HH:mm:ss.fff") + "' order by art_FecMod");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            List<CedForecastEntidades.Bejerman.Articulos> lista = new List<CedForecastEntidades.Bejerman.Articulos>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastEntidades.Bejerman.Articulos elemento = new CedForecastEntidades.Bejerman.Articulos();
                    Copiar(dt.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        public List<CedForecastEntidades.Bejerman.Articulos> LeerLista(DataTable Articulos)
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ltrim(rtrim(art_CodGen)) as art_CodGen, art_DescGen, art_PesoBruto, artcla_Cod, art_FecMod, artda2_cod from Articulos where ltrim(rtrim(art_CodGen)) in (");
            for (int i = 0; i < Articulos.Rows.Count; i++)
            {
                a.Append("'" + Articulos.Rows[i]["Articulo"] + "'");
                if (i != Articulos.Rows.Count - 1)
                {
                    a.Append(", ");
                }
            } a.Append(") order by ltrim(rtrim(art_CodGen)) ");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            List<CedForecastEntidades.Bejerman.Articulos> lista = new List<CedForecastEntidades.Bejerman.Articulos>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastEntidades.Bejerman.Articulos elemento = new CedForecastEntidades.Bejerman.Articulos();
                    Copiar(dt.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastEntidades.Bejerman.Articulos Hasta)
        {
            Hasta.Art_CodGen = Convert.ToString(Desde["art_CodGen"]);
            Hasta.Art_DescGen = Convert.ToString(Desde["art_DescGen"]);
            Hasta.Art_PesoBruto = Convert.ToDecimal(Desde["art_PesoBruto"]);
            Hasta.Artcla_Cod = Convert.ToString(Desde["artcla_Cod"]);
            Hasta.Artda2_cod = Convert.ToString(Desde["artda2_cod"]);
            Hasta.Art_FecMod = Convert.ToDateTime(Desde["art_FecMod"]);
        }
    }
}