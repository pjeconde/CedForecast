using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB.Bejerman
{
    public class Zona: db
    {
        public Zona(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public List<CedForecastEntidades.Bejerman.Zona> LeerNovedades(DateTime FechaUltimaSincronizacion)
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ltrim(rtrim(zon_Cod)) as zon_Cod, zon_Desc, zon_FecMod from Zona where zon_FecMod>'" + FechaUltimaSincronizacion.ToString("yyyyMMdd HH:mm:ss.fff") + "' order by zon_FecMod");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            List<CedForecastEntidades.Bejerman.Zona> lista = new List<CedForecastEntidades.Bejerman.Zona>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastEntidades.Bejerman.Zona elemento = new CedForecastEntidades.Bejerman.Zona();
                    Copiar(dt.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        public List<CedForecastEntidades.Bejerman.Zona> LeerLista()
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ltrim(rtrim(zon_Cod)) as zon_Cod, zon_Desc, zon_FecMod from Zona order by zon_Desc");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            List<CedForecastEntidades.Bejerman.Zona> lista = new List<CedForecastEntidades.Bejerman.Zona>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastEntidades.Bejerman.Zona elemento = new CedForecastEntidades.Bejerman.Zona();
                    Copiar(dt.Rows[i], elemento);
                    LeerClientes(elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastEntidades.Bejerman.Zona Hasta)
        {
            Hasta.Zon_Cod = Convert.ToString(Desde["zon_Cod"]);
            Hasta.Zon_Desc = Convert.ToString(Desde["zon_Desc"]);
            Hasta.Zon_FecMod = Convert.ToDateTime(Desde["zon_FecMod"]);
        }
        private void LeerClientes(CedForecastEntidades.Bejerman.Zona Zona)
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ltrim(rtrim(cli_Cod)) as cli_Cod, cli_RazSoc, clizon_Cod, cli_Habilitado, cli_FecMod from Clientes where ltrim(rtrim(clizon_Cod))='" + Zona.Zon_Cod + "'");
            a.Append(" order by ltrim(rtrim(cli_Cod)) ");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            Zona.Clientes.Clear();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastEntidades.Bejerman.Clientes elemento = new CedForecastEntidades.Bejerman.Clientes();
                    elemento.Cli_Cod = Convert.ToString(dt.Rows[i]["Cli_Cod"]);
                    elemento.Cli_RazSoc = Convert.ToString(dt.Rows[i]["Cli_RazSoc"]);
                    Zona.Clientes.Add(elemento);
                }
            }
        }
    }
}
