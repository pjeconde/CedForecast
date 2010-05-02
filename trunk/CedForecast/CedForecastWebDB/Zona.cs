using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastWebDB
{
    public class Zona: db
    {
        public Zona(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public List<CedForecastWebEntidades.Zona> Lista()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select Zona.IdZona, Zona.DescrZona from Zona ");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.Zona> lista = new List<CedForecastWebEntidades.Zona>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastWebEntidades.Zona zona = new CedForecastWebEntidades.Zona();
                    Copiar(dt.Rows[i], zona);
                    lista.Add(zona);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastWebEntidades.Zona Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdZona"]);
            Hasta.Descr = Convert.ToString(Desde["DescrZona"]);
        }
        public DateTime FechaUltimaSincronizacion()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select max(FechaUltModif) as FechaUltModif from Zona ");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows[0]["FechaUltModif"] != DBNull.Value )
            {
                return Convert.ToDateTime(dt.Rows[0]["FechaUltModif"]);
            }
            else
            {
                return new DateTime(1980, 1, 1);
            }
        }
        public void Actualizar(CedForecastWebEntidades.Zona Elemento)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("if exists (select IdZona from Zona where IdZona='" + Elemento.Id + "') ");
            a.Append("update Zona set ");
            a.Append("DescrZona='" + Elemento.Descr + "', ");
            a.Append("Habilitada=" + Convert.ToInt16(Elemento.Habilitada).ToString() + ", ");
            a.Append("FechaUltModif='" + Elemento.FechaUltModif.ToString("yyyyMMdd HH:mm:ss.fff") + "' ");
            a.Append("where IdZona='" + Elemento.Id + "' ");
            a.Append("else ");
            a.Append("insert Zona values ( ");
            a.Append("'" + Elemento.Id + "', ");
            a.Append("'" + Elemento.Descr + "', ");
            a.Append(Convert.ToInt16(Elemento.Habilitada).ToString() + ", ");
            a.Append("'" + Elemento.FechaUltModif.ToString("yyyyMMdd HH:mm:ss.fff") + "' ");
            a.Append(") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}
