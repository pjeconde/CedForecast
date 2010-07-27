using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastWebDB
{
    public class Articulo: db
    {
        public Articulo(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        //public void Leer(CedForecastWebEntidades.Articulo Articulo)
        //{
        //    StringBuilder a = new StringBuilder(string.Empty);
        //    a.Append("select ltrim(rtrim(Articulo.IdArticulo)) as IdArticulo, Articulo.DescrArticulo, Articulo.PesoBruto, Articulo.UnidadMedida, Articulo.IdGrupoArticulo, GrupoArticulo.DescrGrupoArticulo, Articulo.Habilitado, Articulo.FechaUltModif, GrupoArticulo.IdDivision, Division.DescrDivision ");
        //    a.Append("from Articulo inner join GrupoArticulo on Articulo.IdGrupoArticulo=GrupoArticulo.IdGrupoArticulo inner join Division on GrupoArticulo.IdDivision=Division.IdDivision ");
        //    a.Append("where Articulo.IdArticulo='" + Articulo.Id.ToString() + "'");
        //    DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
        //    if (dt.Rows.Count == 0)
        //    {
        //        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Articulo " + Articulo.Id.ToString());
        //    }
        //    else
        //    {
        //        Copiar(dt.Rows[0], Articulo);
        //    }
        //}
        public List<CedForecastWebEntidades.Articulo> Lista(bool ConArticuloSinInformar, CedForecastWebEntidades.Division Division, string IdFamiliaArticulo, string ListaArticulosADescartar)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ltrim(rtrim(Articulo.IdArticulo)) as IdArticulo, Articulo.DescrArticulo, Articulo.PesoBruto, Articulo.UnidadMedida, Articulo.IdGrupoArticulo, GrupoArticulo.DescrGrupoArticulo, Articulo.Habilitado, Articulo.FechaUltModif, GrupoArticulo.IdDivision, Division.DescrDivision, FamiliaArticulo.IdFamiliaArticulo, FamiliaArticulo.DescrFamiliaArticulo ");
            a.Append("from Articulo inner join GrupoArticulo on Articulo.IdGrupoArticulo=GrupoArticulo.IdGrupoArticulo inner join Division on GrupoArticulo.IdDivision=Division.IdDivision ");
            a.Append("inner join FamiliaArticuloXArticulo on Articulo.IdArticulo=FamiliaArticuloXArticulo.IdArticulo ");
            a.Append("inner join FamiliaArticulo on FamiliaArticuloXArticulo.IdFamiliaArticulo=FamiliaArticulo.IdFamiliaArticulo ");
            a.Append("where GrupoArticulo.IdDivision = '" + Division.Id + "'");
            if (IdFamiliaArticulo != "")
            {
                a.Append(" and FamiliaArticuloXArticulo.IdFamiliaArticulo = '" + IdFamiliaArticulo + "'");
            }
            if (ListaArticulosADescartar != "")
            {
                a.Append(" and Articulo.IdArticulo not in (" + ListaArticulosADescartar + ") ");
            }
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.Articulo> lista = new List<CedForecastWebEntidades.Articulo>();
            if (dt.Rows.Count != 0)
            {
                if (ConArticuloSinInformar)
                {
                    lista.Add(new CedForecastWebEntidades.Articulo());
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastWebEntidades.Articulo Articulo = new CedForecastWebEntidades.Articulo();
                    Copiar(dt.Rows[i], Articulo);
                    lista.Add(Articulo);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastWebEntidades.Articulo Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdArticulo"]);
            Hasta.Descr = Convert.ToString(Desde["DescrArticulo"]);
            Hasta.PesoBruto = Convert.ToDecimal(Desde["PesoBruto"]);
            Hasta.UnidadMedida = Convert.ToString(Desde["UnidadMedida"]);
            Hasta.Habilitado = Convert.ToBoolean(Desde["Habilitado"]);
            Hasta.FechaUltModif = Convert.ToDateTime(Desde["FechaUltModif"]);
            Hasta.GrupoArticulo.IdGrupoArticulo = Convert.ToString(Desde["IdGrupoArticulo"]);
            Hasta.GrupoArticulo.DescrGrupoArticulo = Convert.ToString(Desde["DescrGrupoArticulo"]);
            Hasta.GrupoArticulo.Division.Id = Convert.ToString(Desde["IdDivision"]);
            Hasta.GrupoArticulo.Division.Descr = Convert.ToString(Desde["DescrDivision"]);
            Hasta.FamiliaArticulo.Id = Convert.ToString(Desde["IdFamiliaArticulo"]);
            Hasta.FamiliaArticulo.Descr = Convert.ToString(Desde["DescrFamiliaArticulo"]);
        }
        public DateTime FechaUltimaSincronizacion()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select max(FechaUltModif) as FechaUltModif from Articulo ");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows[0]["FechaUltModif"] != DBNull.Value)
            {
                return Convert.ToDateTime(dt.Rows[0]["FechaUltModif"]);
            }
            else
            {
                return new DateTime(1980, 1, 1);
            }
        }
        public void Actualizar(CedForecastWebEntidades.Articulo Elemento)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("if exists (select ltrim(rtrim(Articulo.IdArticulo)) as IdArticulo from Articulo where IdArticulo='" + Elemento.Id + "') ");
            a.Append("update Articulo set ");
            a.Append("DescrArticulo='" + Elemento.Descr + "', ");
            a.Append("IdGrupoArticulo='" + Elemento.GrupoArticulo.IdGrupoArticulo + "', ");
            a.Append("PesoBruto='" + Convert.ToString(Elemento.PesoBruto, cedeiraCultura) + "', ");
            a.Append("UnidadMedida='" + Elemento.UnidadMedida + "', ");
            a.Append("FechaUltModif='" + Elemento.FechaUltModif.ToString("yyyyMMdd HH:mm:ss.fff") + "', ");
            a.Append("Habilitado=" + Convert.ToInt16(Elemento.Habilitado).ToString() + " ");
            a.Append("where IdArticulo='" + Elemento.Id + "' ");
            a.Append("else ");
            a.Append("insert Articulo values ( ");
            a.Append("'" + Elemento.Id + "', ");
            a.Append("'" + Elemento.Descr + "', ");
            a.Append("'" + Elemento.GrupoArticulo.IdGrupoArticulo + "', ");
            a.Append("'" + Convert.ToString(Elemento.PesoBruto, cedeiraCultura) + "', ");
            a.Append("'" + Elemento.UnidadMedida + "', ");
            a.Append("'" + Elemento.FechaUltModif.ToString("yyyyMMdd HH:mm:ss.fff") + "', ");
            a.Append(Convert.ToInt16(Elemento.Habilitado).ToString() + " ");
            a.Append(") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}
