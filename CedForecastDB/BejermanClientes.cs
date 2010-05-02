using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB.Bejerman
{
    public class Clientes: db
    {
        public Clientes(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public List<CedForecastEntidades.Bejerman.Clientes> LeerNovedades(DateTime FechaUltimaSincronizacion)
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select cli_Cod, cli_RazSoc, clizon_Cod, cli_Habilitado, cli_FecMod from Clientes where cli_FecMod>'" + FechaUltimaSincronizacion.ToString("yyyyMMdd HH:mm:ss.fff") + "' order by cli_FecMod");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            List<CedForecastEntidades.Bejerman.Clientes> lista = new List<CedForecastEntidades.Bejerman.Clientes>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastEntidades.Bejerman.Clientes elemento = new CedForecastEntidades.Bejerman.Clientes();
                    Copiar(dt.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastEntidades.Bejerman.Clientes Hasta)
        {
            Hasta.Cli_Cod = Convert.ToString(Desde["cli_Cod"]);
            Hasta.Cli_RazSoc = Convert.ToString(Desde["cli_RazSoc"]);
            Hasta.Clizon_Cod = Convert.ToString(Desde["clizon_Cod"]);
            Hasta.Cli_Habilitado = Convert.ToBoolean(Desde["cli_Habilitado"]);
            Hasta.Cli_FecMod = Convert.ToDateTime(Desde["cli_FecMod"]);
        }
    }
}