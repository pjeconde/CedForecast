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

        public void Leer(CedForecastWebEntidades.Articulo Articulo)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Articulo.IdArticulo, Articulo.DescrArticulo, Articulo.IdZona, Articulo.Habilitado, Articulo.FechaUltModif ");
            a.Append("from Articulo left outer join Zona on Articulo.IdZona=Zona.IdZona ");
            a.Append("where Articulo.IdArticulo='" + Articulo.IdArticulo.ToString() + "'");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Articulo " + Articulo.IdArticulo.ToString());
            }
            else
            {
                Copiar(dt.Rows[0], Articulo);
            }
        }
        public List<CedForecastWebEntidades.Articulo> Lista()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select Articulo.IdArticulo, Articulo.DescrArticulo, Articulo.PesoBruto, Articulo.UnidadMedida, Articulo.IdGrupoArticulo, GrupoArticulo.DescrGrupoArticulo, Articulo.Habilitado, Articulo.FechaUltModif, GrupoArticulo.IdDivision, Division.DescrDivision ");
            a.Append("from Articulo inner join GrupoArticulo on Articulo.IdGrupoArticulo=GrupoArticulo.IdGrupoArticulo ");
            a.Append("inner join Division on GrupoArticulo.IdDivision=Division.IdDivision");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.Articulo> lista = new List<CedForecastWebEntidades.Articulo>();
            if (dt.Rows.Count != 0)
            {
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
            Hasta.IdArticulo = Convert.ToString(Desde["IdArticulo"]);
            Hasta.DescrArticulo = Convert.ToString(Desde["DescrArticulo"]);
            Hasta.PesoBruto = Convert.ToDecimal(Desde["PesoBruto"]);
            Hasta.UnidadMedida = Convert.ToString(Desde["UnidadMedida"]);
            Hasta.Habilitado = Convert.ToBoolean(Desde["Habilitado"]);
            Hasta.FechaUltModif = Convert.ToDateTime(Desde["FechaUltModif"]);
            Hasta.GrupoArticulo = new CedForecastWebEntidades.GrupoArticulo(); 
            Hasta.GrupoArticulo.IdGrupoArticulo = Convert.ToString(Desde["IdGrupoArticulo"]);
            Hasta.GrupoArticulo.DescrGrupoArticulo = Convert.ToString(Desde["DescrGrupoArticulo"]);
            Hasta.GrupoArticulo.Division = new CedForecastWebEntidades.Division();
            Hasta.GrupoArticulo.Division.IdDivision = Convert.ToString(Desde["IdDivision"]);
            Hasta.GrupoArticulo.Division.DescrDivision = Convert.ToString(Desde["DescrDivision"]);
        }
    }
}
