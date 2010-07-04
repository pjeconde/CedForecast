using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB.Bejerman
{
    public class Vendedor : db
    {
        public Vendedor(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }
        public List<CedForecastEntidades.Bejerman.Vendedor> LeerNovedades(DateTime FechaUltimaSincronizacion)
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ltrim(rtrim(ven_Cod)) as ven_Cod, ven_Desc, ven_Tel, ven_email, ven_Fax, ven_Password, ven_Activo, ven_FecMod from Vendedor where ven_FecMod>'" + FechaUltimaSincronizacion.ToString("yyyyMMdd HH:mm:ss.fff") + "' order by ven_FecMod");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            return Lista(dt);
        }
        public List<CedForecastEntidades.Bejerman.Vendedor> LeerLista(DataTable Vendedores)
        {
            List<CedForecastEntidades.Bejerman.Vendedor> lista = new List<CedForecastEntidades.Bejerman.Vendedor>();
            if (Vendedores.Rows.Count != 0)
            {
                DataTable dt = new DataTable();
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ltrim(rtrim(ven_Cod)) as ven_Cod, ven_Desc, ven_Tel, ven_email, ven_Fax, ven_Password, ven_Activo, ven_FecMod from Vendedor where ltrim(rtrim(ven_Cod)) in (");
                for (int i = 0; i < Vendedores.Rows.Count; i++)
                {
                    a.Append("'" + Vendedores.Rows[i]["Vendedor"] + "'");
                    if (i != Vendedores.Rows.Count - 1)
                    {
                        a.Append(", ");
                    }
                } a.Append(") order by ltrim(rtrim(ven_Cod)) ");
                dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
                lista = Lista(dt);
            }
            return lista;
        }
        public List<CedForecastEntidades.Bejerman.Vendedor> LeerLista()
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ltrim(rtrim(ven_Cod)) as ven_Cod, ven_Desc, ven_Tel, ven_email, ven_Fax, ven_Password, ven_Activo, ven_FecMod from Vendedor order by ven_Cod");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            return Lista(dt);
        }
        private List<CedForecastEntidades.Bejerman.Vendedor> Lista(DataTable Datos)
        {
            List<CedForecastEntidades.Bejerman.Vendedor> lista = new List<CedForecastEntidades.Bejerman.Vendedor>();
            if (Datos.Rows.Count != 0)
            {
                for (int i = 0; i < Datos.Rows.Count; i++)
                {
                    CedForecastEntidades.Bejerman.Vendedor elemento = new CedForecastEntidades.Bejerman.Vendedor();
                    Copiar(Datos.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastEntidades.Bejerman.Vendedor Hasta)
        {
            Hasta.Ven_Cod = Convert.ToString(Desde["ven_Cod"]);
            Hasta.Ven_Desc = Convert.ToString(Desde["ven_Desc"]);
            Hasta.Ven_Tel = Convert.ToString(Desde["ven_Tel"]);
            Hasta.Ven_email = Convert.ToString(Desde["ven_email"]);
            Hasta.Ven_Fax = Convert.ToString(Desde["ven_Fax"]);
            Hasta.Ven_Password = Convert.ToString(Desde["ven_Password"]);
            Hasta.Ven_Activo = Convert.ToString(Desde["ven_Activo"]);
            Hasta.Ven_FecMod = Convert.ToDateTime(Desde["ven_FecMod"]);
        }
    }
}