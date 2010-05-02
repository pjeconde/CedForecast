using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastWebDB
{
    public class Division: db
    {
        public Division(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public void Leer(CedForecastWebEntidades.Division Division)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Division.IdDivision, Cliente.DescrDivision ");
            a.Append("from Division ");
            a.Append("where Division.IdDivision='" + Division.Id.ToString() + "'");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Division " + Division.Id.ToString());
            }
            else
            {
                Copiar(dt.Rows[0], Division);
            }
        }
        public List<CedForecastWebEntidades.Division> Lista()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select Division.IdDivision, Division.DescrDivision ");
            a.Append("from Division");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.Division> lista = new List<CedForecastWebEntidades.Division>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastWebEntidades.Division division = new CedForecastWebEntidades.Division();
                    Copiar(dt.Rows[i], division);
                    lista.Add(division);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastWebEntidades.Division Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdDivision"]);
            Hasta.Descr = Convert.ToString(Desde["DescrDivision"]);
        }
    }
}
