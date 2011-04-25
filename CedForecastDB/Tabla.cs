using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB
{
    public class Tabla : db
    {
        public Tabla(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public List<CedForecastEntidades.Codigo> Leer(string Tabla)
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select * from Tabla where Tabla='"+Tabla+"' order by Descr");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastEntidades.Codigo> lista = new List<CedForecastEntidades.Codigo>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastEntidades.Codigo elemento = new CedForecastEntidades.Codigo();
                    Copiar(dt.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastEntidades.Codigo Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["Id"]);
            Hasta.Descr = Convert.ToString(Desde["Descr"]);
        }
    }
}
