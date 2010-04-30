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
            Hasta.IdZona = Convert.ToString(Desde["IdZona"]);
            Hasta.DescrZona = Convert.ToString(Desde["DescrZona"]);
        }
        public DateTime FechaUltimaSincronizacion()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select max(FechaUltModif) as FEchaUltModif from Zona ");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 1)
            {
                return Convert.ToDateTime(dt.Rows[0]["FechaUltModif"]);
            }
            else
            {
                return new DateTime(1980, 1, 1);
            }
        }
    }
}
