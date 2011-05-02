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
            a.Append("select ltrim(rtrim(cli_Cod)) as cli_Cod, cli_RazSoc, clizon_Cod, cli_Habilitado, cli_FecMod from Clientes where cli_FecMod>'" + FechaUltimaSincronizacion.ToString("yyyyMMdd HH:mm:ss.fff") + "' order by cli_FecMod");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            return Lista(dt);
        }
        public List<CedForecastEntidades.Bejerman.Clientes> LeerLista(DataTable Clientes)
        {
            List<CedForecastEntidades.Bejerman.Clientes> lista = new List<CedForecastEntidades.Bejerman.Clientes>();
            if (Clientes.Rows.Count != 0)
            {
                DataTable dt = new DataTable();
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ltrim(rtrim(cli_Cod)) as cli_Cod, cli_RazSoc, clizon_Cod, cli_Habilitado, cli_FecMod from Clientes where ltrim(rtrim(cli_Cod)) in (");
                for (int i = 0; i < Clientes.Rows.Count; i++)
                {
                    a.Append("'" + Clientes.Rows[i]["Cliente"] + "'");
                    if (i != Clientes.Rows.Count - 1)
                    {
                        a.Append(", ");
                    }
                }
                a.Append(") order by ltrim(rtrim(cli_Cod)) ");
                dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
                lista = Lista(dt);
            }
            return lista;
        }
        public List<CedForecastEntidades.Bejerman.Clientes> LeerLista()
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ltrim(rtrim(cli_Cod)) as cli_Cod, cli_RazSoc, clizon_Cod, cli_Habilitado, cli_FecMod from Clientes order by ltrim(rtrim(cli_Cod)) ");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            return Lista(dt);
        }
        private List<CedForecastEntidades.Bejerman.Clientes> Lista(DataTable Datos)
        {
            List<CedForecastEntidades.Bejerman.Clientes> lista = new List<CedForecastEntidades.Bejerman.Clientes>();
            if (Datos.Rows.Count != 0)
            {
                for (int i = 0; i < Datos.Rows.Count; i++)
                {
                    CedForecastEntidades.Bejerman.Clientes elemento = new CedForecastEntidades.Bejerman.Clientes();
                    Copiar(Datos.Rows[i], elemento);
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
        public List<CedForecastEntidades.Bejerman.Clientes> LeerClientesSinZona()
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ltrim(rtrim(cli_Cod)) as cli_Cod, cli_RazSoc, clizon_Cod, cli_Habilitado, cli_FecMod from Clientes where cliZon_Cod is null order by ltrim(rtrim(cli_Cod)) ");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            return Lista(dt);
        }
    }
}